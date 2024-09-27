using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ListStudent
    {
        public List<StudentInfo> listStudent;

        public ListStudent ()
        {
            listStudent = new List<StudentInfo> ();
        }

        public List<StudentInfo> LoadJson(string path)
        {

            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();

            var array = (JObject)JsonConvert.DeserializeObject(json);
            var students = array["sinhvien"].Children();
            foreach (var item in students) // Duyệt mảng
            {
                // Lấy các thành phần
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                // Chuyển vào đối tượng StudentInfo
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem,
                tongiao);
                listStudent.Add(info);// Thêm vào danh sách
            }

            return listStudent;
        }
    }
}
