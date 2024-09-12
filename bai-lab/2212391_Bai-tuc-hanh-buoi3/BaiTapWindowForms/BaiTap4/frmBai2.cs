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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnXepLoai_Click(object sender, EventArgs e)
        {
            float diemLT = float.Parse(txtDiemLT.Text);
            float diemTH = float.Parse(txtDiemTH.Text);
            float dtb = 0;


            if ( (diemLT < 0 && diemLT > 10) ||  (diemTH < 0 && diemTH > 10))
            {
                MessageBox.Show("Điểm số không bé hơn 0 hoặc lớn hơn 10");
            }

            dtb = (diemTH - diemTH) / 2;

            if ((diemLT < 5) || (diemTH < 5))
                lblKetQua.Text = "Yếu";
            else
            {
                if (dtb < 7)
                    lblKetQua.Text = "Trung bình";
                else
                {
                    if (dtb >= 7 && dtb < 8)
                        lblKetQua.Text = "Khá";
                    else
                    {
                        if (dtb >= 7 && dtb < 8)
                            lblKetQua.Text = "Giỏi";
                        else
                            lblKetQua.Text = "Xuất sắc";
                    }
                }
            }
            
            txtDiemLT.Focus();
        }
    }
}
