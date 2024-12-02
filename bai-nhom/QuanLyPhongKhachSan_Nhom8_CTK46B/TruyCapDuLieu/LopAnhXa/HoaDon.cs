using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyCapDuLieu.LopAnhXa
{
    public class HoaDon
    {
        public int ID_HD { get; set; }

        public int ID_NV { get; set; }

        public int ID_KH { get; set; }

        public DateTime NgayLap { get; set; }

        public DateTime NgayToi { get; set; }

        public DateTime NgayDi { get; set; }

        public float DatCoc { get; set; }

        public int HinhThucThanhToan { get; set; }
        //hình thức thanh toán của khách hàng 0: chuyển khoản; 1: tiền mặt

        public float PhuThu { get; set; }

        public int TrangThai { get; set; }
        //trạng thái thanh toán của hoá đơn 0: chưa thanh toán, 1: đã thanh toán

        public float TongTien { get; set; }

        public string GhiChu { get; set; }
    }
}
