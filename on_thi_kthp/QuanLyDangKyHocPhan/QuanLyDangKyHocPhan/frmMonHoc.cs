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
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ

        string chuoiKN = "server = Admin-PC\\SQLEXPRESS; database = QLDKHP; integrated security = true";

        private void LayDS_CTDT ()
        {
            try
            {
                // Sử dụng `using` để tự động giải phóng tài nguyên.
                using (SqlConnection kn = new SqlConnection(chuoiKN))
                using (SqlCommand cmd = new SqlCommand("LayDS_ChuongTrinhDT", kn))
                using (SqlDataAdapter laydl = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Xác định rõ loại lệnh là stored procedure.
                    DataTable ds = new DataTable();

                    kn.Open();
                    laydl.Fill(ds);

                    if (ds.Rows.Count > 0) // Kiểm tra dữ liệu có hay không.
                    {
                        cboCTDT.DataSource = ds;
                        cboCTDT.DisplayMember = "TenCTDT";
                        cboCTDT.ValueMember = "MaCTDT";
                    }
                    else
                    {
                        cboCTDT.DataSource = null;
                        MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu xảy ra vấn đề trong quá trình thực thi.
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraNhapTT ()
        {
            if (string.IsNullOrEmpty(txtTenMH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học", "Thông báo");
                return false;
            }    

            if (cboCTDT.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình đào tạo", "Thông báo");
                return false;
            }  
            
            return true;
        }

        private void Them_MonHoc ()
        {
            try
            {
                // Sử dụng `using` để đảm bảo giải phóng tài nguyên
                using (SqlConnection kn = new SqlConnection(chuoiKN))
                using (SqlCommand cmd = new SqlCommand("ThemSuaXoa_MonHoc", kn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; // Xác định loại lệnh là stored procedure (thủ tục)

                    // Thêm các tham số cho stored procedure
                    cmd.Parameters.Add(new SqlParameter("@mamh", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    });
                    cmd.Parameters.AddWithValue("@ten", txtTenMH.Text.Trim());
                    cmd.Parameters.AddWithValue("@sotc", nudSoTC.Value);
                    cmd.Parameters.AddWithValue("@ctdt", cboCTDT.SelectedValue);
                    cmd.Parameters.AddWithValue("@thaotac", 0); // 0: Thêm mới

                    kn.Open();

                    int soHangBiTacDong = cmd.ExecuteNonQuery();

                    if (soHangBiTacDong > 0)
                    {
                        // Lấy mã môn học từ tham số output
                        string maMonHoc = cmd.Parameters["@mamh"].Value.ToString();
                        MessageBox.Show($"Thêm môn học thành công. Mã môn học là: {maMonHoc}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm môn học thất bại. Vui lòng thử lại.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }

                }    
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

        public void HienThiThongTinMH (DataRowView mh)
        {
            try
            {
                txtMaMH.Text = mh["MaMH"].ToString();
                txtTenMH.Text = mh["TenMH"].ToString();
                nudSoTC.Value = int.Parse(mh["SoTC"].ToString());

                cboCTDT.SelectedIndex = -1;
                for (int i = 0; i < cboCTDT.Items.Count; i++)
                {
                    DataRowView ctdt = cboCTDT.Items[i] as DataRowView;
                    if (ctdt["MaCTDT"].ToString() == mh["MaCTĐT"].ToString())
                    {
                        cboCTDT.SelectedIndex = i;
                        break;
                    }    
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }

        #endregion

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            LayDS_CTDT();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
