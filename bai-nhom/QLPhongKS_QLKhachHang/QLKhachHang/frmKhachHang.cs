using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKhachHang
{
    public partial class frmKhachHang : Form
    {
        DSKhachHang dskh;
        DSLoaiKH lkh;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ

        private void ThemKH_LV (KhachHang kh)
        {
            ListViewItem lvitem = new ListViewItem(kh.ID_KH.ToString());
            lvitem.SubItems.Add(kh.TenKH);

            string gt = "Nữ";
            if (kh.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);

            lvitem.SubItems.Add(kh.SDT);
            lvitem.SubItems.Add(kh.NgaySinh.ToString("dd/MM/yyyy"));
            lvitem.SubItems.Add(kh.Email);
            lvitem.SubItems.Add(kh.SoCCCD);
            lvitem.SubItems.Add(kh.LoaiKH.TenLoai);
            lvitem.SubItems.Add(kh.GhiChu);

            this.lvKhachHang.Items.Add(lvitem);
        }

        private void LoadLV_KH(DSKhachHang ds)
        {
            this.lvKhachHang.Items.Clear();
            foreach (KhachHang kh in ds.dsKhachHang)
            {
                ThemKH_LV(kh);
            }
        }

        #endregion

        private void tsmiQuanLyLKH_Click(object sender, EventArgs e)
        {
            frmLoaiKH form = new frmLoaiKH();
            form.ShowDialog();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dskh = new DSKhachHang ();
            //dskh.DocFile_XML("DaTa\\DanhSachKH.xml");
            dskh.DocFile_Json("Data\\DSKhachHang.json");
            LoadLV_KH (dskh);
        }
    }
}
