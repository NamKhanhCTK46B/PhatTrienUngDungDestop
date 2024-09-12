using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Demo
{
    public delegate int SoSanh (object sv1, object sv2);
    internal class QuanLySinhVien
    {
        public List <SinhVien> DanhSach;
        public QuanLySinhVien ()
        {
            DanhSach = new List<SinhVien> ();
        }

        public void Them (SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }

        public SinhVien this[int index]
        {
            get { return this.DanhSach[index]; }
            set { this.DanhSach[index] = value; }
        }

        public void Xoa (object sv, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i++)
            {
                if (ss(sv, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
            }
        }

        public SinhVien Tim (object sv, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien i in DanhSach)
                if (ss(sv,i) == 0)
                {
                    svresult = i;
                    break;
                }    
            return svresult;
        }

        public bool Sua(SinhVien svsua, Object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = DanhSach.Count - 1;
            for (i = 0; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void DocTuFile()
        {
            string filename = "DanhSachSV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(
            new FileStream(filename,
            FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.MaSo = s[0];
                sv.HoTen = s[1];
                sv.NgaySinh = DateTime.Parse(s[2]);
                sv.DiaChi = s[3];
                sv.Lop = s[4];
                sv.Hinh = s[5];
                sv.GioiTinh = false;
                if (s[6] == "1")
                    sv.GioiTinh = true;
                string[] cn = s[7].Split(',');
                foreach (string c in cn)
                    sv.ChuyenNganh.Add(c);
                this.Them(sv);
            }
        }
    }
}