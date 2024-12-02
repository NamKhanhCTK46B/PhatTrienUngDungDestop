using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruyCapDuLieu.LopAnhXa;
using XuLy;

namespace QuanLyPhongKhachSan.QLPhong
{
    public partial class frmQL_Tang : Form
    {
        public frmQL_Tang()
        {
            InitializeComponent();
        }

        TangBL tBL = new TangBL();
        List<Tang> ds = new List<Tang>();

        Tang tangHienTai = new Tang();

        private void LayDSTang ()
        {
            ds = tBL.LayDSTang();
        }

        private void TaiDSTangLenLV ()
        {
            lvTang.Items.Clear();

            foreach (Tang t in ds)
            {
                ListViewItem item = new ListViewItem(t.ID_Tang.ToString());

                item.SubItems.Add(t.TenTang);

                lvTang.Items.Add(item);
            }
        }

        private void frmQL_Tang_Load(object sender, EventArgs e)
        {
            LayDSTang();
            TaiDSTangLenLV();
        }
    }
}
