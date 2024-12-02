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
    public class ViTriLVDA
    {
        public List<ViTriLV> LayDSViTriLV()
        {
            SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi);
            kn.Open();

            SqlCommand truyvan = kn.CreateCommand();
            truyvan.CommandType = CommandType.StoredProcedure;
            truyvan.CommandText = TienIch.LayDSViTriLV;

            SqlDataReader laydl = truyvan.ExecuteReader();
            List<ViTriLV> ds = new List<ViTriLV>();

            while (laydl.Read())
            {
                ViTriLV vt = new ViTriLV()
                {
                    ID_VT = laydl.GetInt32(laydl.GetOrdinal("ID_VT")),
                    TenVT = laydl["TenVT"].ToString(),
                    Luong = (float)laydl.GetDouble(laydl.GetOrdinal("Luong"))
                };

                ds.Add(vt);
            }

            kn.Close();
            kn.Dispose();

            return ds;
        }

        public int Them_Xoa_Sua(ViTriLV vt, int thaotac)
        {
            SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi);
            kn.Open();

            SqlCommand truyvan = kn.CreateCommand();
            truyvan.CommandType = CommandType.StoredProcedure;
            truyvan.CommandText = TienIch.ThemXoaSua_ViTriLV;

            SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;

            truyvan.Parameters.Add(IDPara).Value = vt.ID_VT;
            truyvan.Parameters.AddWithValue("@ten", vt.TenVT);
            truyvan.Parameters.AddWithValue("@luong", vt.Luong);
            truyvan.Parameters.AddWithValue("@action", thaotac);

            int kq = truyvan.ExecuteNonQuery();

            if (kq > 0)
                return (int)truyvan.Parameters["@id"].Value;
            return 0;
        }
    }
}
