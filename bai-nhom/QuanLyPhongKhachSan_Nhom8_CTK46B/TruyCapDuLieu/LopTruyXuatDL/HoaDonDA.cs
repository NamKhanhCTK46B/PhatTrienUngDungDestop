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
    public class HoaDonDA
    {
        public List<HoaDon> LayDSHDCuaKH(int idkh)
        {
            List<HoaDon> ds = new List<HoaDon>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand l = kn.CreateCommand())
                {
                    l.CommandType = CommandType.StoredProcedure;
                    l.CommandText = TienIch.LayHDCuaKH;

                    l.Parameters.AddWithValue("idkh", idkh);

                    using (SqlDataReader laydl = l.ExecuteReader())
                    {

                        while (laydl.Read())
                        {
                            HoaDon hd = new HoaDon();

                            hd.ID_HD = laydl.GetInt32(laydl.GetOrdinal("ID_HD"));
                            hd.ID_NV = laydl.GetInt32(laydl.GetOrdinal("ID_NV"));
                            hd.NgayLap = laydl.GetDateTime(laydl.GetOrdinal("NgayLap"));
                            hd.NgayToi = laydl.GetDateTime(laydl.GetOrdinal("NgayToi"));
                            hd.NgayDi = laydl.GetDateTime(laydl.GetOrdinal("NgayDi"));
                            hd.DatCoc = laydl.IsDBNull(laydl.GetOrdinal("DatCoc")) ? 0 : (float)laydl.GetDouble(laydl.GetOrdinal("DatCoc"));
                            hd.HinhThucThanhToan = laydl.GetByte(laydl.GetOrdinal("HinhThucThanhToan"));
                            hd.PhuThu = (float)laydl.GetDouble(laydl.GetOrdinal("PhuThu"));
                            hd.TrangThai = laydl.GetByte(laydl.GetOrdinal("TrangThai"));
                            hd.TongTien = (float)laydl.GetDouble(laydl.GetOrdinal("TongTien"));
                            hd.GhiChu = laydl["GhiChu"] as string;

                            ds.Add(hd);
                        }
                    }
                }
            }

            return ds;
        }

        public List<HoaDon> LayDSHDCuaKH_Ngay(int idkh, DateTime bd, DateTime kt)
        {
            List<HoaDon> ds = new List<HoaDon>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand l = kn.CreateCommand())
                {
                    l.CommandType = CommandType.StoredProcedure;
                    l.CommandText = TienIch.LayDSHDCuaKH_Ngay;

                    l.Parameters.AddWithValue("@idkh", idkh);
                    l.Parameters.AddWithValue("@ngaybd", bd);
                    l.Parameters.AddWithValue("@ngaykt", kt);

                    using (SqlDataReader laydl = l.ExecuteReader())
                    {

                        while (laydl.Read())
                        {
                            HoaDon hd = new HoaDon();

                            hd.ID_HD = laydl.GetInt32(laydl.GetOrdinal("ID_HD"));
                            hd.ID_NV = laydl.GetInt32(laydl.GetOrdinal("ID_NV"));
                            hd.NgayLap = laydl.GetDateTime(laydl.GetOrdinal("NgayLap"));
                            hd.NgayToi = laydl.GetDateTime(laydl.GetOrdinal("NgayToi"));
                            hd.NgayDi = laydl.GetDateTime(laydl.GetOrdinal("NgayDi"));
                            hd.DatCoc = laydl.IsDBNull(laydl.GetOrdinal("DatCoc")) ? 0 : (float)laydl.GetDouble(laydl.GetOrdinal("DatCoc"));
                            hd.HinhThucThanhToan = laydl.GetByte(laydl.GetOrdinal("HinhThucThanhToan"));
                            hd.PhuThu = (float)laydl.GetDouble(laydl.GetOrdinal("PhuThu"));
                            hd.TrangThai = laydl.GetByte(laydl.GetOrdinal("TrangThai"));
                            hd.TongTien = (float)laydl.GetDouble(laydl.GetOrdinal("TongTien"));
                            hd.GhiChu = laydl["GhiChu"] as string;

                            ds.Add(hd);
                        }
                    }
                }
            }

            return ds;
        }

        public List<HoaDon> LayDSHDCuaPhong(int idp)
        {
            List<HoaDon> ds = new List<HoaDon>();

            using (SqlConnection kn = new SqlConnection(TienIch.ChuoiKetNoi))
            {
                kn.Open();

                using (SqlCommand l = kn.CreateCommand())
                {
                    l.CommandType = CommandType.StoredProcedure;
                    l.CommandText = TienIch.LayHDCuaPhong;

                    l.Parameters.AddWithValue("@idp", idp);

                    using (SqlDataReader laydl = l.ExecuteReader())
                    {

                        while (laydl.Read())
                        {
                            HoaDon hd = new HoaDon();

                            hd.ID_HD = laydl.GetInt32(laydl.GetOrdinal("ID_HD"));
                            hd.ID_NV = laydl.GetInt32(laydl.GetOrdinal("ID_NV"));
                            hd.ID_KH = laydl.GetInt32(laydl.GetOrdinal("ID_KH"));
                            hd.NgayLap = laydl.GetDateTime(laydl.GetOrdinal("NgayLap"));
                            hd.NgayToi = laydl.GetDateTime(laydl.GetOrdinal("NgayToi"));
                            hd.NgayDi = laydl.GetDateTime(laydl.GetOrdinal("NgayDi"));
                            hd.DatCoc = laydl.IsDBNull(laydl.GetOrdinal("DatCoc")) ? 0 : (float)laydl.GetDouble(laydl.GetOrdinal("DatCoc"));
                            hd.HinhThucThanhToan = laydl.GetByte(laydl.GetOrdinal("HinhThucThanhToan"));
                            hd.PhuThu = (float)laydl.GetDouble(laydl.GetOrdinal("PhuThu"));
                            hd.TrangThai = laydl.GetByte(laydl.GetOrdinal("TrangThai"));
                            hd.TongTien = (float)laydl.GetDouble(laydl.GetOrdinal("TongTien"));
                            hd.GhiChu = laydl["GhiChu"] as string;

                            ds.Add(hd);
                        }
                    }
                }
            }

            return ds;
        }
    }
}
