using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThongTinSV
{
    public delegate int SoSanh (object obj1, object obj2);
    internal class QLSinhVien
    {
        public List<SinhVien> DSSV;

        public SinhVien this[int index]
        {
            get { return DSSV[index]; }
            set { DSSV[index] = value; }
        }

        public void ThemSV (SinhVien sv)
        {
            this.DSSV.Add(sv);
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DSSV.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                    this.DSSV.RemoveAt(i);
            }
        }

        public SinhVien Tim (object obj, SoSanh ss)
        {
            SinhVien kq = null;
            foreach (SinhVien sv in DSSV)
            {
                if (ss(obj,sv) == 0)
                {
                    kq = sv;
                    break;
                }
            }
            return kq;
        }
    }
}
