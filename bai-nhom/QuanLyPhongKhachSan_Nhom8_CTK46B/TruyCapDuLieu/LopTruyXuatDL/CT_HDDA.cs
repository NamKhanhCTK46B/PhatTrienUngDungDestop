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
    public class CT_HDDA
    {
        public List<CT_HD> CT_HDCuaHD(int idhd)
        {
            List<CT_HD> ds = new List<CT_HD>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand l = new SqlCommand(TienIch.LayCTHDCuaHD, kn))
                {
                    l.CommandType = CommandType.StoredProcedure;
                    l.Parameters.AddWithValue("@idhd", idhd);

                    using (SqlDataReader laydl = l.ExecuteReader())
                    {
                        while (laydl.Read())
                        {
                            CT_HD ct = new CT_HD()
                            {
                                ID_CT = laydl.GetInt32(laydl.GetOrdinal("ID_CT")),
                                ID_HD = laydl.GetInt32(laydl.GetOrdinal("ID_HD")),
                                ID_Phong = laydl.GetInt32(laydl.GetOrdinal("ID_Phong")),
                                Gia = laydl.GetFloat(laydl.GetOrdinal("Gia")),
                                ThoiGianThue = laydl.GetFloat(laydl.GetOrdinal("ThoiGianThue")),
                                DonVi = laydl["DonVi"] as string
                            };
                            ds.Add(ct);
                        }
                    }
                }
            }

            return ds;
        }
    }
}
