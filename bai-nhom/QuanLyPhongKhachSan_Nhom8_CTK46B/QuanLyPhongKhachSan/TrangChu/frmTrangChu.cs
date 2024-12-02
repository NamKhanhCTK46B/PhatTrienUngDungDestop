using QuanLyPhongKhachSan.QLNhanVien_DangNhap;
using QuanLyPhongKhachSan.QLPhong;
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

namespace QuanLyPhongKhachSan.TrangChu
{
    public partial class frmTrangChu : Form
    {
        string connetString = TienIch.ChuoiKetNoi;//@"Data Source=LAPTOP-NBIQUV5E;Initial Catalog=QuanLyPhongKhachSan;Integrated Security=True";
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            LoadRoomList();
        }
        private void LoadRoomListByStatus(int roomStatus)
        {
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                string query = @"SELECT Tang.ID_Tang, Tang.Tang, Phong.ID_Phong, Phong.SoPhong, HangPhong.Gia, HangPhong.HangPhong, Phong.TrangThai 
                         FROM Phong 
                         INNER JOIN HangPhong ON Phong.ID_HP = HangPhong.ID_HP
                         INNER JOIN Tang ON Phong.ID_Tang = Tang.ID_Tang
                         WHERE Phong.TrangThai = @roomStatus AND Phong.KhaDung = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomStatus", roomStatus);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable roomTable = new DataTable();
                adapter.Fill(roomTable);

                // Duyệt qua từng phòng và hiển thị lên flowLayoutPanel1
                flowLayoutPanel1.Controls.Clear(); // Xóa các phòng hiện tại
                foreach (DataRow roomRow in roomTable.Rows)
                {
                    string roomNumber = roomRow["SoPhong"].ToString();
                    string roomCategory = roomRow["HangPhong"].ToString();
                    int roomStatusDb = Convert.ToInt32(roomRow["TrangThai"]);
                    int roomId = Convert.ToInt32(roomRow["ID_Phong"]);
                    int roomPrice = Convert.ToInt32(roomRow["Gia"]);

                    Button roomButton = new Button
                    {
                        Text = $"Phòng {roomNumber}\n\n{roomCategory}",
                        Size = new Size(110, 70),
                        Tag = roomId // Lưu ID phòng vào thuộc tính Tag của button để truy cập sau
                    };

                    switch (roomStatus)
                    {
                        case 1:
                            roomButton.BackColor = Color.Orange; // Phòng khả dụng
                            break;
                        case 0:
                            roomButton.BackColor = Color.LightGreen; // Phòng không khả dụng
                            break;
                        case 2:
                            roomButton.BackColor = Color.Gray; // Phòng trạng thái 2
                            break;
                        case 3:
                            roomButton.BackColor = Color.Red; // Phòng trạng thái 3
                            break;
                        case 4:
                            roomButton.BackColor = Color.Aqua; // Phòng trạng thái 4
                            break;
                        default:
                            roomButton.BackColor = Color.LightGray;
                            break;
                    }

                    roomButton.Margin = new Padding(3);
                    roomButton.TextAlign = ContentAlignment.MiddleLeft;
                    flowLayoutPanel1.Controls.Add(roomButton);

                    // Thêm hình ảnh vào nút
                    try
                    {
                      //  roomButton.Image = Image.FromFile("C:\\Users\\LUAN\\Pictures\\BT\\twopeople.png");
                        roomButton.ImageAlign = ContentAlignment.MiddleRight;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                    }
                }

                conn.Close();
            }
        }
        //================================================================
        //Load Danh Sach Phog
        public void LoadRoomList()
        {
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                // Lấy danh sách tầng
                string getFloorsQuery = "SELECT ID_Tang, Tang FROM Tang WHERE KhaDung = 0";
                SqlCommand getFloorsCmd = new SqlCommand(getFloorsQuery, conn);
                SqlDataAdapter floorAdapter = new SqlDataAdapter(getFloorsCmd);
                DataTable floorTable = new DataTable();
                floorAdapter.Fill(floorTable);

                // Duyệt qua từng tầng và tạo GroupBox
                foreach (DataRow floorRow in floorTable.Rows)
                {
                    int floorId = Convert.ToInt32(floorRow["ID_Tang"]);
                    string floorName = floorRow["Tang"].ToString();

                    // Tạo GroupBox cho mỗi tầng
                    GroupBox groupBox = new GroupBox();
                    groupBox.Text = floorName;
                    groupBox.Padding = new Padding(5);
                    groupBox.Margin = new Padding(5);

                    // Create a FlowLayoutPanel for the rooms
                    FlowLayoutPanel roomPanel = new FlowLayoutPanel();
                    roomPanel.Dock = DockStyle.Fill;
                    roomPanel.AutoScroll = true;

                    // Lấy danh sách tất cả các phòng cho tầng hiện tại
                    string getRoomsQuery = @"
                    SELECT p.ID_Phong, p.SoPhong, hp.Gia, hp.HangPhong, p.TrangThai 
                    FROM Phong p, HangPhong hp
                    
                    WHERE p.ID_Tang = @floorId AND p.KhaDung = 0 and p.ID_HP = hp.ID_HP";

                    SqlCommand getRoomsCmd = new SqlCommand(getRoomsQuery, conn);
                    getRoomsCmd.Parameters.AddWithValue("@floorId", floorId);

                    SqlDataAdapter roomAdapter = new SqlDataAdapter(getRoomsCmd);
                    DataTable roomTable = new DataTable();
                    roomAdapter.Fill(roomTable);
                    int maxRoomsPerRow = 6;
                    int totalRooms = roomTable.Rows.Count;
                    int totalRows = (int)Math.Ceiling((double)totalRooms / maxRoomsPerRow);
                    foreach (DataRow roomRow in roomTable.Rows)
                    {
                        string roomNumber = roomRow["SoPhong"].ToString();
                        string roomCategory = roomRow["HangPhong"].ToString();
                        int roomStatus = Convert.ToInt32(roomRow["TrangThai"]);
                        int roomId = Convert.ToInt32(roomRow["ID_Phong"]);
                        int roomPrice = Convert.ToInt32(roomRow["Gia"]);
                        // Tạo đối tượng lưu trữ thông tin phòng
                        var roomInfo = new
                        {
                            RoomId = roomId,
                            RoomStatus = roomStatus
                        };
                        Button roomButton = new Button
                        {
                            Text = $"Phòng {roomNumber}\n\n{roomCategory}",
                            Size = new Size(110, 70),
                            Tag = roomInfo, // Lưu thông tin phòng vào thuộc tính Tag của button
                            ContextMenuStrip = contextMenuStrip1 // Gán ContextMenuStrip cho mỗi Button
                        };
                        switch (roomStatus)
                        {
                            case 1:
                                roomButton.BackColor = Color.Orange; // Phòng khả dụng
                                break;
                            case 0:
                                roomButton.BackColor = Color.LightGreen; // Phòng không khả dụng
                                break;
                            case 2:
                                roomButton.BackColor = Color.Gray; // Phòng trạng thái 2
                                break;
                            case 3:
                                roomButton.BackColor = Color.Red; // Phòng trạng thái 3
                                break;
                            case 4:
                                roomButton.BackColor = Color.Aqua; // Phòng trạng thái 4
                                break;
                            default:
                                roomButton.BackColor = Color.LightGray;
                                break;
                        }

                        roomButton.Margin = new Padding(3);
                        roomButton.TextAlign = ContentAlignment.MiddleLeft;

                        // Thêm sự kiện Click cho mỗi nút phòng
                        roomButton.Click += RoomButton_Click;

                        roomPanel.Controls.Add(roomButton);

                        // Thêm hình ảnh vào nút
                        try
                        {
                           // roomButton.Image = Image.FromFile("C:\\Users\\LUAN\\Pictures\\BT\\twopeople.png");
                            roomButton.ImageAlign = ContentAlignment.MiddleRight;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                        }
                    }
                    // Thiết lập kích thước cho groupBox dựa trên tổng số dòng
                    groupBox.Height = totalRows * 90 + 40;
                    groupBox.Width = 850;
                    // Thêm roomPanel vào groupBox và groupBox vào flowLayoutPanel1
                    groupBox.Controls.Add(roomPanel);
                    flowLayoutPanel1.Controls.Add(groupBox);
                }
                conn.Close();
            }
        }
        public int IDHD;
        public int IDPhong;


        public void RoomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Lấy thông tin phòng từ thuộc tính Tag
                var roomInfo = clickedButton.Tag as dynamic;
                if (roomInfo != null)
                {
                    int roomId = roomInfo.RoomId;

                    // Ngày hiện tại
                    DateTime currentDate = DateTime.Now.Date;

                    using (SqlConnection conn = new SqlConnection(connetString))
                    {
                        conn.Open();

                        // Truy vấn lấy thông tin khách hàng và ID_HD
                        string query = @"
                    SELECT HD.ID_HD, KH.TenKH, P.SoPhong, HD.NgayToi, HD.NgayDi, KH.SDT, KH.SoGiayTo
                    FROM HoaDon HD
                    INNER JOIN CT_HD CTHD ON HD.ID_HD = CTHD.ID_HD
                    INNER JOIN Phong P ON CTHD.ID_Phong = P.ID_Phong
                    INNER JOIN KhachHang KH ON HD.ID_KH = KH.ID_KH
                    WHERE 
                        P.ID_Phong = @ID_Phong
                        AND @CurrentDate BETWEEN CONVERT(date, HD.NgayToi) AND CONVERT(date, HD.NgayDi)
                        AND P.TrangThai IN (1, 4, 3)
                    ORDER BY 
                        P.SoPhong;";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID_Phong", roomId);
                            IDPhong = roomId;
                            //  MessageBox.Show("" + IDPhong);
                            cmd.Parameters.AddWithValue("@CurrentDate", currentDate);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int idHD = Convert.ToInt32(reader["ID_HD"]);
                                    string customerName = reader["TenKH"].ToString();
                                    string ngaytoi = reader["NgayToi"].ToString();
                                    string ngaydi = reader["NgayDi"].ToString();
                                    string sdt = reader["SDT"].ToString();
                                    string giayTo = reader["SoGiayTo"].ToString();

                                    // Hiển thị thông tin khách hàng trong các TextBox
                                    textBox11.Text = giayTo;
                                    txtSoDienThoai.Text = sdt;
                                    txtTenKhach.Text = customerName;
                                    dateTimePicker6.Text = ngaytoi;
                                    dateTimePicker5.Text = ngaydi;

                                    // Sau khi có ID_HD, gọi phương thức để lấy danh sách phòng cùng ID_HD

                                    IDHD = idHD;
                                    LoadRoomsByID_HD(IDHD);
                                    //  MessageBox.Show("" + IDHD);
                                }

                            }
                        }
                    }
                }
            }
        }

        private void LoadRoomsByID_HD(int idHD)
        {
            //   string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=QuanLyPhongKhachSan;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                string query = @"
            SELECT 
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
                    cmd.Parameters.AddWithValue("@ID_HD", idHD);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable roomTable = new DataTable();
                        adapter.Fill(roomTable);
                        HoaDon hd = new HoaDon();

                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = roomTable;

                    }
                }
            }
        }

        private void btnPhongO_Click(object sender, EventArgs e)
        {
            LoadRoomListByStatus(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadRoomList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadRoomListByStatus(4);
        }

        private void btnPhongTrong_Click(object sender, EventArgs e)
        {
            LoadRoomListByStatus(0);
        }

        private void btnPhongDo_Click(object sender, EventArgs e)
        {
            LoadRoomListByStatus(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadRoomListByStatus(3);
        }
        public void KiemTraVaCapNhatTrangThaiPhong()
        {
            List<string> danhSachPhongTrangThai1 = new List<string>();

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();

                // Bắt đầu giao dịch
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Kiểm tra và cập nhật phòng có Ngày Đi bằng ngày hiện tại (chuyển trạng thái phòng sang 4)
                        string queryNgayDi = @"
                    SELECT p.ID_Phong, p.SoPhong, p.TrangThai
                    FROM HoaDon hd
                    JOIN CT_HD cthd ON hd.ID_HD = cthd.ID_HD
                    JOIN Phong p ON cthd.ID_Phong = p.ID_Phong
                    
                    WHERE CONVERT(date, hd.NgayDi) = CONVERT(date, GETDATE())";

                        SqlCommand cmdNgayDi = new SqlCommand(queryNgayDi, conn, transaction);
                        SqlDataReader readerNgayDi = cmdNgayDi.ExecuteReader();

                        List<int> phongCanCapNhatTrangThai4 = new List<int>();

                        while (readerNgayDi.Read())
                        {
                            int idPhong = readerNgayDi.GetInt32(0);
                            string soPhong = readerNgayDi.GetString(1);
                            int trangThai = readerNgayDi.GetByte(2);

                            // Thêm phòng vào danh sách cần cập nhật trạng thái 4
                            if (trangThai == 1)
                                phongCanCapNhatTrangThai4.Add(idPhong);
                        }

                        readerNgayDi.Close();

                        // Cập nhật trạng thái phòng sang 4 (phòng trống sau khi khách trả phòng)
                        if (phongCanCapNhatTrangThai4.Count > 0)
                        {
                            string updateQueryNgayDi = @"
                        UPDATE Phong
                        SET TrangThai = 4
                        WHERE ID_Phong IN (" + string.Join(",", phongCanCapNhatTrangThai4) + ")";

                            SqlCommand updateCmdNgayDi = new SqlCommand(updateQueryNgayDi, conn, transaction);
                            updateCmdNgayDi.ExecuteNonQuery();
                        }

                        // 2. Kiểm tra và cập nhật phòng có Ngày Tới bằng ngày hiện tại (chuyển trạng thái phòng từ 0 sang 3)
                        string queryNgayToi = @"
                    SELECT p.ID_Phong, p.SoPhong, p.TrangThai
                    FROM HoaDon hd
                    JOIN CT_HD cthd ON hd.ID_HD = cthd.ID_HD
                    JOIN Phong p ON cthd.ID_Phong = p.ID_Phong
                    WHERE CONVERT(date, hd.NgayToi) = CONVERT(date, GETDATE())";

                        SqlCommand cmdNgayToi = new SqlCommand(queryNgayToi, conn, transaction);
                        SqlDataReader readerNgayToi = cmdNgayToi.ExecuteReader();

                        List<int> phongCanCapNhatTrangThai3 = new List<int>();

                        while (readerNgayToi.Read())
                        {
                            int idPhong = readerNgayToi.GetInt32(0);
                            string soPhong = readerNgayToi.GetString(1);
                            int trangThai = readerNgayToi.GetByte(2);

                            if (trangThai == 0)
                            {
                                // Thêm phòng vào danh sách cần cập nhật trạng thái 3
                                phongCanCapNhatTrangThai3.Add(idPhong);
                            }
                            else if (trangThai == 1)
                            {
                                // Thêm phòng vào danh sách để thông báo (phòng đang bận)
                                danhSachPhongTrangThai1.Add(soPhong);
                            }
                        }

                        readerNgayToi.Close();

                        // Cập nhật trạng thái phòng từ 0 sang 3 (phòng đã được đặt)
                        if (phongCanCapNhatTrangThai3.Count > 0)
                        {
                            string updateQueryNgayToi = @"
                        UPDATE Phong
                        SET TrangThai = 3
                        WHERE ID_Phong IN (" + string.Join(",", phongCanCapNhatTrangThai3) + ")";

                            SqlCommand updateCmdNgayToi = new SqlCommand(updateQueryNgayToi, conn, transaction);
                            updateCmdNgayToi.ExecuteNonQuery();
                        }

                        // Xác nhận giao dịch
                        transaction.Commit();

                        // Tùy chọn: Thông báo về các phòng có trạng thái 1 (nếu có)
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback giao dịch
                        transaction.Rollback();
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        return;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KiemTraVaCapNhatTrangThaiPhong();
            flowLayoutPanel1.Controls.Clear();
            LoadRoomList();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (IDHD != 0)
            {
                frmHoaDon hdForm = new frmHoaDon(IDHD);
                hdForm.Show();
            }
            else
            {
                MessageBox.Show("Chưa có hóa đơn được chọn.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRoomType = comboBox1.SelectedItem.ToString();

            flowLayoutPanel1.Controls.Clear(); // Xóa các phòng hiện tại

            if (selectedRoomType == "Tất cả")
            {
                LoadRoomList(); // Tải toàn bộ danh sách phòng
            }
            else
            {
                LoadFilteredRoomList(selectedRoomType); // Tải phòng theo loại đã chọn
            }
        }
        private void InitializeRoomTypeComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tất cả"); // Thêm mục "Tất cả"

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string query = "SELECT HangPhong FROM HangPhong WHERE KhaDung = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string roomType = reader.GetString(0);
                        comboBox1.Items.Add(roomType); // Thêm các loại phòng vào ComboBox
                    }
                }
            }

            comboBox1.SelectedIndex = 0; // Mặc định chọn "Tất cả"
        }
        private void LoadFilteredRoomList(string roomType)
        {
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                conn.Open();
                string query = @"SELECT Tang.ID_Tang, Tang.Tang, Phong.ID_Phong, Phong.SoPhong, HangPhong.Gia, HangPhong.HangPhong, Phong.TrangThai 
                         FROM Phong 
                         INNER JOIN HangPhong ON Phong.ID_HP = HangPhong.ID_HP
                         INNER JOIN Tang ON Phong.ID_Tang = Tang.ID_Tang
                         WHERE HangPhong.HangPhong = @roomType AND Phong.KhaDung = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@roomType", roomType);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable roomTable = new DataTable();
                adapter.Fill(roomTable);

                // Duyệt qua từng phòng và hiển thị lên flowLayoutPanel1
                foreach (DataRow roomRow in roomTable.Rows)
                {
                    string roomNumber = roomRow["SoPhong"].ToString();
                    string roomCategory = roomRow["HangPhong"].ToString();
                    int roomStatus = Convert.ToInt32(roomRow["TrangThai"]);
                    int roomId = Convert.ToInt32(roomRow["ID_Phong"]);
                    int roomPrice = Convert.ToInt32(roomRow["Gia"]);

                    Button roomButton = new Button();
                    roomButton.Text = $"Phòng {roomNumber}\n\n{roomCategory}";
                    roomButton.Size = new Size(110, 70);
                    switch (roomStatus)
                    {
                        case 1:
                            roomButton.BackColor = Color.Orange; // Phòng khả dụng
                            break;
                        case 0:
                            roomButton.BackColor = Color.LightGreen; // Phòng không khả dụng
                            break;
                        case 2:
                            roomButton.BackColor = Color.Gray; // Phòng trạng thái 2
                            break;
                        case 3:
                            roomButton.BackColor = Color.Red; // Phòng trạng thái 3
                            break;
                        case 4:
                            roomButton.BackColor = Color.Aqua; // Phòng trạng thái 4
                            break;
                        default:
                            roomButton.BackColor = Color.LightGray;
                            break;
                    }

                    roomButton.Margin = new Padding(3);
                    roomButton.TextAlign = ContentAlignment.MiddleLeft;
                    flowLayoutPanel1.Controls.Add(roomButton);

                    // Thêm hình ảnh vào nút
                    try
                    {
                       // roomButton.Image = Image.FromFile("C:\\Users\\LUAN\\Pictures\\BT\\twopeople.png");
                        roomButton.ImageAlign = ContentAlignment.MiddleRight;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                    }
                }
            }
        }

        private void MenuDonPhong_Click(object sender, EventArgs e)
        {
           

            using (SqlConnection conn = new SqlConnection(connetString))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh SQL để kiểm tra trạng thái phòng trước khi cập nhật
                    string checkRoomStatusQuery = "SELECT TrangThai FROM Phong WHERE ID_Phong = @ID_Phong";

                    using (SqlCommand checkCmd = new SqlCommand(checkRoomStatusQuery, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        checkCmd.Parameters.AddWithValue("@ID_Phong", IDPhong);

                        // Thực thi câu lệnh SQL và lấy trạng thái phòng
                        var roomStatus = checkCmd.ExecuteScalar();

                        if (roomStatus != null && Convert.ToInt32(roomStatus) == 2)
                        {
                            // Nếu trạng thái phòng là 2, cập nhật trạng thái phòng thành 0 (khả dụng)
                            string updateRoomStatusQuery = "UPDATE Phong SET TrangThai = 0 WHERE ID_Phong = @ID_Phong";

                            using (SqlCommand cmd = new SqlCommand(updateRoomStatusQuery, conn))
                            {
                                // Thêm tham số cho câu lệnh SQL
                                cmd.Parameters.AddWithValue("@ID_Phong", IDPhong);

                                // Thực thi câu lệnh SQL để cập nhật trạng thái phòng
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật trạng thái phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy phòng với ID_Phong = " + IDPhong, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // Nếu phòng không ở trạng thái 2, thông báo không thể dọn
                            MessageBox.Show("Phòng không thể dọn vì trạng thái hiện tại không phải là 2.", "Không thể dọn phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                flowLayoutPanel1.Controls.Clear();
                LoadRoomList();
            }
        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong datPhong = new frmDatPhong();
            datPhong.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            using (SqlConnection conn = new SqlConnection(connetString))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh SQL để kiểm tra trạng thái phòng trước khi cập nhật
                    string checkRoomStatusQuery = "SELECT TrangThai FROM Phong WHERE ID_Phong = @ID_Phong";

                    using (SqlCommand checkCmd = new SqlCommand(checkRoomStatusQuery, conn))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        checkCmd.Parameters.AddWithValue("@ID_Phong", IDPhong);

                        // Thực thi câu lệnh SQL và lấy trạng thái phòng
                        var roomStatus = checkCmd.ExecuteScalar();

                        if (roomStatus != null && Convert.ToInt32(roomStatus) == 3)
                        {
                            // Nếu trạng thái phòng là 2, cập nhật trạng thái phòng thành 0 (khả dụng)
                            string updateRoomStatusQuery = "UPDATE Phong SET TrangThai = 1 WHERE ID_Phong = @ID_Phong";

                            using (SqlCommand cmd = new SqlCommand(updateRoomStatusQuery, conn))
                            {
                                // Thêm tham số cho câu lệnh SQL
                                cmd.Parameters.AddWithValue("@ID_Phong", IDPhong);

                                // Thực thi câu lệnh SQL để cập nhật trạng thái phòng
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cập nhật trạng thái phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy phòng với ID_Phong = " + IDPhong, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            // Nếu phòng không ở trạng thái 2, thông báo không thể dọn
                            MessageBox.Show("Phòng không thể dọn vì trạng thái hiện tại không phải là 2.", "Không thể dọn phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật trạng thái phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                flowLayoutPanel1.Controls.Clear();
                LoadRoomList();
            }
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQL_KhachHang khachHang = new frmQL_KhachHang();
            khachHang.ShowDialog();
            this.Close();
        }

        private void quảnLýNhânViên_Click(object sender, EventArgs e)
        {
            frmQL_NhanVien nhanVien = new frmQL_NhanVien();
            nhanVien.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmQL_Phong phong = new frmQL_Phong();
            phong.ShowDialog();
            this.Close();
        }
    }
}
