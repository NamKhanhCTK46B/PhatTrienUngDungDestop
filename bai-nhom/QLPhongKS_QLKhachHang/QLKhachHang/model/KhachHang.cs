using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKhachHang
{
    internal class KhachHang
    {
        public int ID_KH {  get; set; }
        public string TenKH { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT {  get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoCCCD { get; set; }
        public LoaiKH LoaiKH {  get; set; }
        public string GhiChu { get; set; }

        public KhachHang() 
        { 
            LoaiKH = new LoaiKH();
        }

        public KhachHang (string ten, bool gt, string sdt, string email, string cccd, LoaiKH loai, string ghiChu, DateTime ngaySinh)
        {
            this.TenKH = ten;
            this.GioiTinh = gt;
            this.SDT = sdt;
            this.Email = email;
            this.SoCCCD = cccd;
            this.LoaiKH = loai;
            this.GhiChu = ghiChu;
            this.NgaySinh = ngaySinh;
        }
    }
}
