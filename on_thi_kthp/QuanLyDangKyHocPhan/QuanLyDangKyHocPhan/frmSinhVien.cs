using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDangKyHocPhan
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien(string maMH)
        {
            InitializeComponent();
            this.maMH = maMH;
        }

        string maMH = "";
        string chuoiKN = "server = Admin-PC\\SQLEXPRESS; database = QLDKHP; integrated security = true";

        private void TaiDSSinhVien ()
        {
            using (SqlConnection kn = new SqlConnection(chuoiKN))
            using (SqlCommand cmd = kn.CreateCommand())
            {
                cmd.CommandText = "select TenMH from MonHoc where MaMH = @mamh";
                cmd.Parameters.AddWithValue("@mamh", maMH);

                kn.Open();

                string tenMH = cmd.ExecuteScalar().ToString();
                lblTenMH.Text = tenMH;

                cmd.CommandText = "select sv.MaSV, HoTen, TenLop " +
                                  "from SinhVien sv, Lop l, Hoc h " +
                                  "where sv.MaLop = l.MaLop and h.MaSV = sv.MaSV and h.MaMH = @mamh";
                //cmd.Parameters.AddWithValue("@mamh", maMH);

                SqlDataAdapter laydl = new SqlDataAdapter(cmd);
                DataTable dsSinhVien = new DataTable();

                laydl.Fill(dsSinhVien);

                dgvSinhVien.DataSource = dsSinhVien;
            }    
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            TaiDSSinhVien();
        }
    }
}
