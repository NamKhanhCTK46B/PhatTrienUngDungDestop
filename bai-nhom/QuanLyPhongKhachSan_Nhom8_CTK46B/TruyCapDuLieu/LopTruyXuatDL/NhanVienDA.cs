using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;

namespace TruyCapDuLieu.LopTruyXuatDL
{
    public class NhanVienDA
    {
        public List<NhanVien> LayDSNhanVien()
        {
            SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi);
            kn.Open();

            SqlCommand truyvan = kn.CreateCommand();
            truyvan.CommandType = CommandType.StoredProcedure;
            truyvan.CommandText = TienIch.LayDSNhanVien;

            SqlDataReader laydl = truyvan.ExecuteReader();
            List<NhanVien> ds = new List<NhanVien>();

            while (laydl.Read())
            {
                NhanVien nv = new NhanVien()
                {
                    ID_NV = laydl.GetInt32(laydl.GetOrdinal("ID_NV")),
                    TenNV = laydl["TenNV"].ToString(),
                    SoCCCD = laydl["SoCCCD"].ToString(),
                    GioiTinh = laydl.GetInt32(laydl.GetOrdinal("GioiTinh")),
                    NgaySinh = laydl.GetDateTime(laydl.GetOrdinal("NgaySinh")),
                    NgayVaoLam = laydl.GetDateTime(laydl.GetOrdinal("NgayVaoLam")),
                    SDT = laydl["SDT"].ToString(),
                    Email = laydl["Email"].ToString(),
                    ID_VT = laydl.GetInt32(laydl.GetOrdinal("ID_VT")),
                    TenDN = laydl["TenDN"].ToString(),
                    MatKhau = laydl["MatKhau"].ToString(),
                    GhiChu = laydl["GhiChu"].ToString(),
                    KhaDung = laydl.GetByte(laydl.GetOrdinal("KhaDung"))
                };

                ds.Add(nv);
            }

            kn.Close();
            kn.Dispose();

            return ds;
        }

        public int Them_Xoa_Sua(NhanVien nv, int thaotac)
        {
            SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi);

            kn.Open();

            SqlCommand truyvan = kn.CreateCommand();
            truyvan.CommandType = CommandType.StoredProcedure;
            truyvan.CommandText = TienIch.ThemXoaSua_NhanVien;

            SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            truyvan.Parameters.Add(IDPara).Value = nv.ID_NV;
            truyvan.Parameters.AddWithValue("@ten", nv.TenNV);
            truyvan.Parameters.AddWithValue("@cccd", nv.SoCCCD);
            truyvan.Parameters.AddWithValue("@gt", nv.GioiTinh);
            truyvan.Parameters.AddWithValue("@ngaysinh", nv.NgaySinh);
            truyvan.Parameters.AddWithValue("@ngayvaolam", nv.NgayVaoLam);
            truyvan.Parameters.AddWithValue("@sdt", nv.SDT);
            truyvan.Parameters.AddWithValue("@email", nv.Email);
            truyvan.Parameters.AddWithValue("@idvt", nv.ID_VT);
            truyvan.Parameters.AddWithValue("@tendn", nv.TenDN);
            truyvan.Parameters.AddWithValue("@matkhau", nv.MatKhau);
            truyvan.Parameters.AddWithValue("@ghichu", nv.GhiChu);
            truyvan.Parameters.AddWithValue("@action", thaotac);

            int kq = truyvan.ExecuteNonQuery();

            if (kq > 0)
                return (int)truyvan.Parameters["@id"].Value;

            return 0;
        }

        // Phương thức kiểm tra thông tin đăng nhập của nhân viên
        public bool KiemTraTTDangNhap(string tenDN, string matKhau)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();
                string truyvan = @"SELECT * FROM NhanVien WHERE TenDN = @tendn AND MatKhau = @matkhau AND KhaDung = 0";

                SqlCommand cmd = new SqlCommand(truyvan, kn);
                cmd.Parameters.AddWithValue("@tendn", tenDN);
                cmd.Parameters.AddWithValue("@matkkhau", matKhau);

                SqlDataReader laydl = cmd.ExecuteReader();

                if (laydl.HasRows)
                {
                    laydl.Close();
                    return true;
                }
                return false;
            }
        }

        // Phương thức kiểm tra xem nhân viên mới nhập có trùng với nhân viên đã có hay không
        public bool KiemTraTrungNhanVien(string cccd, string tendn, string email)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                string truyvan = @"SELECT COUNT (*) FROM NhanVien WHERE SoCCCD = @CCCD OR TenDN = @TenDN OR Email = @Email";

                using (SqlCommand cmd = new SqlCommand(truyvan, kn))
                {
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    cmd.Parameters.AddWithValue("@TenDN", tendn);
                    cmd.Parameters.AddWithValue("@Email", email);

                    // Thực hiện truy vấn và lấy kết quả
                    int kq = (int)cmd.ExecuteScalar();

                    // Nếu kết quả > 0, đã có nhân viên trong hệ thống
                    return kq > 0;
                }
            }
        }
        
    }
}
