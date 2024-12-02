using QuanLyPhongKhachSan.QLNhanVien_DangNhap;
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

namespace QuanLyPhongKhachSan.QLPhong
{
    public partial class frmQL_Phong : Form
    {
        public frmQL_Phong()
        {
            InitializeComponent();
        }
        List<Phong> dsPhong = new List<Phong>();
        List<Tang> dsTang = new List<Tang>();
        List<HangPhong> dsHangPhong = new List<HangPhong>();
        Phong phongHT = new Phong();

        #region Phương thức bổ trợ

        private void TaiTangLenCombobox()
        {
            TangBL tBL = new TangBL();

            dsTang = tBL.LayDSTang();

            cbbTang.DataSource = dsTang;
            cbbTang.DisplayMember = "TenTang";
            cbbTang.ValueMember = "ID_Tang";
        }

        private void TaiHangPhongLenCombobox()
        {
            HangPhongBL hpBL = new HangPhongBL();

            dsHangPhong = hpBL.LayDSHangPhong();

            cbbHangPhong.DataSource = dsHangPhong;
            cbbHangPhong.DisplayMember = "TenHP";
            cbbHangPhong.ValueMember = "ID_HP";
        }

        private void LayDSPhong()
        {
            PhongBL pBL = new PhongBL();

            dsPhong = pBL.LayDSPhong();
        }

        private void TaiDSPhongLenLV(List<Phong> ds)
        {
            lvPhong.Items.Clear();

            foreach (Phong p in ds)
            {
                ListViewItem ph = lvPhong.Items.Add(p.ID_Phong.ToString());

                ph.SubItems.Add(p.SoPhong);

                var hangPhong = dsHangPhong.Find(x => x.ID_HP == p.ID_HP);
                string hp = hangPhong != null ? hangPhong.TenHP : "Không tìm thấy";

                var tang = dsTang.Find(x => x.ID_Tang == p.ID_Tang);
                string t = tang != null ? tang.TenTang : "Không tìm thấy";

                ph.SubItems.Add(hp);
                ph.SubItems.Add(t);
                ph.SubItems.Add(p.MoTa);
                ph.SubItems.Add(p.GhiChu);

                string trangThai = "";
                switch (p.TrangThai)
                {
                    case 0:
                        trangThai = "Phòng trống";
                        break;
                    case 1:
                        trangThai = "Phòng ở";
                        break;
                    case 2:
                        trangThai = "Phòng đơ";
                        break;
                    case 3:
                        trangThai = "Phòng đặt";
                        break;
                }
                ph.SubItems.Add(trangThai);
            }
        }

        private bool KiemTraNhap()
        {
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số phòng", "Thông báo");
                return false;
            }
            if (cbbHangPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn hạng phòng", "Thông báo");
                return false;
            }

            if (cbbTang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn tầng", "Thông báo");
                return false;
            }

            return true;
        }

        public int ThemPhong()
        {
            if (txtIDPhong.Text != "")
            {
                MessageBox.Show("Đã tồn tại khách có mã số " + txtIDPhong.Text + " trong hệ thống", "Thông báo");
                return -1;
            }

            if (KiemTraNhap())
            {
                Phong ph = new Phong();

                ph.SoPhong = txtSoPhong.Text;
                ph.MoTa = txtMoTa.Text;
                ph.GhiChu = txtGhiChu.Text;
                ph.ID_HP = Convert.ToInt32(cbbHangPhong.SelectedValue);
                ph.ID_Tang = Convert.ToInt32(cbbTang.SelectedValue);

                PhongBL pBL = new PhongBL();
                return pBL.Them(ph);
            }
            else
                return -1;
        }

        public int CapNhatPhong()
        {
            if (txtIDPhong.Text == "")
            {
                MessageBox.Show("Không tồn tại phòng trong hệ thống", "Thông báo");
                return -1;
            }

            if (KiemTraNhap())
            {
                Phong ph = new Phong();

                ph.ID_Phong = int.Parse(txtIDPhong.Text);
                ph.SoPhong = txtSoPhong.Text;
                ph.MoTa = txtMoTa.Text;
                ph.GhiChu = txtGhiChu.Text;
                ph.ID_HP = Convert.ToInt32(cbbHangPhong.SelectedValue);
                ph.ID_Tang = Convert.ToInt32(cbbTang.SelectedValue);

                PhongBL pBL = new PhongBL();
                return pBL.Sua(ph);
            }
            else
                return -1;
        }

