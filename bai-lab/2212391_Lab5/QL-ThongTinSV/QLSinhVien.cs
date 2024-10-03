using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QL_ThongTinSV
{
    public delegate int SoSanh (object obj1, object obj2);
    internal class QLSinhVien
    {
        public List<SinhVien> DSSV;

        public QLSinhVien()
        {
            DSSV = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return DSSV[index]; }
            set { DSSV[index] = value; }
        }

        public void ThemSV (SinhVien sv)
        {
            this.DSSV.Add(sv);
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DSSV.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                    this.DSSV.RemoveAt(i);
            }
        }

        public SinhVien Tim1SV (object obj, SoSanh ss)
        {
            SinhVien kq = null;
            foreach (SinhVien sv in DSSV)
            {
                if (ss(obj,sv) == 0)
                {
                    kq = sv;
                    break;
                }
            }
            return kq;
        }

        public QLSinhVien TimDSSV (string mssv, string ten, string lop)
        {
            QLSinhVien kq = new QLSinhVien();
            foreach (SinhVien sv in DSSV)
            {
                if (
                      (string.IsNullOrEmpty(mssv) || sv.MSSV.Contains(mssv)) &&
                      (string.IsNullOrEmpty(ten) || sv.Ten.Contains(ten)) &&
                      (string.IsNullOrEmpty(lop) || sv.Lop.Contains(lop))
                   )
                    kq.ThemSV(sv);
            }
            return kq;
        }

        public bool Sua (SinhVien svSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DSSV.Count - 1;

            for (i = 0; i < count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        public void DocFile_TXT (string tenFile)
        {
            //string t;
            //string[] s;
            //SinhVien sv;
            //StreamReader sr = new StreamReader(new FileStream(tenFile, FileMode.Open));

            //while ((t = sr.ReadLine()) != null)
            //{
            //    s = t.Split('*');
            //    sv = new SinhVien();

            //    sv.MSSV = s[0];
            //    sv.HoTenLot = s[1];
            //    sv.Ten = s[2];
            //    sv.NgaySinh = DateTime.Parse(s[3]);
            //    sv.Lop = s[4];
            //    sv.SoCMND = s[5];
            //    sv.SDT = s[6];
            //    sv.DiaChi = s[7];
            //    sv.GioiTinh = false;
            //    if (s[8] == "1")
            //        sv.GioiTinh= true;
            //    string[] mondk = s[9].Split(',');
            //    foreach (string m in mondk)
            //        sv.MonHocDK.Add(m);

            //    this.ThemSV(sv);
            //}

            //sr.Close();

            using (StreamReader sr = new StreamReader(tenFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var s = line.Split('*');
                    SinhVien sv = new SinhVien
                    {
                        MSSV = s[0],
                        HoTenLot = s[1],
                        Ten = s[2],
                        NgaySinh = DateTime.ParseExact(s[3],"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Lop = s[4],
                        SoCMND = s[5],
                        SDT = s[6],
                        DiaChi = s[7],
                        GioiTinh = s[8] == "1",
                        MonHocDK = s[9].Split(',').ToList(),
                    };
                    ThemSV(sv);
                }
            }
            
        }

        public void GhiFile_TXT (string part)
        {
            using (StreamWriter wr = new StreamWriter(part))
            {
                foreach (SinhVien sv in DSSV)
                    wr.WriteLine(sv.ToString());
            }
        }

        public void DocFile_Json (string tenFile)
        {
            //Cách 1
            //StreamReader sr = new StreamReader(tenFile);
            //string json = sr.ReadToEnd();
            //var array = (JObject)JsonConvert.DeserializeObject(json);
            //var dssv = array["sinhvien"].Children();

            //foreach (var item in dssv)
            //{
            //    SinhVien sv = new SinhVien();
            //    sv.MSSV = item["mssv"].Value<string>();
            //    sv.HoTenLot = item["hotenlot"].Value<string>();
            //    sv.Ten = item["ten"].Value<string>();
            //    sv.NgaySinh = DateTime.Parse(item["ngaysinh"].Value<string>());
            //    sv.Lop = item["lop"].Value<string>();
            //    sv.SoCMND = item["socmnd"].Value<string>();
            //    sv.SDT = item["sdt"].Value<string>();
            //    sv.DiaChi = item["diachi"].Value<string>();
            //    sv.GioiTinh = item["gioitinh"].Value<bool>();

            //    var mon = item["monhocdk"].ToObject<List<string>>();
            //    sv.MonHocDK = mon;

            //    ThemSV(sv);
            //}

            //Cách 2 (phải ghi từ khoá trong file json trùng vói file VD: class:"MonHocKD" = json:"monhocdk")
            using (StreamReader reader = new StreamReader(tenFile))
            {
                string json = reader.ReadToEnd();
                dynamic arr = JsonConvert.DeserializeObject(json);

                var ds = arr["sinhvien"].ToObject<List<SinhVien>>();

                foreach (var sv in ds)
                    ThemSV(sv);
            }
        }

        public void GhiFile_Json(string path)
        {
            string json = JsonConvert.SerializeObject(DSSV);
            System.IO.File.WriteAllText(path, json);
        }

        public void DocFile_XML(string tenFile)
        {
            //var xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(tenFile);

            //var nodeList = xmlDoc.DocumentElement.SelectNodes("/dssinhvien/sinhvien");

            //foreach (XmlNode node in nodeList)
            //{
            //    SinhVien sv = new SinhVien();

            //    sv.MSSV = node.Attributes["mssv"].InnerText;
            //    sv.HoTenLot = node.SelectSingleNode("hotenlot").InnerText;
            //    sv.Ten = node.SelectSingleNode("ten").InnerText;
            //    sv.NgaySinh = DateTime.Parse(node.SelectSingleNode("ngaysinh").InnerText);
            //    sv.Lop = node.SelectSingleNode("lop").InnerText;
            //    sv.SoCMND = node.SelectSingleNode("socmnd").InnerText;
            //    sv.SDT = node.SelectSingleNode("sdt").InnerText;
            //    sv.DiaChi = node.SelectSingleNode("diachi").InnerText;
            //    sv.GioiTinh = false;
            //    if (node.SelectSingleNode("gioitinh").InnerText == "1")
            //        sv.GioiTinh = true;
            //    XmlNodeList mon = node.SelectNodes("monhocdk/mon");
            //    foreach (XmlNode m in mon)
            //    {
            //        sv.MonHocDK.Add(m.InnerText);
            //    }

            //    ThemSV(sv);
            //}

            XDocument xmlDoc = XDocument.Load(tenFile);

            var dssv = from sinhvien in xmlDoc.Descendants("sinhvien")
                       select new SinhVien
                       {
                           MSSV = (string)sinhvien.Element("mssv"),
                           HoTenLot = (string)sinhvien.Element("hotenlot"),
                           Ten = (string)sinhvien.Element("ten"),
                           NgaySinh = DateTime.Parse((string)sinhvien.Element("ngaysinh")),
                           Lop = (string)sinhvien.Element("lop"),
                           SoCMND = (string)sinhvien.Element("socmnd"),
                           SDT = (string)sinhvien.Element("sdt"),
                           DiaChi = (string)sinhvien.Element("diachi"),
                           GioiTinh = (string)sinhvien.Element("gioitinh") == "1",
                           MonHocDK = sinhvien.Element("monhocdk").Elements("mon").Select(mon => (string)mon).ToList()
                       };
            foreach (var sv in dssv)
            {
                ThemSV(sv);
            }
        }

        public void GhiFile_XML (string parth)
        {
            var serializer = new XmlSerializer(typeof(List<SinhVien>));
            using (var writer = new StreamWriter(parth))
            {
                serializer.Serialize(writer, DSSV, null);
                writer.Close();
            }    
        }
    }
}
