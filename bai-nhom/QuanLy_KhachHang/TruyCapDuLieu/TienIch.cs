using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TruyCapDuLieu
{
    public class TienIch
    {
        private static string tenChuoi = "ChuoiKetNoiCSDL";
        public static string ChuoiKetNoi = ConfigurationManager.ConnectionStrings[tenChuoi].ConnectionString;

        public static string LayDSKhachHang = "LayDSKhachHang";
        public static string ThemXoaSua_KhachHang = "ThemXoaSua_KhachHang";

        public static string LayHDCuaKH = "LayHDCuaKH";
        public static string LayDSHDCuaKH_Ngay = "LayDSHDCuaKH_Ngay";
        public static string LayCTHDCuaHD = "LayCTHDCuaHD";
    }
}
