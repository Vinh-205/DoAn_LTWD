using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.User
{
    public class KhachThueDB
    {
        private readonly Connect db = new Connect();

        // Lấy danh sách toàn bộ khách thuê (hiếm khi dùng bên User, chủ yếu dùng Admin)
        public List<KhachThue> GetAll()
        {
            return db.KhachThues.ToList();
        }

        // Lấy thông tin khách thuê theo ID
        public KhachThue GetById(int maKhach)
        {
            return db.KhachThues
                     .Include(k => k.HopDongs)
                     .FirstOrDefault(k => k.MaKhach == maKhach);
        }

        // Cập nhật thông tin hồ sơ cá nhân
        public void Update(KhachThue updatedKhach)
        {
            var existingKhach = db.KhachThues.Find(updatedKhach.MaKhach);
            if (existingKhach != null)
            {
                db.Entry(existingKhach).CurrentValues.SetValues(updatedKhach);
                db.SaveChanges();
            }
        }

        // Tìm kiếm khách thuê theo tên (phục vụ tra cứu hoặc filter trong danh sách)
        public List<KhachThue> SearchByName(string keyword)
        {
            return db.KhachThues
                     .Where(k => k.Ten.Contains(keyword))
                     .ToList();
        }

        // Thêm mới khách thuê (nếu có đăng ký từ ngoài)
        public void Add(KhachThue kh)
        {
            db.KhachThues.Add(kh);
            db.SaveChanges();
        }

        // Xóa khách thuê (chỉ dùng nếu hệ thống cho phép xoá – thường hạn chế)
        public void Delete(int maKhach)
        {
            var kh = db.KhachThues.Find(maKhach);
            if (kh != null)
            {
                db.KhachThues.Remove(kh);
                db.SaveChanges();
            }
        }
    }
}
