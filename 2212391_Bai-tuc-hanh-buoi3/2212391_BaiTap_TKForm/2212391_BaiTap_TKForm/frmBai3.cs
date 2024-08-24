using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2212391_BaiTap_TKForm
{
    public partial class frmBai3 : Form
    {
        List<String> nghiaTu = new List<String>();
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnThemTu_Click(object sender, EventArgs e)
        {
            var tu = txtTuMoi.Text;
            var nghia = txtNghia.Text;
            listBox1.Items.Add(tu);
            nghiaTu.Add(nghia);

            txtTuMoi.Focus();
            txtTuMoi.Text = "";
            txtNghia.Text = "";

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            txtHienThiNghia.Text = nghia;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stt = listBox1.SelectedIndex;
            txtHienThiNghia.Text = nghiaTu[stt];
        }
    }
}
