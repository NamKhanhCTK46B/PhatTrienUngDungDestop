using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_ThongTinSV
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        #region Phương thức bổ trợ
        QLSinhVien dssv;
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
            if (rdNam.Checked)
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
            sv.NgaySinh = DateTime.ParseExact(lvitem.SubItems[3].Text, "dd/MM/yyyy",CultureInfo.InvariantCulture);
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

        private void ThietLapTT_Control(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoTenLot.Text = sv.HoTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cboLop.Text = sv.Lop;
            this.mtxtCMND.Text = sv.SoCMND;
            this.mtxtSDT.Text = sv.SDT;
            this.txtDiaChi.Text = sv.DiaChi;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < clbMonDK.Items.Count; i++)
                this.clbMonDK.SetItemChecked(i, false);
            foreach (string mon in sv.MonHocDK)
            {
                for (int i = 0; i <= this.clbMonDK.Items.Count - 1; i++)
                    if (mon.CompareTo(this.clbMonDK.Items[i]) == 0)
                        this.clbMonDK.SetItemChecked(i, true);
            }
        }

        private void ThemSV_LV (SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            string gt = "Nữ", mdk = "";

            lvitem.SubItems.Add(sv.HoTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoCMND);
            lvitem.SubItems.Add(sv.SDT);
            lvitem.SubItems.Add(sv.DiaChi);
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            foreach (string mon in sv.MonHocDK)
            {
                mdk += mon + ",";
            }
            lvitem.SubItems.Add(mdk);

            this.lvSinhVien.Items.Add(lvitem);
        }

        private void TaiListView (QLSinhVien ds)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in ds.DSSV)
            {
                ThemSV_LV(sv);
            }
        }

        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        #endregion

        #region Các sự kiện

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            dssv = new QLSinhVien();
            //dssv.DocFile_TXT("du-lieu\\DSSinhVien.txt");
            //dssv.DocFile_Json("du-lieu\\DSSinhVien.json");
            dssv.DocFile_XML("du-lieu\\DSSinhVien.xml");
            TaiListView(dssv);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(mtxtMSSV.Text) ||
                string.IsNullOrEmpty(txtHoTenLot.Text) ||
                string.IsNullOrEmpty(txtTen.Text) ||
                string.IsNullOrEmpty(cboLop.Text) ||
                dtpNgaySinh.Value == DateTime.Now ||
                string.IsNullOrEmpty(mtxtCMND.Text) ||
                string.IsNullOrEmpty(mtxtSDT.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                clbMonDK.Items.Count == 0
              )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                SinhVien sv = LayTTSV_Controls();
                SinhVien kq = dssv.Tim1SV(sv.MSSV, SoSanhTheoMa);

                if (kq != null)
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.dssv.ThemSV(sv);
                    this.TaiListView(dssv);
                    this.dssv.GhiFile_TXT("du-lieu\\DSSinhVien.txt");
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) 
                Application.Exit();
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lviem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = LayTTSV_LV(lviem);
                ThietLapTT_Control(sv);
            }
        }

        #endregion


    }
}
