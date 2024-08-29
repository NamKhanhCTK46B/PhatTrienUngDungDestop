using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap2
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            long n = long.Parse(txtSoN.Text);
            long kq = XuLy.GiaiThua(n);

            lblKetQua.Text = kq.ToString();
        }

        private void btnHoTen_Click(object sender, EventArgs e)
        {
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string hoTen = "";

            XuLy.NoiChuoi(ho, ten, ref hoTen);

            txtHoTen.Text = hoTen.ToString();

            txtHo.Focus();
        }
    }
}
