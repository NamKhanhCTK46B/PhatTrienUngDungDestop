using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TruyCapDuLieu.LopAnhXa;
using TruyCapDuLieu.LopTruyXuatDL;

namespace XuLy
{
    public class NhanVienBL
    {
        NhanVienDA nvDA = new NhanVienDA();

        public List<NhanVien> LayDSNhanVien()
        {
            return nvDA.LayDSNhanVien();
        }

        public NhanVien LayNhanVien_ID(int ID)
        {
            List<NhanVien> ds = LayDSNhanVien();

            foreach (NhanVien item in ds)
            {
                if (item.ID_NV == ID)
                    return item;
            }
            return null;
        }

        public List<NhanVien> TimKiem(string khoa)
        {
            List<NhanVien> ds = LayDSNhanVien();
            List<NhanVien> kq = new List<NhanVien>();

            foreach (NhanVien nv in ds)
            {
                if (nv.ID_NV.ToString().Contains(khoa)
                    || nv.TenNV.Contains(khoa)
                    || nv.SoCCCD.Contains(khoa)
                    || nv.GioiTinh.ToString().Contains(khoa)
                    || nv.NgaySinh.ToString("yyyy-MM-dd").Contains(khoa)
                    || nv.NgayVaoLam.ToString("yyyy-MM-dd").Contains(khoa)
                    || nv.SDT.Contains(khoa)
                    || nv.Email.Contains(khoa)
                    || nv.ID_VT.ToString().Contains(khoa)
                    || nv.TenDN.Contains(khoa)
                    || nv.GhiChu.Contains(khoa)
                    )
                    kq.Add(nv);
            }

            return kq;
        }

        public int Them(NhanVien nv)
        {
            return nvDA.Them_Xoa_Sua(nv, 0);
        }

        public int Sua(NhanVien nv)
        {
            return nvDA.Them_Xoa_Sua(nv, 1);
        }

        public int Xoa(NhanVien nv)
        {
            return nvDA.Them_Xoa_Sua(nv, 2);
        }

        // Phương thức mã hoá mật khẩu
        public string MaHoaMatKhau(string matkhau)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matkhau));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2")); //Chuyển chuỗi byte sang chuỗi hex
                }
                return sb.ToString();
            }
        }

        // Phương thức kiểm tra định dạng số điện thoại
        public bool KiemTraDinhDang_SDT(string sdt)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^(0|\+84)[1-9][0-9]{8}$");
        }

        // Phương thức kiểm tra định dạng email
        public bool KiemTraDinhDang_Email(string email)
        {
            try
            {
                var dc = new System.Net.Mail.MailAddress(email);
                return dc.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Phương thức kiểm tra có trùng nhân viên không
        public bool KiemTraTrungNhanVien(string cccd, string tendn, string email)
        {
            return nvDA.KiemTraTrungNhanVien(cccd, tendn, email);
        }

        
        // Phương thức này giúp kiểm tra thông tin đăng nhập
        public bool KiemTraTTDangNhap(string tenDN, string matKhau)
        {
            return nvDA.KiemTraTTDangNhap(tenDN, matKhau);
        }
    }
}
