using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnChaoHoi_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;

            //Chưa xử lý được
            if (rbNam.Checked)
                XuLy.ChaoHoi(hoTen, true);
            else          
                XuLy.ChaoHoi(hoTen, false);              

            txtHoTen.Focus();
        }

        private void btnTinhToan_Click(object sender, EventArgs e)
        {
            int m = int.Parse(txtSoM.Text);
            int n = int.Parse(txtSoN.Text);
            int kq = XuLy.USCLN(m, n);

            txtUSCLN.Text = kq.ToString();

            txtSoM.Focus();
        }
    }
}
