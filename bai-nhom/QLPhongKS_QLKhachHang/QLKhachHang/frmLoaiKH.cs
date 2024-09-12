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
    public partial class frmLoaiKH : Form
    {
        DSLoaiKH dslkh;
        public frmLoaiKH()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ

        private LoaiKH GetLoaiKH_Control ()
        {
            LoaiKH lkh = new LoaiKH();

            lkh.TenLoai = this.txtTenLKH.Text;
            lkh.GhiChu = this.txtGhiChu_LoaiKH.Text;

            return lkh;
        }

        private LoaiKH GetLoaiKH_LV (ListViewItem lvitem)
        {
            LoaiKH lkh = new LoaiKH();

            lkh.ID_LoaiKH = int.Parse(lvitem.SubItems[0].Text);
            lkh.TenLoai = lvitem.SubItems[1].Text;
            lkh.GhiChu = lvitem.SubItems[2].Text;

            return lkh;
        }

        private void ThietLapTT (LoaiKH lkh)
        {
            this.txtID_LKH.Text = lkh.ID_LoaiKH.ToString();
            this.txtTenLKH.Text = lkh.TenLoai;
            this.txtGhiChu_LoaiKH.Text = lkh.GhiChu;
        }

        private void ThemLKH_LV(LoaiKH lkh)
        {
            ListViewItem lvitem = new ListViewItem(lkh.ID_LoaiKH.ToString());
            lvitem.SubItems.Add(lkh.TenLoai);
            lvitem.SubItems.Add(lkh.GhiChu);

            this.lvLoaiKH.Items.Add(lvitem);
        }

        private void LoadListView ()
        {
            this.lvLoaiKH.Items.Clear();
            foreach (LoaiKH lkh in dslkh.dsLoaiKH)
            {
                ThemLKH_LV(lkh);
            }
        }

        private int SoSanhTheoID(object obj1, object obj2)
        {
            LoaiKH lkh = obj2 as LoaiKH;
            return lkh.ID_LoaiKH.ToString().CompareTo(obj1);
        }

        #endregion

        private void frmLoaiKH_Load(object sender, EventArgs e)
        {
            dslkh = new DSLoaiKH();
            dslkh.DocFile_Json("Data\\LoaiKH.json");
            LoadListView();
        }

        private void lvLoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvLoaiKH.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvLoaiKH.SelectedItems[0];
                LoaiKH lkh = GetLoaiKH_LV(lvitem);
                ThietLapTT(lkh);
            }
        }

        private void btnMacDinh_LoaiKH_Click(object sender, EventArgs e)
        {
            this.txtID_LKH.Text = "";
            this.txtTenLKH.Text = "";
            this.txtGhiChu_LoaiKH.Text = "";
        }

        private void btnThem_LoaiKH_Click(object sender, EventArgs e)
        {
            LoaiKH lkh = GetLoaiKH_Control();

            this.dslkh.ThemLoaiKH(lkh);
            this.LoadListView();
        }

        private void btnXoa_LoaiKH_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvLoaiKH.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvLoaiKH.Items[i];
                if (lvitem.Checked)
                    dslkh.XoaLoaiKH(lvitem.SubItems[0].Text, SoSanhTheoID);
            }
            this.LoadListView();
            this.btnMacDinh_LoaiKH.PerformClick();
        }

        private void btnSua_LoaiKH_Click(object sender, EventArgs e)
        {
            LoaiKH lkh = GetLoaiKH_Control();
            bool kq;
            kq = dslkh.Sua_LoaiKH(lkh, lkh.ID_LoaiKH.ToString(), SoSanhTheoID);
            if (kq == true)
            {
                this.LoadListView();
            }
        }
    }
}
