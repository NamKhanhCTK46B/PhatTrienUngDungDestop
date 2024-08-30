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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtSoThuNhat.Text);
            int b = int.Parse(txtSoThuHai.Text);
            int kq = 0;

            if (rbCong.Checked)
                kq = a + b;
            if (rbTru.Checked)
                kq = a - b;
            if (rbNhan.Checked)
                kq = a * b;
            if (rbChia.Checked)
                kq = a / b;

            lblKetQua.Text = kq.ToString();
        }
    }
}
