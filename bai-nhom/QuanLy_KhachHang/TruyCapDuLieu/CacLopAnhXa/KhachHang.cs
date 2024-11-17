using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyCapDuLieu.CacLopAnhXa
{
    public class KhachHang
    {
        public int ID_KH { get; set; }

        public string TenKH { get; set; }

        public bool GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string SDT {  get; set; }

        public string Email { get; set; }

        public string SoGiayTo {  get; set; }

        public string GhiChu {  get; set; }
    }
}
