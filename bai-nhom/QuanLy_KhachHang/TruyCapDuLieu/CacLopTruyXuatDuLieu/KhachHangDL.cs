using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.CacLopAnhXa;
using System.Data;

namespace TruyCapDuLieu.CacLopTruyXuatDuLieu
{
    public class KhachHangDL
    {
        public List<KhachHang> LayDSKH ()
        {
            SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi);
            kn.Open ();

            SqlCommand lenh = kn.CreateCommand ();
            lenh.CommandType = CommandType.StoredProcedure;
            lenh.CommandText = TienIch.LayDSKhachHang;

            SqlDataReader laydl = lenh.ExecuteReader ();
            List <KhachHang> ds = new List<KhachHang> ();
            while (laydl.Read ())
            {
                KhachHang kh = new KhachHang ();
                kh.ID_KH = Convert.ToInt32 (laydl["ID_KH"]);
                kh.TenKH = laydl["TenKH"].ToString ();
                kh.GioiTinh = Convert.ToBoolean(laydl["GioiTinh"]);
                kh.NgaySinh = Convert.ToDateTime(laydl["NgaySinh"]);
                kh.SDT = laydl["SDT"].ToString ();
                kh.Email = laydl["Email"].ToString ();
                kh.SoGiayTo = laydl["SoGiayTo"].ToString ();
                kh.GhiChu = laydl["GhiChu"].ToString ();

                ds.Add (kh);
            }
            kn.Close ();
            return ds;
        }

        public int Them_Xoa_Sua (KhachHang kh, int hd)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand lenh = kn.CreateCommand())
                {
                    lenh.CommandType = CommandType.StoredProcedure;
                    lenh.CommandText = TienIch.ThemXoaSua_KhachHang;

                    SqlParameter IDPara = new SqlParameter ("@id", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;

                    lenh.Parameters.Add (IDPara).Value = kh.ID_KH;
                    lenh.Parameters.AddWithValue("@ten", kh.TenKH);
                    lenh.Parameters.AddWithValue("@gt", kh.GioiTinh);
                    lenh.Parameters.AddWithValue("@ngaysinh", kh.NgaySinh);
                    lenh.Parameters.AddWithValue("@sdt", kh.SDT);
                    lenh.Parameters.AddWithValue("@email", kh.Email);
                    lenh.Parameters.AddWithValue("@sogiayto", kh.SoGiayTo);
                    lenh.Parameters.AddWithValue("@ghichu", kh.GhiChu);
                    lenh.Parameters.AddWithValue("@action", hd);

                    int kq = lenh.ExecuteNonQuery ();

                    return kq > 0 ? (int)lenh.Parameters["@id"].Value : 0;
                }
            }
        }
    }
}
