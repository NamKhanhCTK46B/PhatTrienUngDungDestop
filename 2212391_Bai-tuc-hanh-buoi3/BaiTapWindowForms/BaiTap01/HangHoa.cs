using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap01
{
    internal class HangHoa
    {
        public string MaHang { get; set; }

        public string TenHang { get; set; }

        public string DVT { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public HangHoa() 
        { 
        
        }

        public string HienThi()
        {
            return string.Format("{0} \t {1} \t {2} \t {3} \t {4}", MaHang, TenHang, DVT, SoLuong, DonGia);
        }
    }
}
