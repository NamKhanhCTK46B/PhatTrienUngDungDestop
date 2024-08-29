using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class XuLy
    {
        public static void TachChuoi (string hoTen, ref string ho,  ref string ten)
        {
            int index = hoTen.LastIndexOf (' ');

            ho = hoTen.Substring (0, index);
            ten = hoTen.Substring (index + 1);
        }

        public static bool ThuTu (int s1, int s2)
        {
            if (Math.Abs(s1 - s2) == 1)
                return true ;
            return false ;
        }
    }
}
