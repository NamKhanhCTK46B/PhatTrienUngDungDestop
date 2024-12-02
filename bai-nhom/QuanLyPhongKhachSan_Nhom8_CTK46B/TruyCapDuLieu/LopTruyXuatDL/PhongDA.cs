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
    public class PhongDA
    {

        #region Các phương thức dùng cho form quản lý phòng
        public List<Phong> LayDSPhong()
        {

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.LayDSPhong;

                    using (SqlDataReader laydl = cmd.ExecuteReader())
                    {

                        List<Phong> ds = new List<Phong>();
                        while (laydl.Read())
                        {
                            Phong p = new Phong()
                            {
                                ID_Phong = laydl.GetInt32(laydl.GetOrdinal("ID_Phong")),
                                SoPhong = laydl["SoPhong"].ToString(),
                                ID_HP = laydl.GetInt32(laydl.GetOrdinal("ID_HP")),
                                ID_Tang = laydl.GetInt32(laydl.GetOrdinal("ID_Tang")),
                                MoTa = laydl["MoTa"].ToString(),
                                TrangThai = laydl.GetByte(laydl.GetOrdinal("TrangThai")),
                                GhiChu = laydl["GhiChu"].ToString()
                            };
                            ds.Add(p);
                        }
                        return ds;
                    }
                }
            }

           
        }

        public int Them_Xoa_Sua(Phong p, int thaotac)
        {
            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand cmd = kn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = TienIch.ThemXoaSua_Phong;

                    SqlParameter IDPara = new SqlParameter("@id", SqlDbType.Int);
                    IDPara.Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add(IDPara).Value = p.ID_Phong;
                    cmd.Parameters.AddWithValue("@sophong", p.SoPhong);
                    cmd.Parameters.AddWithValue("@idhp", p.ID_HP);
                    cmd.Parameters.AddWithValue("@idtang", p.ID_Tang);
                    cmd.Parameters.AddWithValue("@mota", p.MoTa);
                    cmd.Parameters.AddWithValue("@trangthai", p.TrangThai);
                    cmd.Parameters.AddWithValue("@ghichu", p.GhiChu);
                    cmd.Parameters.AddWithValue("@action", thaotac);

                    int kq = cmd.ExecuteNonQuery();

                    return kq > 0 ? (int)cmd.Parameters["@id"].Value : 0;
                }
            }
        }
        #endregion

    }
}
