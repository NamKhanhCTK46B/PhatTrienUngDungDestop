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
    public class CT_HDXL
    {
        CT_HDDL ctDl = new CT_HDDL();

        public List<CT_HD> LayDSCTCuaHD (int idhd)
        {
            return ctDl.CT_HDCuaHD(idhd);
        }
    }
}
