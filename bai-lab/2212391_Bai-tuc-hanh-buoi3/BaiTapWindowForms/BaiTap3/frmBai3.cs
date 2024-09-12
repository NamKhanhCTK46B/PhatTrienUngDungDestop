using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnTachChuoi_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string ho = "";
            string ten = "";

            XuLy.TachChuoi(hoTen, ref ho, ref ten);

            txtHo.Text = ho;
            txtTen.Text = ten;

            txtHoTen.Focus();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            int s1 = int.Parse(txtS1.Text);
            int s2 = int.Parse(txtS2.Text);

            if (XuLy.ThuTu(s1, s1) == true)
                lblKetQua.Text = "Hai số liền kề";
            else
                lblKetQua.Text = "Hai số không liền kề";
        }
    }
}
