using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class PhongBL
    {
        PhongDA pDA = new PhongDA();

        public List<Phong> LayDSPhong()
        {
            return pDA.LayDSPhong();
        }

        public int Them(Phong p)
        {
            return pDA.Them_Xoa_Sua(p, 0);
        }

        public int Sua(Phong p)
        {
            return pDA.Them_Xoa_Sua(p, 1);
        }

        public int Xoa(Phong p)
        {
            return pDA.Them_Xoa_Sua(p, 2);
        }

        public List<Phong> TimKiem (string khoa)
        {
            List<Phong> ds = LayDSPhong();
            List<Phong> kq = new List<Phong>();

            foreach (Phong p in ds) 
            { 
                if (p.SoPhong.Contains(khoa)
                    || p.ID_HP.ToString().Contains(khoa)
                    || p.ID_Tang.ToString().Contains(khoa))
                    kq.Add(p);
            }
            return kq;
        }
    }
}
