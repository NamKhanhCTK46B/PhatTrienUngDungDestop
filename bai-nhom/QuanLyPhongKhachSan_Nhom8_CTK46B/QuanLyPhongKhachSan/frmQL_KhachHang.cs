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

namespace QuanLyPhongKhachSan
{
    public partial class frmQL_KhachHang : Form
    {
        public frmQL_KhachHang()
        {
            InitializeComponent();
        }

        List<KhachHang> dskh = new List<KhachHang>();
        KhachHang khHienTai = new KhachHang();

        #region Phương thức bổ trợ

        private void LayDSKH()
        {
            KhachHangBL khBL = new KhachHangBL();

            dskh = khBL.LayDSKH();
        }

        private void TaiDSKHLenListView(List<KhachHang> ds)
        {
            lvKhachHang.Items.Clear();

            foreach (var kh in ds)
            {
                ListViewItem k = lvKhachHang.Items.Add(kh.ID_KH.ToString());

                k.SubItems.Add(kh.TenKH);
                string gt = "Nữ";
                if (kh.GioiTinh == true)
                    gt = "Nam";
                k.SubItems.Add(gt);
                k.SubItems.Add(kh.SDT);
                k.SubItems.Add(kh.NgaySinh.ToString("dd/MM/yyyy"));
                k.SubItems.Add(kh.Email);
                k.SubItems.Add(kh.SoGiayTo);
                k.SubItems.Add(kh.GhiChu);
            }
        }

        public int ThemKH()
        {
            KhachHang kh = new KhachHang();

            if (txtID_KhachHang.Text != "")
            {
                MessageBox.Show("Đã tồn tại khách hàng có mã số " + txtID_KhachHang.Text + " trong hệ thống", "Thông báo");
                return -1;
            }


            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên của khách hàng", "Thông báo");
                return -1;
            }

            if (dtpNgaySinh.Value.Year > DateTime.Now.Year - 16)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh của khách hàng", "Thông báo");
                return -1;
            }

            if (mtxtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng", "Thông báo");
                return -1;
            }

            if (txtSoGiayTo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số giấy tờ của khách hàng", "Thông báo");
                return -1;
            }

