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
using TruyCapDuLieu;

namespace QuanLyPhongKhachSan.TrangChu
{
    public partial class frmHoaDon : Form
        
    {
        string connetString = TienIch.ChuoiKetNoi;//@"Data Source=LAPTOP-NBIQUV5E;Initial Catalog=QuanLyPhongKhachSan;Integrated Security=True";
        public int IDHD { get; private set; }
        public frmHoaDon(int idHD) 
        {
            InitializeComponent();
                 this.IDHD = idHD;
            LoadHoaDonData();
            LoadHoaDonData_Room();
        }
      
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
         
        }
        private void LoadHoaDonData_Room()
        {
            if (IDHD <= 0)
            {
                MessageBox.Show("ID hóa đơn không hợp lệ.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                string query = @"
                SELECT 
                   P.ID_Phong AS 'ID',
                    P.SoPhong AS 'Số Phòng',
                    HP.HangPhong AS 'Hạng Phòng',
                    HP.Gia AS 'Giá Tiền'
                FROM CT_HD CTHD
                INNER JOIN Phong P ON CTHD.ID_Phong = P.ID_Phong
                INNER JOIN HangPhong HP ON P.ID_HP = HP.ID_HP
                WHERE CTHD.ID_HD = @ID_HD
                ORDER BY P.SoPhong;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_HD", IDHD);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable roomTable = new DataTable();
                        adapter.Fill(roomTable);

                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = roomTable;
                    }
                }
            }
        }
        private void LoadHoaDonData()
        {
            if (IDHD <= 0)
            {
                MessageBox.Show("ID hóa đơn không hợp lệ.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                try
                {
                    conn.Open();

                    string query = @"
            SELECT TOP 1
                HD.ID_HD,
                HD.NgayLap,
                NV.TenNV,
                KH.TenKH,
                HD.NgayToi,
                HD.NgayDi,
                HD.DatCoc,
                HD.PhuThu,
                HD.TongTien,
                ct.ThoiGianThue
            FROM HoaDon HD
            INNER JOIN NhanVien NV ON HD.ID_NV = NV.ID_NV
            INNER JOIN KhachHang KH ON HD.ID_KH = KH.ID_KH
            INNER JOIN CT_HD ct ON HD.ID_HD = ct.ID_HD
            WHERE HD.ID_HD = @ID_HD";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_HD", IDHD);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lbSoHD.Text = reader["ID_HD"].ToString();
                                txtNgayHoaDon.Text = Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy");
                                lbNV.Text = reader["TenNV"].ToString();
                                txtKH.Text = reader["TenKH"].ToString();
                                txtThoiDiemVao.Text = Convert.ToDateTime(reader["NgayToi"]).ToString("dd/MM/yyyy");
                                txtThoiDiemRa.Text = Convert.ToDateTime(reader["NgayDi"]).ToString("dd/MM/yyyy");
                                label9.Text = Convert.ToDouble(reader["DatCoc"]).ToString("N0");
                                label2.Text = Convert.ToDouble(reader["PhuThu"]).ToString("N0");
                                txtTongTienTT.Text = Convert.ToDouble(reader["TongTien"]).ToString("N0");
                                lbSoDem.Text = reader["ThoiGianThue"].ToString();
                            }
                            else
                            {
                                MessageBox.Show($"Không tìm thấy hóa đơn với ID_HD = {IDHD}");
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu DataGridView không rỗng
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phòng.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Duyệt qua các dòng trong DataGridView
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            // Lấy ID phòng từ cột 0 của DataGridView (cột đầu tiên)
                            if (row.Cells[0].Value == null)
                                continue;  // Bỏ qua dòng nếu ID phòng không có giá trị

                            int IDPhongTro = Convert.ToInt32(row.Cells[0].Value);

                            if (IDPhongTro <= 0)
                            {
                                MessageBox.Show("ID phòng không hợp lệ.");
                                continue;
                            }

                            // Kiểm tra trạng thái phòng hiện tại
                            string queryCheck = "SELECT TrangThai FROM Phong WHERE ID_Phong = @ID_PhongTro";
                            SqlCommand cmdCheck = new SqlCommand(queryCheck, conn, transaction);
                            cmdCheck.Parameters.AddWithValue("@ID_PhongTro", IDPhongTro);

                            object result = cmdCheck.ExecuteScalar();

                            if (result == null)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Phòng không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            int trangThaiHienTai = Convert.ToInt32(result);

                            // Nếu trạng thái hiện tại là 4, cập nhật thành trạng thái 2
                            if (trangThaiHienTai == 4)
                            {
                                string queryUpdate = "UPDATE Phong SET TrangThai = 2 WHERE ID_Phong = @ID_PhongTro";
                                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn, transaction);
                                cmdUpdate.Parameters.AddWithValue("@ID_PhongTro", IDPhongTro);

                                int rowsAffected = cmdUpdate.ExecuteNonQuery();
                                MessageBox.Show(""+IDPhongTro);
                                if (rowsAffected <= 0)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Không thể cập nhật trạng thái phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        // Xác nhận giao dịch sau khi xử lý tất cả các phòng
                        transaction.Commit();
                        MessageBox.Show("Cập nhật trạng thái phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi thì rollback và thông báo lỗi
                        transaction.Rollback();
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
