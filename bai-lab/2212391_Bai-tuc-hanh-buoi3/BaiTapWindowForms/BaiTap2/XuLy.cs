using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    internal class XuLy
    {
        public static void NoiChuoi (string ho, string ten, ref string s)
        {
            s = ho + " " + ten;
        }

        public static long GiaiThua (long n)
        {
            long kq = 1;
            for (int i = 1; i <= n; i++)
            {
                kq *= i;
            }
            return kq;
        }
    }
}
