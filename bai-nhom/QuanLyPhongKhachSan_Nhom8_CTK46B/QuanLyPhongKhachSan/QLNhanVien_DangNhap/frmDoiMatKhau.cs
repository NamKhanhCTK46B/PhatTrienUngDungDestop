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

namespace QuanLyPhongKhachSan.QLNhanVien_DangNhap
{
    public partial class frmDoiMatKhau : Form
    {
        string connectionString = TienIch.ChuoiKetNoi;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private bool ChangePassword(string oldPassword, string newPassword)
        {
            // Lấy username hiện tại (giả sử bạn có lưu trữ thông tin này)
            string currentUsername = TTNguoiDung.TenDN; // Thay thế với username thực tế (có thể lấy từ session hoặc user đang đăng nhập)

            try
            {
                // Mở kết nối đến database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra mật khẩu cũ có đúng không
                    string checkPasswordQuery = "SELECT MatKhau FROM NhanVien WHERE TenDN = @TenDN";
                    using (SqlCommand checkCommand = new SqlCommand(checkPasswordQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TenDN", currentUsername);

                        string storedPassword = (string)checkCommand.ExecuteScalar();

                        // So sánh mật khẩu cũ với mật khẩu trong database
                        if (storedPassword != oldPassword)
                        {
                            return false; // Mật khẩu cũ không đúng
                        }
                    }

                    // Cập nhật mật khẩu mới vào cơ sở dữ liệu
                    string updatePasswordQuery = "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE TenDN = @TenDN";
                    using (SqlCommand updateCommand = new SqlCommand(updatePasswordQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@MatKhauMoi", newPassword);
                        updateCommand.Parameters.AddWithValue("@TenDN", currentUsername);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        return rowsAffected > 0; // Nếu cập nhật thành công, trả về true
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPass.Text.Trim();
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtNewPassConfirm.Text.Trim();

            // Kiểm tra các điều kiện mật khẩu
            if (oldPassword == "" || newPassword == "" || confirmPassword == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool passwordChanged = ChangePassword(oldPassword, newPassword);

            if (passwordChanged)
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thay đổi mật khẩu thành công
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
