using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ListStudent lst;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDocFileJson_Click(object sender, EventArgs e)
        {
            lst = new ListStudent();
            string str = "";
            string Path = "JSONExample.json"; 

            lst.LoadJson(Path);
            int i = 0;

            foreach (StudentInfo st in lst.listStudent)
            {
                i++;
                StudentInfo s = st;
                str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}, điểm TB: {3}\r\n", i, s.MSSV, s.Hoten, s.Diem);
            }
            MessageBox.Show(str);
        }
    }
}
