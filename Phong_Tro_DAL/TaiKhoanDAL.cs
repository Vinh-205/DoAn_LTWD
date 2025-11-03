using System;
using System.Linq;
using System.Data.Entity;
namespace Phong_Tro_DAL.PhongTro
{
    public class TaiKhoanDAL
    {
        private readonly Connect db;

        public TaiKhoanDAL()
        {
            db = new Connect();
        }

        public TaiKhoan DangNhap(string username, string password, string role)
        {
            return db.TaiKhoans.FirstOrDefault(t =>
                t.TenDangNhap == username &&
                t.MatKhau == password &&
                t.LoaiTK == role);
        }

        public bool Them(TaiKhoan tk)
        {
            if (db.TaiKhoans.Any(t => t.TenDangNhap == tk.TenDangNhap))
                throw new Exception("Tài khoản đã tồn tại!");

            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return true;
        }

        public TaiKhoan LayTheoTenVaEmail(string tenDangNhap, string email)
        {
            return db.TaiKhoans.FirstOrDefault(t =>
                t.TenDangNhap == tenDangNhap &&
                t.Email == email);
        }

        public void CapNhatMatKhau(TaiKhoan taiKhoan)
        {
            var tk = db.TaiKhoans.FirstOrDefault(t => t.MaTK == taiKhoan.MaTK);
            if (tk != null)
            {
                tk.MatKhau = taiKhoan.MatKhau;
                db.SaveChanges();
            }
        }
    }
}
