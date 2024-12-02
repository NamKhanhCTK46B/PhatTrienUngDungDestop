using QuanLyPhongKhachSan.QLPhong;
using QuanLyPhongKhachSan.TrangChu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruyCapDuLieu.LopAnhXa;
using XuLy;

namespace QuanLyPhongKhachSan.QLNhanVien_DangNhap
{
    public partial class frmQL_NhanVien : Form
    {
        // Danh sách các biến toàn cục bảng NhanVien
        List<NhanVien> dsNhanVien = new List<NhanVien>();
        List<ViTriLV> dsViTriLV = new List<ViTriLV>();
        // Đối tượng NhanVien đang chọn hiện hành
        NhanVien nvHienTai = new NhanVien();

        public frmQL_NhanVien()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ

        public void TaiDSNhanVienLenListView()
        {
            //Gọi các đối tượng  NhanVienBL và ViTriLVBL từ tầng XuLy
            NhanVienBL nvBL = new NhanVienBL();
            ViTriLVBL vtBL = new ViTriLVBL();

            dsNhanVien = nvBL.LayDSNhanVien();
            dsViTriLV = vtBL.LayDSViTriLV();

            lsvQLNV.Items.Clear();

            cbbVTLV.DataSource = dsViTriLV;
            cbbVTLV.ValueMember = "ID_VT";
            cbbVTLV.DisplayMember = "TenVT";

            int stt = 1;

            foreach (NhanVien nv in dsNhanVien)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                var vtlv = dsViTriLV.FirstOrDefault(p => p.ID_VT == nv.ID_VT);
                string mk = nvBL.MaHoaMatKhau(nv.MatKhau.ToString());

                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.SoCCCD);
                item.SubItems.Add(nv.GioiTinh == 0 ? "Nữ" : "Nam");
                item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.NgayVaoLam.ToString("dd/MM/yyyy"));
                item.SubItems.Add(nv.SDT);
                item.SubItems.Add(nv.Email);
                item.SubItems.Add(vtlv?.TenVT ?? "Không xác định");
                item.SubItems.Add(nv.TenDN);
                item.SubItems.Add(mk);
                item.SubItems.Add(nv.GhiChu);
                item.SubItems.Add(nv.KhaDung == 0 ? "Hoạt động" : "Không hoạt động");

