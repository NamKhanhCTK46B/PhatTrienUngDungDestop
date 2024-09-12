using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKhachHang
{
    internal class LoaiKH
    {
        public int ID_LoaiKH {  get; set; }
        public string TenLoai {  get; set; }
        public string GhiChu { get; set; }

        public LoaiKH() { }

        public LoaiKH (string ten, string ghiChu)
        {
            this.TenLoai = ten;
            this.GhiChu = ghiChu;
        }
    }
}
