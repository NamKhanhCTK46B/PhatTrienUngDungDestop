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
    public class KhachHangDA
    {
        public List<KhachHang> LayDSKH()
        {
            List<KhachHang> ds = new List<KhachHang>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.LayDSKhachHang;

                    using (SqlDataReader laydl = cmd.ExecuteReader())
                    {
                        while (laydl.Read())
                        {
                            KhachHang kh = new KhachHang()
                            {
                                ID_KH = laydl.GetInt32(laydl.GetOrdinal("ID_KH")),
                                TenKH = laydl["TenKH"].ToString(),
                                GioiTinh = laydl.GetBoolean(laydl.GetOrdinal("GioiTinh")),
                                NgaySinh = laydl.GetDateTime(laydl.GetOrdinal("NgaySinh")),
                                SDT = laydl["SDT"].ToString(),
                                Email = laydl["Email"].ToString(),
                                SoGiayTo = laydl["SoGiayTo"].ToString()
                            };
                            ds.Add(kh);
                        }
                    }
                }
            }

            return ds;
        }

        public int Them_Xoa_Sua(KhachHang kh, int thaotac)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.ThemXoaSua_KhachHang;

                    SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add(IDPara).Value = kh.ID_KH;
                    cmd.Parameters.AddWithValue("@ten", kh.TenKH);
                    cmd.Parameters.AddWithValue("@gt", kh.GioiTinh);
                    cmd.Parameters.AddWithValue("@ngaysinh", kh.NgaySinh);
                    cmd.Parameters.AddWithValue("@sdt", kh.SDT);
                    cmd.Parameters.AddWithValue("@email", kh.Email);
                    cmd.Parameters.AddWithValue("@sogiayto", kh.SoGiayTo);
                    cmd.Parameters.AddWithValue("@ghichu", string.IsNullOrEmpty(kh.GhiChu) ? "" : kh.GhiChu);
                    cmd.Parameters.AddWithValue("@action", thaotac);

                    int kq = cmd.ExecuteNonQuery();

                    return kq > 0 ? (int)cmd.Parameters["@id"].Value : 0;
                }
            }
        }
    }
}
