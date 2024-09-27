using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string Hinh { get; set; }

        public SinhVien ()
        {

        }

        public SinhVien (string mssv, string ten, string email, string diaChi, DateTime ngaySinh, bool gt, string lop,string sdt, string hinh)
        {
            this.MSSV = mssv;
            this.HoTen = ten;
            this.Email = email;
            this.DiaChi = diaChi;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gt;
            this.Lop = lop;
            this.SDT = sdt;
            this.Hinh = hinh;
        }
    }
}
