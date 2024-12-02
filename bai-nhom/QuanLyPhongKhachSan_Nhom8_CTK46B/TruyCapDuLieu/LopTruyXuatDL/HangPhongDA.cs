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
    public class HangPhongDA
    {
        public List<HangPhong> LayDSHangPhong()
        {
            

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.LayDSHangPhong;

                    using (SqlDataReader laydl = cmd.ExecuteReader())
                    {
                        List<HangPhong> ds = new List<HangPhong>();
                        while (laydl.Read())
                        {
                            HangPhong hp = new HangPhong()
                            {
                                ID_HP = laydl.GetInt32(laydl.GetOrdinal("ID_HP")),
                                TenHP = laydl["HangPhong"].ToString(),
                                Gia = (float)laydl.GetDouble(laydl.GetOrdinal("Gia")),
                                GiaGio = (float)laydl.GetDouble(laydl.GetOrdinal("GiaGio")),
                                DienTich = (float)laydl.GetDouble(laydl.GetOrdinal("DienTich")),
                                DonViDT = laydl["DonViDT"].ToString(),
                                SucChuaToiDa = laydl["SucChuaToiDa"].ToString(),
                                GhiChu = laydl["GhiChu"].ToString()
                            };
                            ds.Add(hp);

                        }
                        return ds;
                    }
                }
            }
            
        }

        public int Them_Xoa_Sua(HangPhong hp, int thaotac)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.ThemXoaSua_HangPhong;

                    SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add(IDPara).Value = hp.ID_HP;
                    cmd.Parameters.AddWithValue("@hangphong", hp.TenHP);
                    cmd.Parameters.AddWithValue("@gia", hp.Gia);
                    cmd.Parameters.AddWithValue("@giagio", hp.GiaGio);
                    cmd.Parameters.AddWithValue("@dientich", hp.DienTich);
                    cmd.Parameters.AddWithValue("@donvidt", hp.DonViDT);
                    cmd.Parameters.AddWithValue("@succhua", hp.SucChuaToiDa);
                    cmd.Parameters.AddWithValue("@ghichu", hp.GhiChu);
                    cmd.Parameters.AddWithValue("@action", thaotac);

                    int kq = cmd.ExecuteNonQuery();

                    return kq > 0 ? (int)cmd.Parameters["@id"].Value : 0;
                }
            }
        }
    }
}
