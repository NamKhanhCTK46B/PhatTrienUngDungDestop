using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    internal class ThietBi
    {
        public string MaThietBi {  get; set; }

        public string TenThietBi { get; set; }

        public string NuocSanXuat {  get; set; }

        public int DonGia {  get; set; }

        public int SoLuong {  get; set; }
       

        public ThietBi (string maThietBi, string tenThietBi, string nuocSanXuat, int donGia, int soLuong)
        {
            MaThietBi = maThietBi;
            TenThietBi = tenThietBi;
            NuocSanXuat = nuocSanXuat;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public int ThanhTien(int donGia, int soLuong)
        {
            int thanhTien = 0;
            return thanhTien = donGia * soLuong;
        }

        public string HienThi ()
        { 
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", MaThietBi, TenThietBi, NuocSanXuat, DonGia, SoLuong, ThanhTien(DonGia, SoLuong).ToString()); 
        }
    }
}
