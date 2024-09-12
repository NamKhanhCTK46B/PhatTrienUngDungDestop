using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace QLKhachHang
{
    public delegate int SoSanh (object obj1, object obj2);
    internal class DSLoaiKH
    {
        public List <LoaiKH> dsLoaiKH;
        private int nextID;

        public DSLoaiKH ()
        {
            dsLoaiKH = new List <LoaiKH> ();
            nextID = 1;
        }

        public LoaiKH this[int index]
        {
            get { return dsLoaiKH[index]; }
            set { dsLoaiKH[index] = value; }
        }

        public void ThemLoaiKH (LoaiKH l)
        {
            this.dsLoaiKH.Add (l);
            l.ID_LoaiKH = nextID++;
        }

        public void XoaLoaiKH (object obj, SoSanh ss)
        {
            int i = dsLoaiKH.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.dsLoaiKH.RemoveAt (i);
        }

        public LoaiKH TimLoaiKH(object obj, SoSanh ss)
        {
            LoaiKH kq = null;
            foreach (LoaiKH l in dsLoaiKH)
                if (ss(obj, l) == 0)
                {
                    kq = l;
                    break;
                }
            return kq;
        }

        public bool Sua_LoaiKH (LoaiKH lSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;

            count = this.dsLoaiKH.Count - 1;

            for (i = 0; i < count; i++) 
            {
                //string id = this[i].ID_LoaiKH.ToString();
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = lSua;
                    kq = true;
                    break;
                }
            } 

            return kq;
        }

        public void DocFile_Json (string part)
        {
            StreamReader sr = new StreamReader(part);
            string json = sr.ReadToEnd();

            var array = (JObject)JsonConvert.DeserializeObject (json);

            var loai = array["loaikh"].Children();
            foreach (var l in loai)
            {
                string ten = l["TenLoai"].Value<string>();
                string gc = l["GhiChu"].Value<string>();

                LoaiKH loaiKH = new LoaiKH(ten, gc);
                ThemLoaiKH(loaiKH);
            }
        }


    }
}