            else
            {
                kh.TenKH = txtTenKH.Text;
                bool gt = false;
                if (rdNam.Checked)
                    gt = true;
                kh.GioiTinh = gt;
                kh.NgaySinh = dtpNgaySinh.Value;
                kh.SDT = mtxtSDT.Text.Replace("-", "");
                kh.Email = txtEmail.Text;
                kh.SoGiayTo = txtSoGiayTo.Text;
                kh.GhiChu = txtGhiChu.Text;

                KhachHangBL khXL = new KhachHangBL();
                return khXL.ThemKH(kh);
            }
        }

        public int CapNhatKH()
        {
            KhachHang kh = new KhachHang();

            if (txtID_KhachHang.Text == "")
            {
                MessageBox.Show("Không tồn tại khách hàng trong hệ thống", "Thông báo");
                return -1;
            }


            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên của khách hàng", "Thông báo");
                return -1;
            }

            if (dtpNgaySinh.Value.Year > DateTime.Now.Year - 16)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh của khách hàng", "Thông báo");
                return -1;
            }

            if (mtxtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của khách hàng", "Thông báo");
                return -1;
            }

            if (txtSoGiayTo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số giấy tờ của khách hàng", "Thông báo");
                return -1;
            }

            else
            {
                kh.ID_KH = int.Parse(txtID_KhachHang.Text);
                kh.TenKH = txtTenKH.Text;
                bool gt = false;
                if (rdNam.Checked)
                    gt = true;
                kh.GioiTinh = gt;
                kh.NgaySinh = dtpNgaySinh.Value;
                kh.SDT = mtxtSDT.Text.Replace("-", "");
                kh.Email = txtEmail.Text;
                kh.SoGiayTo = txtSoGiayTo.Text;
                kh.GhiChu = txtGhiChu.Text;

                KhachHangBL khXL = new KhachHangBL();
                return khXL.SuaKH(kh);
            }
        }

        private List<HoaDon> LayDSHD_KH(int idkh)
        {
            HoaDonBL hdXL = new HoaDonBL();
            return hdXL.LayDSHDCuaKH(idkh);
        }

        #endregion

        #region Xử lý sự kiên
        private void frmKhachHang_Load(object sender, EventArgs e)
        {

            dgvHoaDon.AutoGenerateColumns = false;
            LayDSKH();
            TaiDSKHLenListView(dskh);
        }

        private void lvKhachHang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvKhachHang.Items?.Count; i++)
            {
                if (lvKhachHang.Items[i].Selected)
                {
                    khHienTai = dskh[i];
                    txtID_KhachHang.Text = khHienTai.ID_KH.ToString();
                    txtTenKH.Text = khHienTai.TenKH;
                    txtSoGiayTo.Text = khHienTai.SoGiayTo;
                    dtpNgaySinh.Value = khHienTai.NgaySinh;
                    if (khHienTai.GioiTinh == true)
                        rdNam.Checked = true;
                    else
                        rdNu.Checked = true;
                    mtxtSDT.Text = khHienTai.SDT;
                    txtEmail.Text = khHienTai.Email;
                    txtGhiChu.Text = khHienTai.GhiChu;

                    dgvHoaDon.DataSource = LayDSHD_KH(khHienTai.ID_KH);

                    break;
                }
            }
        }

        private void btnThem_KH_Click(object sender, EventArgs e)
        {
            int kq = ThemKH();
            if (kq > 0)
            {
                MessageBox.Show("Thêm khách hàng thành công");

                LayDSKH();
                TaiDSKHLenListView(dskh);

                btnMacDinh.PerformClick();
            }
            else
                return;
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtID_KhachHang.Text = "";
            txtTenKH.Text = "";
            txtSoGiayTo.Text = "";
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            mtxtSDT.Text = "";
            txtEmail.Text = "";
            txtGhiChu.Text = "";

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.Refresh();
        }

        private void btnCapNhat_KH_Click(object sender, EventArgs e)
        {
            int kq = CapNhatKH();
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công");

                LayDSKH();
                TaiDSKHLenListView(dskh);

                btnMacDinh.PerformClick();
            }
            else
                return;

        }

        private void btnLamMoiDSHD_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = LayDSHD_KH(khHienTai.ID_KH);
        }

        private void tsmiTaiLaiDSKH_Click(object sender, EventArgs e)
        {
            TaiDSKHLenListView(dskh);

            txtTK_TenKH.Text = "";
            txtTK_SoGiayTo.Text = "";
            mtxtSDT.Text = "";
        }

        private void txtTK_TenKH_TextChanged(object sender, EventArgs e)
        {
            string ten = txtTK_TenKH.Text;

            KhachHangBL khXL = new KhachHangBL();
            List<KhachHang> kq = khXL.TimKiem(ten);

            TaiDSKHLenListView(kq);
        }

        private void txtTK_SoGiayTo_TextChanged(object sender, EventArgs e)
        {
            string sgt = txtTK_SoGiayTo.Text;

            KhachHangBL khXL = new KhachHangBL();
            List<KhachHang> kq = khXL.TimKiem(sgt);

            TaiDSKHLenListView(kq);
        }

        private void txtTK_SDT_TextChanged(object sender, EventArgs e)
        {
            string sgt = txtTK_SDT.Text;

            KhachHangBL khXL = new KhachHangBL();
            List<KhachHang> kq = khXL.TimKiem(sgt);

            TaiDSKHLenListView(kq);
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            HoaDonBL hdXL = new HoaDonBL();
            List<HoaDon> kq = hdXL.LayDSHDCuaKH_Ngay(int.Parse(txtID_KhachHang.Text), dtpNgayBD.Value, dtpNgayKT.Value);

            dgvHoaDon.DataSource = kq;
        }

        private void tsmiXoaKH_Click(object sender, EventArgs e)
        {
            KhachHangBL khachHangXL = new KhachHangBL();
            int count, i;
            ListViewItem kh;
            count = lvKhachHang.Items.Count - 1;

            for (i = count; i >= 0; i--)
            {
                kh = this.lvKhachHang.Items[i];
                if (kh.Checked)
                {
                    KhachHang khXoa = dskh[i];

                    khachHangXL.XoaKH(khXoa);
                    dskh.Remove(khXoa);

                    MessageBox.Show("Xoá khách hàng thành công", "Thông báo");
                }
            }
            TaiDSKHLenListView(dskh);
        }

        private void tsmiTrangChu_Click(object sender, EventArgs e)
        {
            frmTrangChu trangChu = new frmTrangChu();
            trangChu.ShowDialog();
            this.Close();
        }
        #endregion

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQL_Phong phong = new frmQL_Phong();
            phong.Show();
            this.Close();
        }
    }
}
