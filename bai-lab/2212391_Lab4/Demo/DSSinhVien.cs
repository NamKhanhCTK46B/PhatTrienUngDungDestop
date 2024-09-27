using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public delegate int SoSanh (object obj1,  object obj2);
    internal class DSSinhVien
    {
        public ArrayList DSSV;

        public DSSinhVien()
        {
            DSSV = new ArrayList();
        }

        public object this[int index]
        {
            get { return DSSV[index]; }
            set { DSSV[index] = value; }
        }


        public void Them_SV (SinhVien sv)
        {
            this.DSSV.Add (sv);
        }

        public void Xoa_SV (object obj, SoSanh ss)
        {
            int i = DSSV.Count - 1;
            for (; i >= 0; i--) 
                if (ss(obj, this[i]) == 0)
                    this.DSSV.RemoveAt (i);
        }

        public bool Sua (SinhVien svSua, object obj, SoSanh ss)
        {
            int i = 1, count;
            bool kq = false;
            count = this.DSSV.Count - 1;

            for (; i < count; i++)
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

        public SinhVien Tim_SV (object obj, SoSanh ss)
        {
            SinhVien kq = new SinhVien();

            foreach (SinhVien s in DSSV)
            {
                if (ss(obj,s) == 0)
                {
                    kq = s;
                    break;
                }    
            }

            return kq;
        }

        public void DocTuFile (string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader (new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {

            }    
        }
    }
}
