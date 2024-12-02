using System;
using System.Collections;
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
   
    public partial class frmDatPhong : Form
    {
        string connetString = TienIch.ChuoiKetNoi; //@"Data Source=LAPTOP-NBIQUV5E;Initial Catalog=QuanLyPhongKhachSan;Integrated Security=True";
        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
            LoadAvailableRooms();
            CalculateRentalTime();
            CalculateTotalRoomPrice();
            listView3.DoubleClick += listView3_DoubleClick;
        }
        private void LoadData()
        {
            // Ví dụ load lại danh sách phòng vào listView1
            listView1.Items.Clear();

            using (SqlConnection conn = new SqlConnection("Chuỗi kết nối của bạn"))
            {
                conn.Open();
                string query = "SELECT * FROM Phong"; // Giả sử bạn muốn load lại danh sách phòng

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["ID_Phong"].ToString());
                        item.SubItems.Add(reader["TenPhong"].ToString());
                        item.SubItems.Add(reader["Gia"].ToString());
                        // Thêm các cột khác nếu cần
                        listView1.Items.Add(item);
                    }
                }
            }
        }
        private void DatPhong_Load(object sender, EventArgs e)
        {
            // dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            // dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            LoadCustomerList();
            LoadAvailableRooms();
            CalculateRentalTime();
            CalculateTotalRoomPrice();
            listView3.DoubleClick += listView3_DoubleClick;


        }
        private void LoadCustomerList()
        {
            // Clear any previous items in the ListView
            listView1.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string selectQuery = "SELECT ID_KH, TenKH, GioiTinh, SDT, Email, SoGiayTo, GhiChu, KhaDung FROM KhachHang";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Create a new ListViewItem for each row
                            ListViewItem item = new ListViewItem(reader["ID_KH"].ToString());
                            item.SubItems.Add(reader["TenKH"].ToString());
                            item.SubItems.Add((bool)reader["GioiTinh"] ? "Nam" : "Nữ"); // Convert boolean to text
                                                                                        // item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy"));
                            item.SubItems.Add(reader["SDT"].ToString());
                            item.SubItems.Add(reader["Email"].ToString());
                            item.SubItems.Add(reader["SoGiayTo"].ToString());
                            item.SubItems.Add(reader["GhiChu"].ToString());
                            item.SubItems.Add(reader["KhaDung"].ToString());

                            // Add the item to the ListView
                            listView1.Items.Add(item);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
                    }
                }
            }
        }

        private void txtTenKh_TextChanged(object sender, EventArgs e)
        {
            string tenKhachHang = txtTenKh.Text;
            FilterCustomerList(tenKhachHang);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected ListViewItem
                ListViewItem item = listView1.SelectedItems[0];

                // Populate the controls with the corresponding values
                txtTenKh.Text = item.SubItems[1].Text; // TenKH
                txtSDT.Text = item.SubItems[3].Text; // SDT
                txtEmail.Text = item.SubItems[4].Text; // Email
                txtGiayTo.Text = item.SubItems[5].Text; // SoGiayTo

                // Set the gender RadioButton
                if (item.SubItems[2].Text == "Nam")
                {
                    rdNam.Checked = true;
                    rdNu.Checked = false;
                }
                else
                {
                    rdNam.Checked = false;
                    rdNu.Checked = true;
                }
                listView1.ListViewItemSorter = new ListViewItemComparer(0);
                // dtpNgaySinh.Value = DateTime.Parse(item.SubItems[3].Text);
            }
        }
        private void LoadAvailableRooms()
        {
            // Clear any previous items in the ListView
            listView2.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string query = "SELECT Phong.ID_Phong, Phong.SoPhong,HangPhong.HangPhong FROM Phong JOIN HangPhong ON Phong.ID_HP = HangPhong.ID_HP JOIN Tang ON Phong.ID_Tang = Tang.ID_Tang  WHERE   Phong.TrangThai = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Create a new ListViewItem for each row
                            ListViewItem item = new ListViewItem(reader["ID_Phong"].ToString());
                            item.SubItems.Add(reader["SoPhong"].ToString());
                            item.SubItems.Add(reader["HangPhong"].ToString());

                            // Add the item to the ListView
                            listView2.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
                    }
                }
            }
        }
        public void LoadDanhSachPhong(DateTime ngayDen, DateTime ngayDi)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = connetString;

            // Truy vấn SQL để lấy danh sách phòng trống
            string query = @"
        WITH HoaDonTrongKhoang AS (
            SELECT 
            HD.ID_HD, 
            HD.NgayLap, 
            HD.NgayToi, 
            HD.NgayDi, 
            HD.PhuThu, 
            HD.TrangThai, 

            FROM 
                HoaDon AS HD
            INNER JOIN 
                NhanVien AS NV ON HD.ID_NV = NV.ID_NV
            INNER JOIN 
                KhachHang AS KH ON HD.ID_KH = KH.ID_KH
            WHERE 
                (HD.NgayToi <= @NgayKetThuc) AND (HD.NgayDi >= @NgayBatDau)
        )
        SELECT 
            P.ID_Phong,
            P.SoPhong,
            HP.HangPhong
        FROM 
            Phong AS P
        INNER JOIN 
            HangPhong AS HP ON P.ID_HP = HP.ID_HP
        WHERE 
            P.KhaDung = 0
            AND NOT EXISTS (
                SELECT 1
                FROM HoaDonTrongKhoang AS HD
                INNER JOIN CT_HD AS CTHD ON HD.ID_HD = CTHD.ID_HD
                WHERE CTHD.ID_Phong = P.ID_Phong
            )
        ORDER BY 
            P.SoPhong;";

            try
            {
                // Mở kết nối với cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo câu lệnh SQL với tham số
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm các tham số vào câu truy vấn
                        cmd.Parameters.AddWithValue("@NgayBatDau", ngayDen);
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayDi);

                        // Thực thi truy vấn và lấy dữ liệu
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Dọn sạch ListView trước khi thêm dữ liệu mới
                            listView2.Items.Clear();

                            // Đọc từng dòng dữ liệu và thêm vào ListView
                            while (reader.Read())
                            {
                                // Tạo một item mới cho mỗi phòng
                                ListViewItem item = new ListViewItem(reader["ID_Phong"].ToString());
                                item.SubItems.Add(reader["SoPhong"].ToString());
                                item.SubItems.Add(reader["HangPhong"].ToString());

                                // Thêm item vào ListView
                                listView2.Items.Add(item);
                            }
                        }
                    }
                }
                // Sắp xếp các item trong ListView (tùy chọn)
                listView2.ListViewItemSorter = new ListViewItemComparer(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Lấy phần tử đang được chọn trong ListView2
                ListViewItem selectedItem = listView2.SelectedItems[0];

                // Lấy thông tin về phòng từ ListView
                string idPhong = selectedItem.SubItems[0].Text;
                string soPhong = selectedItem.SubItems[1].Text;
                string hangPhong = selectedItem.SubItems[2].Text;

                // Lấy giá phòng từ bảng HangPhong
                decimal giaPhong = GetRoomPriceFromHangPhong(hangPhong); // Hàm lấy giá phòng

                // Tạo một ListViewItem mới để thêm vào listView3
                ListViewItem newItem = new ListViewItem(idPhong);
                newItem.SubItems.Add(soPhong);
                newItem.SubItems.Add(hangPhong);
                newItem.SubItems.Add(giaPhong.ToString()); // Hiển thị giá dưới dạng tiền tệ

                // Thêm phần tử vào ListView3
                listView3.Items.Add(newItem);

                // Tính lại tổng tiền khi thêm phòng
                CalculateTotalRoomPrice();

            }
        }
        private decimal CalculateTotalRoomPrice()
        {
            decimal totalPrice = 0;

            // Tính thời gian thuê dựa trên thời gian từ hai DateTimePicker
            DateTime ngayToi = dateTimePicker1.Value;
            DateTime ngayDi = dateTimePicker2.Value;
            float thoiGianThue = GetRentalTime(ngayToi, ngayDi); // Số ngày hoặc số giờ thuê

            // Duyệt qua tất cả các phần tử trong ListView3
            foreach (ListViewItem item in listView3.Items)
            {
                // Lấy giá phòng từ mỗi phần tử (Giả sử giá phòng nằm trong SubItems[3])
                decimal roomPrice;
                if (decimal.TryParse(item.SubItems[3].Text, out roomPrice)) // Kiểm tra và lấy giá phòng
                {
                    // Tính tiền phòng cho thời gian thuê cụ thể
                    if (thoiGianThue == 0)
                        thoiGianThue = 1;
                    decimal roomTotal = roomPrice * (decimal)thoiGianThue;

                    totalPrice += roomTotal; // Cộng dồn tổng tiền
                }
                int soNgay = (int)thoiGianThue; // Phần nguyên là số ngày
                float gioLe = (thoiGianThue - soNgay) * 24; // Phần thập phân là giờ (24 giờ/ngày)
                int soGio = (int)gioLe;
                int soPhut = (int)((gioLe - soGio) * 60); // Phần thập phân còn lại là phút

                // Hiển thị thời gian ở chi tiết trong textBox1
                textBox1.Text = $"{soNgay}";
            }

            // Hiển thị tổng tiền trong Label (hoặc nơi bạn muốn)
            textBox4.Text = $"{totalPrice.ToString()}";
            return totalPrice;
        }

        // Hàm lấy giá phòng từ bảng HangPhong dựa trên Hạng Phòng
        private decimal GetRoomPriceFromHangPhong(string hangPhong)
        {
            decimal price = 0;

            // Truy vấn giá phòng từ bảng HangPhong dựa trên Hạng Phòng
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string query = "SELECT Gia FROM HangPhong WHERE HangPhong = @HangPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HangPhong", hangPhong);
                    try
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lấy giá phòng: " + ex.Message);
                    }
                }
            }
            return price;
        }
        //Tính thời gian ở 
        private void CalculateRentalTime()
        {
            DateTime ngayToi = dateTimePicker1.Value;
            DateTime ngayDi = dateTimePicker2.Value;
            float thoiGianThue = GetRentalTime(ngayToi, ngayDi);

            // Hiển thị thời gian thuê (ví dụ hiển thị trong một Label)
            //     labelThoiGianThue.Text = $"Thời gian thuê: {thoiGianThue} giờ/ ngày";
        }
        private float GetRentalTime(DateTime ngayToi, DateTime ngayDi)
        {
            float rentalTime = 0;

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                // Lệnh SQL gọi hàm TinhThoiGianThue
                string query = "SELECT dbo.TinhThoiGianThue(@NgayToi, @NgayDi)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayToi", ngayToi);
                    cmd.Parameters.AddWithValue("@NgayDi", ngayDi);

                    try
                    {
                        // Lấy kết quả trả về từ hàm TinhThoiGianThue
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            rentalTime = Convert.ToSingle(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tính thời gian thuê: " + ex.Message);
                    }
                }
            }

            return rentalTime;
        }
        private void FilterCustomerList(string tenKhachHang)
        {
            // Clear previous items in the ListView
            listView1.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                // Truy vấn tìm kiếm khách hàng theo tên
                string query = "SELECT ID_KH, TenKH, GioiTinh, SDT, Email, SoGiayTo, GhiChu, KhaDung FROM KhachHang WHERE TenKH LIKE @TenKH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenKH", "%" + tenKhachHang + "%");

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            // Tạo ListViewItem mới cho mỗi hàng dữ liệu
                            ListViewItem item = new ListViewItem(reader["ID_KH"].ToString());
                            item.SubItems.Add(reader["TenKH"].ToString());
                            item.SubItems.Add((bool)reader["GioiTinh"] ? "Nam" : "Nữ"); // Convert boolean to text
                                                                                        //   item.SubItems.Add(Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy"));
                            item.SubItems.Add(reader["SDT"].ToString());
                            item.SubItems.Add(reader["Email"].ToString());
                            item.SubItems.Add(reader["SoGiayTo"].ToString());
                            item.SubItems.Add(reader["GhiChu"].ToString());
                            item.SubItems.Add(reader["KhaDung"].ToString());

                            // Add the item to the ListView
                            listView1.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lọc danh sách khách hàng: " + ex.Message);
                    }
                }
            }
        }
       

        // Cập nhật trạng thái phòng sau khi tạo hóa đơn
        private void UpdateRoomStatus(SqlConnection conn, SqlTransaction transaction)
        {
            string updateStatusQuery = "UPDATE Phong SET TrangThai = 3 WHERE ID_Phong = @ID_Phong";
            foreach (ListViewItem item in listView3.Items)
            {
                int idPhong = Convert.ToInt32(item.SubItems[0].Text);

                using (SqlCommand cmd = new SqlCommand(updateStatusQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@ID_Phong", idPhong);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public class ListViewItemComparer : IComparer
        {
            private int col;

            public ListViewItemComparer(int column)
            {
                col = column;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                // So sánh theo cột ID_Phong (cột 0)
                return int.Parse(itemX.SubItems[col].Text).CompareTo(int.Parse(itemY.SubItems[col].Text));
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView3.ListViewItemSorter = new ListViewItemComparer(0);
        }

        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                // Lấy phần tử đang được chọn
                ListViewItem selectedItem = listView3.SelectedItems[0];

                // Xóa phần tử khỏi listView3
                listView3.Items.Remove(selectedItem);

                // Tính lại tổng tiền sau khi xóa phòng
                CalculateTotalRoomPrice();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayToi = dateTimePicker1.Value;
            DateTime ngayDi = dateTimePicker2.Value;

            // Lấy thời gian thuê
            float thoiGianThue = GetRentalTime(ngayToi, ngayDi);
            // Chuyển đổi thời gian ở thành định dạng ngày, giờ và phút
            int soNgay = (int)thoiGianThue; // Phần nguyên là số ngày
            // Hiển thị thời gian ở chi tiết trong textBox1
            textBox1.Text = $"{soNgay} ngày";

            // Gọi hàm để tải danh sách phòng trống
            LoadDanhSachPhong(ngayToi, ngayDi);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayToi = dateTimePicker1.Value;
            DateTime ngayDi = dateTimePicker2.Value;

            // Lấy thời gian thuê
            float thoiGianThue = GetRentalTime(ngayToi, ngayDi);
            // Chuyển đổi thời gian ở thành định dạng ngày, giờ và phút
            int soNgay = (int)thoiGianThue; // Phần nguyên là số ngày
            // Hiển thị thời gian ở chi tiết trong textBox1
            textBox1.Text = $"{soNgay} ngày";

            // Gọi hàm để tải danh sách phòng trống
            LoadDanhSachPhong(ngayToi, ngayDi);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateInvoiceWithRooms();
        }
        private void CreateInvoiceWithRooms()
        {
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string soCCCD = txtGiayTo.Text.Trim();  // Get SoCCCD from the text box

                // Step 1: Check if customer exists based on SoCCCD
                string checkCustomerQuery = "SELECT ID_KH FROM KhachHang WHERE SoGiayTo = @SoCCCD";
                int idKhachHang = 0;

                using (SqlCommand checkCmd = new SqlCommand(checkCustomerQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Customer exists, get their ID_KH
                        idKhachHang = Convert.ToInt32(result);
                    }
                    else
                    {
                        // Customer doesn't exist, create a new customer
                        idKhachHang = AddNewCustomer(conn);
                    }
                }

                if (idKhachHang > 0)
                {
                    // Step 2: Begin a transaction to create invoice and add rooms to the invoice
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Step 3: Create the invoice
                            int invoiceId = CreateInvoice(conn, transaction, idKhachHang);

                            // Step 4: Add room details to the invoice
                            AddRoomsToInvoiceDetail(conn, transaction, invoiceId);

                            // Step 5: Commit the transaction after successful creation of invoice and details
                            transaction.Commit();
                            MessageBox.Show("Hóa đơn đã được tạo thành công!");
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if there's an error
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng mới.");
                }
            }
        }

        private int AddNewCustomer(SqlConnection conn)
        {
            string tenKH = txtTenKh.Text;
            bool gioiTinh = rdNam.Checked;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string soGiayTo = txtGiayTo.Text;
            DateTime ngaySinh = DateTime.Parse("10/07/2002"); // Replace with the actual birthdate
            string ghiChu = null;
            int khaDung = 0;

            string insertCustomerQuery = @"INSERT INTO KhachHang (TenKH, GioiTinh, NgaySinh, SDT, Email, SoGiayTo, GhiChu, KhaDung) 
                                VALUES (@TenKH, @GioiTinh, @NgaySinh, @SDT, @Email, @SoGiayTo, @GhiChu, @KhaDung);
                                SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(insertCustomerQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TenKH", tenKH);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@SoGiayTo", soGiayTo);
                cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@KhaDung", khaDung);

                try
                {
                    object newId = cmd.ExecuteScalar();
                    return Convert.ToInt32(newId); // Return the new customer's ID
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng mới: " + ex.Message);
                    return -1; // Return -1 if there's an error
                }
            }
        }

        private int CreateInvoice(SqlConnection conn, SqlTransaction transaction, int idKhachHang)
        {
            int idNhanVien = 3; // Example employee ID who is creating the invoice
            DateTime ngayLap = DateTime.Now;
            DateTime ngayToi = dateTimePicker1.Value;
            DateTime ngayDi = dateTimePicker2.Value;
            float datCoc = float.Parse(txtDatCoc.Text);
            byte hinhThucThanhToan = 0; // Payment method (assumed to be cash)
            float phuThu = float.Parse(textBox3.Text);
            byte trangThai = 0; // Default status (e.g., active)
            decimal tongTien = CalculateTotalRoomPrice(); // Calculate the total price from rooms
            string ghiChu = textBox5.Text;
            byte khaDung = 0;

            // Create the invoice query
            string insertInvoiceQuery = @"INSERT INTO HoaDon (ID_NV, ID_KH, NgayLap, NgayToi, NgayDi, DatCoc, HinhThucThanhToan, PhuThu, TrangThai, TongTien, GhiChu, KhaDung) 
                   VALUES (@ID_NV, @ID_KH, @NgayLap, @NgayToi, @NgayDi, @DatCoc, @HinhThucThanhToan, @PhuThu, @TrangThai, @TongTien, @GhiChu, @KhaDung);
                   SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(insertInvoiceQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@ID_NV", idNhanVien);
                cmd.Parameters.AddWithValue("@ID_KH", idKhachHang);
                cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                cmd.Parameters.AddWithValue("@NgayToi", ngayToi);
                cmd.Parameters.AddWithValue("@NgayDi", ngayDi);
                cmd.Parameters.AddWithValue("@DatCoc", datCoc);
                cmd.Parameters.AddWithValue("@HinhThucThanhToan", hinhThucThanhToan);
                cmd.Parameters.AddWithValue("@PhuThu", phuThu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@KhaDung", khaDung);

                // Execute and get the new invoice ID
                int invoiceId = Convert.ToInt32(cmd.ExecuteScalar());
                return invoiceId;
            }
        }

        private void AddRoomsToInvoiceDetail(SqlConnection conn, SqlTransaction transaction, int invoiceId)
        {
            string insertDetailQuery = @"INSERT INTO CT_HD (ID_HD, ID_Phong, Gia, ThoiGianThue, DonVi, KhaDung) 
                  VALUES (@ID_HD, @ID_Phong, @Gia, @SoNgay, @DonVi, @KhaDung)";
            string dvt = "Ngày"; // Unit of time (e.g., "Ngày" for days)

            foreach (ListViewItem item in listView3.Items) // Assuming rooms are in listViewRooms
            {
                int idPhong = Convert.ToInt32(item.SubItems[0].Text);
                decimal gia = Convert.ToDecimal(item.SubItems[3].Text);
                int thoiGianThue = int.Parse(textBox1.Text); // Assuming txtThoiGianThue holds number of days

                using (SqlCommand cmd = new SqlCommand(insertDetailQuery, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@ID_HD", invoiceId);
                    cmd.Parameters.AddWithValue("@ID_Phong", idPhong);
                    cmd.Parameters.AddWithValue("@Gia", gia);
                    cmd.Parameters.AddWithValue("@SoNgay", thoiGianThue);
                    cmd.Parameters.AddWithValue("@DonVi", dvt);
                    cmd.Parameters.AddWithValue("@KhaDung", 0); // Assuming room status is not available (0)

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
