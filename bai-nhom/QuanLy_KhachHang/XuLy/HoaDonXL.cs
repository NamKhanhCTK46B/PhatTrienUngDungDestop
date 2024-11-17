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
    public class HoaDonXL
    {
        HoaDonDL hdDL = new HoaDonDL();

        public List<HoaDon> LayDSHDCuaKH (int idkh)
        {
            return hdDL.LayDSHDCuaKH(idkh);
        }

        public List<HoaDon> LayDSHDCuaKH_Ngay (int idkh, DateTime bd, DateTime kt)
        {
            return hdDL.LayDSHDCuaKH_Ngay(idkh, bd, kt);
        }
    }
}