                this.lsvQLNV.Items.Add(item);
                stt++;
            }
        }

        public int ThemNhanVien()
        {
            NhanVienBL nvBL = new NhanVienBL();
            NhanVien nv = new NhanVien();
            nv.ID_NV = 0;

            if (txtTenNV.Text == "" || txtCCCD.Text == "" || cbbGioiTinh.SelectedIndex == -1
                || txtSDT.Text == "" || txtEmail.Text == "" || cbbVTLV.SelectedIndex == -1
                || txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô. Vui lòng nhập lại!");
            else
            {
                nv.TenNV = txtTenNV.Text;
                nv.SoCCCD = txtCCCD.Text;
                nv.NgaySinh = dtpNgaySinh.Value;
                nv.NgayVaoLam = dtpNgayVaoLam.Value;
                nv.GioiTinh = cbbGioiTinh.SelectedIndex;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                nv.TenDN = txtTenDangNhap.Text;
                nv.MatKhau = nvBL.MaHoaMatKhau(txtMatKhau.Text);
                nv.GhiChu = txtGhiChu.Text;
                nv.ID_VT = int.Parse(cbbVTLV.SelectedValue.ToString());

                if (!nvBL.KiemTraDinhDang_SDT(nv.SDT))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                if (!nvBL.KiemTraDinhDang_Email(nv.Email))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }


                return nvBL.Them(nv);
            }

            return -1;
        }

        public int CapNhatNhanVien()
        {
            NhanVienBL nvBL = new NhanVienBL();
            NhanVien nv = new NhanVien();
            nv.ID_NV = nvHienTai.ID_NV;

            if (txtTenNV.Text == "" || txtCCCD.Text == "" || cbbGioiTinh.SelectedIndex == -1
                || txtSDT.Text == "" || txtEmail.Text == "" || cbbVTLV.SelectedIndex == -1
                || txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô. Vui lòng nhập lại!");
            else
            {
                nv.TenNV = txtTenNV.Text;
                nv.SoCCCD = txtCCCD.Text;
                nv.NgaySinh = dtpNgaySinh.Value;
                nv.NgayVaoLam = dtpNgayVaoLam.Value;
                nv.GioiTinh = cbbGioiTinh.SelectedIndex;
                nv.SDT = txtSDT.Text;
                nv.Email = txtEmail.Text;
                nv.TenDN = txtTenDangNhap.Text;
                nv.MatKhau = nvBL.MaHoaMatKhau(txtMatKhau.Text);

                if (!nvBL.KiemTraDinhDang_SDT(nv.SDT))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                if (!nvBL.KiemTraDinhDang_Email(nv.Email))
                {
                    MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }

                return nvBL.Sua(nv);
            }

            return -1;
        }

        #endregion

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVienBL nvBL = new NhanVienBL();
            if (nvBL.KiemTraTrungNhanVien(txtCCCD.Text, txtTenDangNhap.Text, txtEmail.Text))
            {
                MessageBox.Show("Thông tin nhân viên bị trùng lặp! Vui lòng kiểm tra CCCD, Username hoặc Email.",
                                "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int kq = ThemNhanVien();
            if (kq > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tải lại dữ liệu cho ListView
                TaiDSNhanVienLenListView();
            }
            else
                MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu đã nhập!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            int kq = CapNhatNhanVien();

            if (kq > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");

                TaiDSNhanVienLenListView();
            }
            else
                MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string TenDNHienTai = TTNguoiDung.TenDN;

            if (lsvQLNV.SelectedItems.Count > 0)
            {
                string tenDN = lsvQLNV.SelectedItems[0].SubItems[9].Text;

                if (TenDNHienTai == tenDN)
                {
                    frmDoiMatKhau doiMatKhau = new frmDoiMatKhau();
                    doiMatKhau.Show();
                }
                else
                {
                    MessageBox.Show("Bạn không thể thay đổi mật khẩu của tài khoản khác!");
                    btnDoiMatKhau.Enabled = false;
                }
            }
        }
        private void tsmiQLKH_Click(object sender, EventArgs e)
        {
            frmQL_KhachHang qlKhachHang = new frmQL_KhachHang();
            qlKhachHang.ShowDialog();
            this.Close();
        }

        private void lsvQLNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvQLNV.Items.Count; i++)
            {
                if (lsvQLNV.Items[i].Selected)
                {
                    nvHienTai = dsNhanVien[i];

                    txtTenNV.Text = nvHienTai.TenNV;
                    txtCCCD.Text = nvHienTai.SoCCCD;
                    dtpNgaySinh.Value = nvHienTai.NgaySinh;
                    dtpNgayVaoLam.Value = nvHienTai.NgayVaoLam;
                    txtSDT.Text = nvHienTai.SDT;
                    txtEmail.Text = nvHienTai.Email;
                    txtTenDangNhap.Text = nvHienTai.TenDN;
                    txtMatKhau.Text = nvHienTai.MatKhau;
                    txtGhiChu.Text = nvHienTai.GhiChu;

                    cbbGioiTinh.SelectedIndex = nvHienTai.GioiTinh == 0 ? 0 : 1;

                    cbbVTLV.SelectedValue = nvHienTai.ID_VT;
                }    
            }
            if (lsvQLNV.SelectedItems.Count > 0) 
            {
                string selectedUsername = lsvQLNV.SelectedItems[0].SubItems[9].Text; // SubItems[9] là Username

                if (selectedUsername == TTNguoiDung.TenDN)
                {
                    btnDoiMatKhau.Enabled = true; // Cho phép đổi mật khẩu nếu là tài khoản đang đăng nhập
                }
                else
                {
                    btnDoiMatKhau.Enabled = false; // Không cho phép nếu không phải tài khoản của người dùng hiện tại
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtGhiChu.Text = "";

            cbbGioiTinh.SelectedIndex = -1;
            cbbVTLV.SelectedIndex = -1;

            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayVaoLam.Value = DateTime.Now;
        }

        private void tsmiTrangChu_Click(object sender, EventArgs e)
        {
            frmTrangChu trangChu = new frmTrangChu();
            trangChu.ShowDialog();
            this.Close();
        }

        private void frmQL_NhanVien_Load(object sender, EventArgs e)
        {
            TaiDSNhanVienLenListView();
        }

        private void btnKhoaTK_Click(object sender, EventArgs e)
        {
            NhanVienBL nvBL = new NhanVienBL();
            nvBL.Xoa(nvHienTai);
            TaiDSNhanVienLenListView();
        }

        private void tsmiQLPhong_Click(object sender, EventArgs e)
        {
            frmQL_Phong phong = new frmQL_Phong();
            phong.ShowDialog();
            this.Close();
        }
    }
}
