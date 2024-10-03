using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThongTinSV
{
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
        {
            InitializeComponent();
        }
        
        public void btn_Tim_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mtxtMSSV_TK.Text) && string.IsNullOrEmpty(txtTen_TK.Text) && string.IsNullOrEmpty(cboLop_TK.Text) )
                MessageBox.Show ("Xin hãy nhập thông tin tìm kiếm","Lỗi tìm kiếm",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            string mssv = mtxtMSSV_TK.Text;
            string ten = txtTen_TK.Text;
            string lop = cboLop_TK.Text;

            QLSinhVien kq;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
