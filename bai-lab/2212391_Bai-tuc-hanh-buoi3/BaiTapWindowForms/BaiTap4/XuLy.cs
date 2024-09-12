using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap4
{
    internal class XuLy
    {
        public static void ChaoHoi (string hoTen, bool gioiTinh)
        {
            if (gioiTinh)
                Console.WriteLine("Xin chào ông " + hoTen);
            else
                Console.WriteLine("Xin chào bà " + hoTen);
        }

        public static int USCLN (int m, int n)
        {
            if (m < 0) m = -m;
            if (n < 0) n = -n;

            if (m == 0 || n == 0) return 1;

            while (m != n)
            {
                if (m > n)
                    m -= n;
                else 
                    n -= m;
            }  
            
            return m;
        }
    }
}