        #endregion

        private void frmQL_Phong_Load(object sender, EventArgs e)
        {
            LayDSPhong();
            TaiHangPhongLenCombobox();
            TaiTangLenCombobox();
            TaiDSPhongLenLV(dsPhong);
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvPhong.Items.Count; i++)
            {
                if (lvPhong.Items[i].Selected)
                {
                    phongHT = dsPhong[i];

                    txtIDPhong.Text = phongHT.ID_Phong.ToString();
                    txtSoPhong.Text = phongHT.SoPhong;

                    if (phongHT.ID_HP == 0)
                        cbbHangPhong.SelectedIndex = -1;
                    else
                        cbbHangPhong.SelectedIndex = dsHangPhong.FindIndex(x => x.ID_HP == phongHT.ID_HP);

                    if (phongHT.ID_Tang == 0)
                        cbbHangPhong.SelectedIndex = -1;
                    else
                        cbbTang.SelectedIndex = dsTang.FindIndex(x => x.ID_Tang == phongHT.ID_Tang);
                    txtMoTa.Text = phongHT.MoTa;
                    txtGhiChu.Text = phongHT.GhiChu;
                }
            }

            HoaDonBL hdBL = new HoaDonBL();
            List<HoaDon> dsHD = hdBL.LayHDCuaPhong(phongHT.ID_HP);
            dgvHoaDon.DataSource = dsHD;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            int kq = ThemPhong();

            if (kq > 0)
            {
                MessageBox.Show("Thêm phòng thành công", "Thông báo");

                LayDSPhong();
                TaiDSPhongLenLV(dsPhong);
            }
            else
                return;

            btnNhapLai.PerformClick();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtIDPhong.Text = "";
            txtSoPhong.Text = "";
            txtMoTa.Text = "";
            cbbHangPhong.SelectedIndex = -1;
            cbbTang.SelectedIndex = -1;
            txtGhiChu.Text = "";

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.Refresh();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int kq = CapNhatPhong();
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật phòng thành công", "Thông báo");

                LayDSPhong();
                TaiDSPhongLenLV(dsPhong);
            }
            else
                return;

            btnNhapLai.PerformClick();
        }

        private void btnThemTang_Click(object sender, EventArgs e)
        {
            frmQL_Tang qlTang = new frmQL_Tang();
            qlTang.ShowDialog();
        }

        private void tsmiTaiLaiDSPhong_Click(object sender, EventArgs e)
        {
            TaiDSPhongLenLV(dsPhong);
        }

        private void tsmiXoaPhong_Click(object sender, EventArgs e)
        {
            PhongBL phongBL = new PhongBL();
            int count, i;
            ListViewItem p;
            count = lvPhong.Items.Count - 1;

            for ( i = count; i >= 0; i--) 
            {
                p = lvPhong.Items[i];
                if (p.Checked)
                {
                    Phong pXoa = dsPhong[i];

                    phongBL.Xoa(pXoa);
                    dsPhong.Remove(pXoa);

                    MessageBox.Show("Xoá phòng thành công", "Thông báo");
                }

                TaiDSPhongLenLV(dsPhong);
            }
        }

        private void txtTK_Tang_TextChanged(object sender, EventArgs e)
        {
            string sp = txtSoPhongTK.Text;

            PhongBL phongBL = new PhongBL();
            List<Phong> kq = phongBL.TimKiem(sp);
            
            TaiDSPhongLenLV(kq);
        }

        private void cbbTK_Tang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string tang = cbbTK_Tang.SelectedValue.ToString();

            //PhongBL phongBL = new PhongBL();
            //List<Phong> kq = phongBL.TimKiem(tang);

            //TaiDSPhongLenLV(kq);
        }

        private void cbbTK_HangPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string hp = cbbTK_HangPhong.SelectedValue.ToString();

            //PhongBL phongBL = new PhongBL();
            //List<Phong> kq = phongBL.TimKiem(hp);

            //TaiDSPhongLenLV(kq);
        }

        private void btnThemHP_Click(object sender, EventArgs e)
        {

        }

        private void lvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQL_NhanVien nhanVien = new frmQL_NhanVien();
            nhanVien.ShowDialog();
            this.Close();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQL_KhachHang khachHang = new frmQL_KhachHang();
            khachHang.ShowDialog();
            this.Close();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangChu trangChu = new frmTrangChu();
            trangChu.ShowDialog();
            this.Close();
        }
    }
}
