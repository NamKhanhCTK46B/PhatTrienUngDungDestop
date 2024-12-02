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
    public class TangDA
    {
        public List<Tang> LayDSTang()
        {
            List<Tang> ds = new List<Tang>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.LayDSTang;

                    using (SqlDataReader laydl = cmd.ExecuteReader())
                    {
                        while (laydl.Read())
                        {
                            Tang t = new Tang()
                            {
                                ID_Tang = laydl.GetInt32(laydl.GetOrdinal("ID_Tang")),
                                TenTang = laydl["Tang"].ToString(),
                            };
                            ds.Add(t);
                        }
                    }
                }
            }

            return ds;
        }

        public int Them_Xoa_Sua(Tang t, int thaotac)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.ThemXoaSua_Tang;

                    SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add(IDPara).Value = t.ID_Tang;
                    cmd.Parameters.AddWithValue("@tang", t.TenTang);

                    int kq = cmd.ExecuteNonQuery();

                    return kq > 0 ? (int)cmd.Parameters["@id"].Value : 0;
                }
            }
        }
    }
}
