using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class ViTriLVBL
    {
        ViTriLVDA vtDA = new ViTriLVDA();

        public List<ViTriLV> LayDSViTriLV()
        {
            return vtDA.LayDSViTriLV();
        }

        public int Them(ViTriLV vt)
        {
            return vtDA.Them_Xoa_Sua(vt, 0);
        }

        public int Sua(ViTriLV vt)
        {
            return vtDA.Them_Xoa_Sua(vt, 1);
        }

        public int Xoa(ViTriLV vt)
        {
            return vtDA.Them_Xoa_Sua(vt, 2);
        }
    }
}
