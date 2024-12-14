using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDangKyHocPhan
{
    public partial class frmQLMonHoc : Form
    {
        public frmQLMonHoc()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ

        string chuoiKN = "server = Admin-PC\\SQLEXPRESS; database = QLDKHP; integrated security = true";
        DataTable dsMonHoc;
        int ctdtHienTai = 0;

        private void TaiDSMonHoc (int ctdt)
        {
            using (SqlConnection kn = new SqlConnection (chuoiKN))
            using (SqlCommand cmd = new SqlCommand("LayDS_MonHoc", kn))
            using (SqlDataAdapter laydl = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@mactdt", ctdt);

                dsMonHoc = new DataTable();

                kn.Open ();

                laydl.Fill (dsMonHoc);
            }
            
            dgvMonHoc.AutoGenerateColumns = false; //để datagridview không tự tạo thêm cột
            dgvMonHoc.DataSource = dsMonHoc;
        }

        #endregion

        private void frmQLMonHoc_Load(object sender, EventArgs e)
        {
            TaiDSMonHoc(ctdtHienTai);
            rdTatCa.Checked = true;
        }

        //Tải danh sách môn học theo chương trình đào tạo
        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked)
            {
                TaiDSMonHoc(0);
                ctdtHienTai = 0;
            }
            else if (rdCT2015.Checked)
            {
                TaiDSMonHoc(1);
                ctdtHienTai = 1;
            }
            else if (rdCT2017.Checked)
            {
                TaiDSMonHoc(2);
                ctdtHienTai = 2;
            }
            else if (rdCT2020.Checked)
            {
                TaiDSMonHoc(3);
                ctdtHienTai = 3;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmMonHoc gdMonHoc = new frmMonHoc();
            gdMonHoc.FormClosed += new FormClosedEventHandler(gdMonHoc_FormClosed);

            gdMonHoc.Show(this);
        }

        void gdMonHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ctdtHienTai == 0)
            {
                rdTatCa.Checked = false;
                rdTatCa.Checked = true;
            }
            else if (ctdtHienTai == 1)
            {
                rdCT2015.Checked = false;
                rdCT2015.Checked = true;
            }
            else if (ctdtHienTai == 2)
            {
                rdCT2017.Checked = false;
                rdCT2017.Checked = true;
            }
            else if (ctdtHienTai == 3)
            {
                rdCT2020.Checked = false;
                rdCT2020.Checked = true;
            }
        }

        //Sự kiện giúp tìm kiếm môn học theo điều kiện
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dsMonHoc == null) return;

            string bieuThucLoc = "";
            string bieuThucSapXep = "SoTC DESC";
            DataViewRowState trangThaiDong = DataViewRowState.OriginalRows;

            if (rdMa_Ten.Checked)
                bieuThucLoc = $"MaMH like '%{txtTimKiem.Text}%' or TenMH like '%{txtTimKiem.Text}%'";
            //Tìm kiếm bằng tên môn học hoặc mã môn học
            
            else if (rdSTC.Checked)
            {
                // Kiểm tra đầu vào có phải số hay không (tránh lỗi khi nhập chuỗi)
                if (int.TryParse(txtTimKiem.Text, out int soTinChi))
                {
                    bieuThucLoc = $"SoTC = {soTinChi}";
                }
                else
                {
                    bieuThucLoc = "SoTC IS NULL"; // Không khớp nếu đầu vào không hợp lệ
                }
            }
            
            //Tạo DataView với điều kiện lọc và sắp xếp
            DataView ketQua = new DataView(dsMonHoc, bieuThucLoc, bieuThucSapXep, trangThaiDong);

            dgvMonHoc.DataSource = ketQua;
        }

        private void dgvMonHoc_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow mhChon = dgvMonHoc.SelectedRows[0];
                DataRowView mh = mhChon.DataBoundItem as DataRowView;

                frmMonHoc gdmonHoc = new frmMonHoc();
                gdmonHoc.FormClosed += new FormClosedEventHandler(gdMonHoc_FormClosed);

                gdmonHoc.Show(this);
                gdmonHoc.HienThiThongTinMH(mh);
            }    
        }

        private void tsmiTinhSoSVDK_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                string mamh = dgvMonHoc.SelectedRows[0].Cells["MaMH"].Value.ToString().Trim();
                string tenmh = dgvMonHoc.SelectedRows[0].Cells["TenMH"].Value.ToString().Trim();
                int soSinhVien = 0;

                try
                {
                    using (SqlConnection kn = new SqlConnection(chuoiKN))
                    using (SqlCommand cmd = new SqlCommand("TinhSoSV_DangKyMH", kn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@mamh", mamh);

                        SqlParameter kq = new SqlParameter
                        {
                            ParameterName = "@kq",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output,
                        };
                        cmd.Parameters.Add(kq);

                        kn.Open();

                        cmd.ExecuteNonQuery();

                        soSinhVien = (int)cmd.Parameters["@kq"].Value;
                    }

                    MessageBox.Show($"Số sinh viên đăng ký môn học '{tenmh}' là: {soSinhVien.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Vui lòng chọn môn học cần tính toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
    }
}
