using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class HangPhongBL
    {
        HangPhongDA hpDA = new HangPhongDA();

        public List<HangPhong> LayDSHangPhong()
        {
            return hpDA.LayDSHangPhong();
        }

        public int Them(HangPhong hp)
        {
            return hpDA.Them_Xoa_Sua(hp, 0);
        }

        public int Sua(HangPhong hp)
        {
            return hpDA.Them_Xoa_Sua(hp, 1);
        }

        public int Xoa(HangPhong hp)
        {
            return hpDA.Them_Xoa_Sua(hp, 2);
        }
    }
}
