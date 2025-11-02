using System;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class TaiKhoanBUS
    {
        private readonly Connect db;

        public TaiKhoanBUS()
        {
            db = new Connect();
        }

        // ======== Kiểm tra đăng nhập ========
        public TaiKhoan KiemTraDangNhap(string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // Kiểm tra trong DB
            var tk = db.TaiKhoans
                       .FirstOrDefault(t =>
                           t.TenDangNhap == username &&
                           t.MatKhau == password &&
                           t.LoaiTK == role
                       );

            return tk;
        }

        // ======== Thêm tài khoản mới (nếu cần) ========
        public bool Them(TaiKhoan tk)
        {
            if (tk == null)
                throw new ArgumentNullException(nameof(tk));

            if (db.TaiKhoans.Any(t => t.TenDangNhap == tk.TenDangNhap))
                throw new Exception("Tài khoản đã tồn tại!");

            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return true;
        }
        // Lấy lại mật khẩu theo TenDangNhap và Email
        public TaiKhoan LayLaiMatKhau(string tenDangNhap, string email)
        {
            return db.TaiKhoans
                     .FirstOrDefault(t =>
                         t.TenDangNhap == tenDangNhap &&
                         t.Email == email
                     );
        }
    }
}
