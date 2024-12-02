using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyCapDuLieu.LopAnhXa
{
    public class NhanVien
    {
        public int ID_NV { get; set; }

        public string TenNV { get; set; }

        public string SoCCCD { get; set; }

        public int GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public DateTime NgayVaoLam { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public int ID_VT { get; set; }

        public string TenDN { get; set; }

        public string MatKhau { get; set; }

        public string GhiChu { get; set; }

        public byte KhaDung { get; set; }
    }
}
