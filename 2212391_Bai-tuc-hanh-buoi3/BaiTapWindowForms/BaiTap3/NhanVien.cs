using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class NhanVien
    {
        public string MaNV { get; set; }

        public string HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        public float HeSoLuong { get; set; }

        public float HeSoPhuCap { get; set; }

        public NhanVien (string maNV, string hoTen, DateTime ngaySinh, float heSoLuong, float heSoPhuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            HeSoLuong = heSoLuong;
            HeSoPhuCap = heSoPhuCap;
        }

        private float TongLuong (float hsLuong, float hsPhuCap)
        {
            float tong = 0;
            return tong = (hsLuong + hsPhuCap) * 1150000;
        }

        public string HienThi ()
        {
            return string.Format("{0} | {1}  |{2} | {3} | {4} | {5}",
                                  MaNV, HoTen, NgaySinh.ToString("dd/MM/yyyy"), HeSoLuong.ToString(), HeSoPhuCap.ToString(),
                                  TongLuong(HeSoLuong, HeSoPhuCap).ToString()
                                );
        }
    }
}
