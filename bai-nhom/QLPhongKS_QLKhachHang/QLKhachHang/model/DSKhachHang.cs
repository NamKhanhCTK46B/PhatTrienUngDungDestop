using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QLKhachHang
{
    internal class DSKhachHang
    {
        public List<KhachHang> dsKhachHang;
        private int nextID;

        public DSKhachHang() 
        {
            dsKhachHang = new List<KhachHang>();
            nextID = 1;
        }

        public KhachHang this[int index]
        {
            get { return dsKhachHang[index]; }
            set { dsKhachHang[index] = value; }
        }

        public void Them_KH_IDTuDong (KhachHang kh)
        {
            this.dsKhachHang.Add(kh);
            kh.ID_KH = nextID++;
        }

        public void Them_KH (KhachHang kh)
        {
            this.dsKhachHang.Add (kh);
        }

        public void Xoa (object obj, SoSanh ss)
        {
            int i = dsKhachHang.Count - 1;
            for (; i >= 0; i--) 
                if (ss(obj,this[i]) == 0)
                    this.dsKhachHang.RemoveAt(i);
        }

        public DSKhachHang Tim_KH(object obj, SoSanh ss)
        {
            DSKhachHang kq = null;
            foreach (KhachHang kh in dsKhachHang)
            {
                if (ss (obj,kh) == 0)
                {
                    kq.Them_KH(kh); 
                    break;
                }    
            }
            return kq;
        }

        public bool Sua_KH (KhachHang khSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.dsKhachHang.Count - 1;

            for ( i = 0; i < count; i++)
            {
                if (ss (obj, this[i]) == 0)
                {
                    this[i] = khSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void DocFile_XML (string path)
        {
            // Đưa nội dung của file vào XMLDocument instance
            var xmlDoc = new XmlDocument ();
            xmlDoc.Load (path);

            

            //Lấy danh sách các node trong node có tên KhachHang
            var nodeList = xmlDoc.DocumentElement.SelectNodes("/DanhSachKH/KhachHang");

            foreach (XmlNode node in nodeList)
            {
                KhachHang kh = new KhachHang();

                kh.TenKH = node.Attributes["TenKH"].Value;

                kh.GioiTinh = false;
                if (node.SelectSingleNode("GioiTinh").InnerText == "1")
                    kh.GioiTinh = true;

                kh.SDT = node.SelectSingleNode("SDT").InnerText;

                kh.NgaySinh = DateTime.ParseExact(node.SelectSingleNode("NgaySinh").InnerText,"dd/MM/yyyy",CultureInfo.InvariantCulture);

                kh.Email = node.SelectSingleNode("Email").InnerText;
                kh.SoCCCD = node.SelectSingleNode("SoCCCD").InnerText;
                string lkh = node.SelectSingleNode("LoaiKH").InnerText;
                kh.LoaiKH.TenLoai = lkh;
                kh.GhiChu = node.SelectSingleNode("GhiChu").InnerText;

                Them_KH_IDTuDong(kh);
            }
        }

        public void DocFile_Json (string path)
        {
            StreamReader sr = new StreamReader (path);
            string json = sr.ReadToEnd ();

            var arry = (JObject)JsonConvert.DeserializeObject (json);

            var khachhang = arry["khachhang"].Children();
            foreach (var kh in khachhang)
            {
                KhachHang k = new KhachHang();
                
                k.TenKH = kh["TenKH"].Value<string>();
                k.GioiTinh = false;
                if (kh["GioiTinh"].Value<string>() == "1")
                    k.GioiTinh = true;
                k.NgaySinh = DateTime.ParseExact(kh["NgaySinh"].Value<string>(),"dd/MM/yyyy",CultureInfo.InvariantCulture);
                k.SDT = kh["SDT"].Value<string> ();
                k.Email = kh["Email"].Value < string>();
                k.LoaiKH.TenLoai = kh["LoaiKH"].Value<string>();
                k.GhiChu = kh["GhiChu"].Value<string>();

                Them_KH_IDTuDong(k); 
            }
        }

    }
}
