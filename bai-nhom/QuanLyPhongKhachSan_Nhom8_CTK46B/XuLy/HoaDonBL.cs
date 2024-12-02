using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class HoaDonBL
    {
        HoaDonDA hdDA = new HoaDonDA();

        public List<HoaDon> LayDSHDCuaKH(int idkh)
        {
            return hdDA.LayDSHDCuaKH(idkh);
        }

        public List<HoaDon> LayDSHDCuaKH_Ngay(int idkh, DateTime bd, DateTime kt)
        {
            return hdDA.LayDSHDCuaKH_Ngay(idkh, bd, kt);
        }

        public List<HoaDon> LayHDCuaPhong(int idp)
        {
            return hdDA.LayDSHDCuaPhong(idp);
        }
    }
}
