using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;
using System.Data.Entity;

namespace Phong_Tro_BUS
{
    public class TaiKhoanDB
    {
        private readonly Connect db = new Connect();

        // Đăng nhập: kiểm tra username và password
        public TaiKhoan Login(string username, string password)
        {
            return db.TaiKhoans
                     .FirstOrDefault(t => t.TenDangNhap == username && t.MatKhau == password);
        }

        // Đăng ký tài khoản mới
        public void Register(TaiKhoan tk)
        {
            // Kiểm tra trùng username
            var exists = db.TaiKhoans.Any(t => t.TenDangNhap == tk.TenDangNhap);
            if (exists)
                throw new Exception("Tên đăng nhập đã tồn tại!");

            tk.NgayTao = DateTime.Now;
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
        }

        // Đổi mật khẩu
        public void ChangePassword(int maTK, string newPassword)
        {
            var acc = db.TaiKhoans.Find(maTK);
            if (acc != null)
            {
                acc.MatKhau = newPassword;
                db.SaveChanges();
            }
        }

        // Lấy thông tin tài khoản theo ID
        public TaiKhoan GetById(int maTK)
        {
            return db.TaiKhoans.Find(maTK);
        }

        // Lấy tất cả tài khoản (chủ yếu dùng cho admin quản lý)
        public List<TaiKhoan> GetAll()
        {
            return db.TaiKhoans.ToList();
        }

        // Cập nhật thông tin tài khoản (Email, SDT, HoTen, ...)
        public void Update(TaiKhoan tk)
        {
            var existing = db.TaiKhoans.Find(tk.MaTK);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(tk);
                db.SaveChanges();
            }
        }

        // Xóa tài khoản (nếu cần)
        public void Delete(int maTK)
        {
            var acc = db.TaiKhoans.Find(maTK);
            if (acc != null)
            {
                db.TaiKhoans.Remove(acc);
                db.SaveChanges();
            }
        }
    }
}
