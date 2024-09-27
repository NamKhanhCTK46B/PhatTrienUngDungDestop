using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class frmChinh : Form
    {
        DSSinhVien dssv;
        public frmChinh()
        {
            InitializeComponent();
        }


        #region Phương thức bổ trợ

        private SinhVien GetSV_Controls ()
        {
            SinhVien sv = new SinhVien();
            bool gt = false;

            sv.MSSV = this.mtxtMSSV.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.Email = this.txtEmail.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            if (rdNam.Checked)
                gt = true;
            sv.GioiTinh = gt;
            sv.Lop = this.cboLop.Text;
            sv.SDT = this.mtxtSDT.Text;
            sv.Hinh = this.txtChonHinh.Text;

            return sv;
        }

        private SinhVien GetSV_LV (ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();

            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.Email = lvitem.SubItems[2].Text;
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            sv.Lop = lvitem.SubItems[6].Text;
            sv.SDT = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;

            return sv;
        }

        private void ThietLapThongTin_Controls(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MSSV;
            this.txtHoTen.Text = sv.HoTen;
            this.txtEmail.Text = sv.Email;
            this.txtDiaChi.Text = sv.DiaChi;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            this.cboLop.Text = sv.Lop;
            this.mtxtSDT.Text = sv.SDT;
            this.txtChonHinh.Text = sv.Hinh;
            pbHinh.Image = Image.FromFile(sv.Hinh);
        }

        private void ThemSV_LV (SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add (sv.SDT);
            lvitem.SubItems.Add(sv.Hinh);

            this.lvDSSV.Items.Add(lvitem);
        }

        private void Load_LV ()
        {
            this.lvDSSV.Items.Clear();
            foreach (SinhVien sv in dssv.DSSV)
            {
                ThemSV_LV(sv);
            }
        }

        private int SoSanhTheoMa (object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        #endregion

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMSSV.Text = "";
            this.txtHoTen.Text = "";
            this.txtEmail.Text = "";
            this.txtDiaChi.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.mtxtSDT.Text = "";
            this.txtChonHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            
            this.mtxtMSSV.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileIg.Title = "Chọn Hình của sinh viên";
            //OpenFileIg.Filter = "Image Files (PNG, JPEG, etc.)|"
            //                   + "*.jpg; *.jpeg;*.png|"
            //                   + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg"
            //                   + "PNG files (*.png)|*.png| All files(*.*|*.*)";

            if (OpenFileIg.ShowDialog() == DialogResult.OK)
            {
                txtChonHinh.Text = OpenFileIg.FileName;
                pbHinh.Image = Image.FromFile(OpenFileIg.FileName);
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSV_Controls();
            SinhVien kq = dssv.Tim_SV(  sv.MSSV, 
                                        delegate (object obj1, object obj2)
                                        {
                                            return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
                                        }
                                      );
            if (kq == null)
            {
                this.dssv.Them_SV(sv);
                this.Load_LV();
            }
            else
            {
                bool kqSua;
                kqSua = dssv.Sua(sv, sv.MSSV, SoSanhTheoMa);
                if (kqSua)
                {
                    this.Load_LV();
                }
            }    
        }

        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvDSSV.Items.Count - 1;
            for(i = count; i >= 0; i--)
            {
                lvitem = this.lvDSSV.Items[i];
                if (lvitem.Checked)
                    dssv.Xoa_SV(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }    
            this.Load_LV();
            this.btnMacDinh.PerformClick();
        }
    }
}
