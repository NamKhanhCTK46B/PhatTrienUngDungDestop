using System;
using System.Collections.Generic;
using System.IO;
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

        public bool Sua (SinhVien svSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DSSV.Count - 1;

            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svSua;
                    kq= true;
                    break;
                }

            return kq;
        }

        public void DocFile_TXT (string tenFile)
        {
            string t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(tenFile, FileMode.Open));

            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();

                sv.MSSV = s[0];
                sv.HoTenLot = s[1];
                sv.Ten = s[2];
                sv.NgaySinh = DateTime.Parse(s[3]);
                sv.Lop = s[4];
                sv.SoCMND = s[5];
                sv.SDT = s[6];
                sv.DiaChi = s[7];
                sv.GioiTinh = false;
                if (s[8] == "1")
                    sv.GioiTinh= true;
                string[] mondk = s[9].Split(',');
                foreach (string m in mondk)
                    sv.MonHocDK.Add(m);

                this.ThemSV(sv);
            }
        }
    }
}
