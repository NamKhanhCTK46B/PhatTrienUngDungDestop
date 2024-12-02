using QuanLyPhongKhachSan.TrangChu;
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
using TruyCapDuLieu.LopAnhXa;
using XuLy;

namespace QuanLyPhongKhachSan
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        string chuoiKN = TienIch.ChuoiKetNoi;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tendn = txtTenDN.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tendn) || string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection kn = new SqlConnection(chuoiKN))
            {
                try
                {
                    kn.Open();
                    string truyvan = @"
                    SELECT *
                    FROM NhanVien
                    WHERE TenDN = @TenDN
                    AND MatKhau = @MatKhau
                    AND KhaDung = 0";

                    SqlCommand cmd = new SqlCommand(truyvan, kn);
                    cmd.Parameters.AddWithValue("@TenDN", tendn);
                    cmd.Parameters.AddWithValue("@MatKhau", matkhau);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Close();
                        TTNguoiDung.TenDN = txtTenDN.Text.Trim();

                        frmTrangChu trangChu = new frmTrangChu();
                        trangChu.ShowDialog();
                        //this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenDN.Text = "";
                        txtMatKhau.Text = "";
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
