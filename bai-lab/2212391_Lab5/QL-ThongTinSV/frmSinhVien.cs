using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThongTinSV
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        #region

        private SinhVien LayTTSV_Controls()
        {
            SinhVien sv = new SinhVien();
            bool gt = false;
            List<string> mon = new List<string>();

            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoTenLot= this.txtHoTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cboLop.Text;
            sv.SoCMND = this.mtxtCMND.Text;
            sv.SDT = this.mtxtMSSV.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            if (rbNam.Checked)
                gt = true;
            sv.GioiTinh = gt;

            for (int i = 0; i < this.clbMonDK.Items.Count; i++)
                if (clbMonDK.GetItemChecked(i))
                    mon.Add(clbMonDK.Items[i].ToString());
            sv.MonHocDK = mon;

            return sv;
        }

        private SinhVien LayTTSV_LV (ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            List<string> mon = new List<string>();

            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoCMND = lvitem.SubItems[5].Text;
            sv.SDT = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[8].Text == "Nam")
                sv.GioiTinh = true;

            string[] mondk = lvitem.SubItems[9].Text.Split(',');
            foreach (string m in mondk)
            {
                mon.Add(m);
            }
            sv.MonHocDK = mon;

            return sv;
        }

        #endregion

        private void frmSinhVien_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
