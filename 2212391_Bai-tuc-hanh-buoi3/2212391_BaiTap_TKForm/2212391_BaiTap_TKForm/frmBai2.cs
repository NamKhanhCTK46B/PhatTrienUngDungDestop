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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnChonHang_Click(object sender, EventArgs e)
        {
            var item = lbDSHangHoa.SelectedItem;
            lbHKhachMua.Items.Add(item);
        }

        private void btnBoHang_Click(object sender, EventArgs e)
        {
            lbHKhachMua.Items.Remove(lbHKhachMua.SelectedItem);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int soTien = 0;
            foreach (var hang in lbHKhachMua.Items)
            {
                switch (hang)
                {
                    case "Chuột":
                        soTien += 100000;
                        break;
                    case "Bàn phím":
                        soTien += 150000;
                        break;
                    case "Máy in":
                        soTien += 2000000;
                        break;
                    case "USB kingmax":
                        soTien += 200000;
                        break;
                    default:
                        break;
                }
            }
            lblSoTien.Text = soTien + " đồng";
        }
    }
}
