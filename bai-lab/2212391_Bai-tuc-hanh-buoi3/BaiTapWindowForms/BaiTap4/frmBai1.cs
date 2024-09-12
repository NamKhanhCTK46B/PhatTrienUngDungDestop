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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = "SP001";
            sp.TenSanPham = "Bút bi";
            sp.LoaiSanPham = "Văn phòng phẩm";
            sp.NgaySanXuat = DateTime.Parse("02/04/2024");

            lblHienThi.Text = sp.HienThi();
        }
    }
}
