using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu;
using TruyCapDuLieu.CacLopAnhXa;
using TruyCapDuLieu.CacLopTruyXuatDuLieu;

namespace XuLy
{
    public class KhachHangXL
    {
        KhachHangDL khDL = new KhachHangDL ();

        public List<KhachHang> LayDSKH ()
        {
            return khDL.LayDSKH ();
        }

        public List<KhachHang> TimKiem (string khoa)
        {
            List<KhachHang> ds = LayDSKH ();
            List<KhachHang> kq = new List<KhachHang> ();

            foreach (var kh in ds)
            {
                if ( kh.ID_KH.ToString().Contains(khoa)
                    || kh.TenKH.Contains(khoa)
                    || kh.SoGiayTo.Contains(khoa)
                    || kh.SDT.Contains(khoa))

                    kq.Add (kh);
            }  
            
            return kq;
        }

        public int ThemKH (KhachHang kh)
        {
            return khDL.Them_Xoa_Sua(kh, 0);
        }

        public int SuaKH (KhachHang kh)
        {
            return khDL.Them_Xoa_Sua(kh, 1);
        }

        public int XoaKH (KhachHang kh)
        {
            return khDL.Them_Xoa_Sua (kh, 2);
        }
    }
}
