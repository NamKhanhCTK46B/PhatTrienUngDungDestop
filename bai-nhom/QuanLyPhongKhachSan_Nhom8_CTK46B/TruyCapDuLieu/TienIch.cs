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
        // Lấy chuỗi kết nối từ tập tin App.config
        private static string TenChuoiKN = "ChuoiKetNoiCSDL";
        public static string ChuoiKetNoi = ConfigurationManager.ConnectionStrings[TenChuoiKN].ConnectionString;

        // Các biến của bảng Tang
        public static string LayDSTang = "LayDSTang";
        public static string ThemXoaSua_Tang = "ThemXoaSua_Tang";

        // Các biến của bảng HangPhong
        public static string LayDSHangPhong = "LayDSHangPhong";
        public static string ThemXoaSua_HangPhong = "ThemXoaSua_HangPhong";

        // Các biến của bảng Phong
        public static string LayDSPhong = "LayDSPhong";
        public static string ThemXoaSua_Phong = "ThemXoaSua_Phong";

        // Các biến của bảng KhachHang
        public static string LayDSKhachHang = "LayDSKhachHang";
        public static string ThemXoaSua_KhachHang = "ThemXoaSua_KhachHang";

        // Các biến của bảng ViTriLV
        public static string LayDSViTriLV = "LayDSViTriLV";
        public static string ThemXoaSua_ViTriLV = "ThemXoaSua_ViTriLV";

        // Các biến của bảng NhanVien
        public static string LayDSNhanVien = "LayDSNhanVien";
        public static string ThemXoaSua_NhanVien = "ThemXoaSua_NhanVien";

        // Các biến của bảng HoaDon
        public static string LayHDCuaKH = "LayHDCuaKH";
        public static string LayDSHDCuaKH_Ngay = "LayDSHDCuaKH_Ngay";
        public static string LayHDCuaPhong = "LayHDCuaPhong";
        public static string LayHDCuaPhong_Ngay = "LayHDCuaPhong_Ngay";
        public static string CapNhatHoaDon = "CapNhatHoaDon";
        public static string ThemXoaSua_HoaDon = "ThemXoaSua_HoaDon";

        // Các biến của bảng CT_HD
        public static string LayCTHDCuaHD = "LayCTHDCuaHD";
        public static string ThemXoa_CTHD = "ThemXoa_CTHD";
    }
}
