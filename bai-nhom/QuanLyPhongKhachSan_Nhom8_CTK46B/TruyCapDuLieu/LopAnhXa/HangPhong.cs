using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyCapDuLieu.LopAnhXa
{
    public class HangPhong
    {
        public int ID_HP { get; set; }

        public string TenHP { get; set; }
        //Tương ứng cột HangPhong trong cơ sở dữ liệu

        public float Gia { get; set; }

        public float GiaGio { get; set; }

        public float DienTich { get; set; }

        public string DonViDT { get; set; }

        public string SucChuaToiDa { get; set; }

        public string GhiChu { get; set; }
    }
}
