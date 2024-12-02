using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class TangBL
    {
        TangDA khDA = new TangDA();

        public List<Tang> LayDSTang()
        {
            return khDA.LayDSTang();
        }

        public int Them(Tang t)
        {
            return khDA.Them_Xoa_Sua(t, 0);
        }

        public int Sua(Tang t)
        {
            return khDA.Them_Xoa_Sua(t, 1);
        }

        public int Xoa(Tang t)
        {
            return khDA.Them_Xoa_Sua(t, 2);
        }
    }
}
