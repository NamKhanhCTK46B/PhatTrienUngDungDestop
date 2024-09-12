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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoN.Text);

            if(n<0)
            {
                MessageBox.Show("Hãy nhập số n là số nguyên dương");
                txtSoN.Focus();
            }

            int kq = 1;

            if (rbTong.Checked)
            {
                for(int i = 0; i < n; i++)
                {
                    kq += i;
                }
            }
            else
            {
                for(int i = 1; i <= n; i++)
                {
                    kq *= i;
                }
            }  
            
            lblKetQua.Text = kq.ToString();

            txtSoN.Focus();
        }
    }
}
