using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;
using System.Data.Entity;

namespace Phong_Tro_BUS.Shared
{
    public class ThongBaoDB
    {
        private readonly Connect db = new Connect();

        // ========== Dùng chung cho cả Admin & User ==========

        // Lấy tất cả thông báo (Admin)
        public List<ThongBao> GetAll()
        {
            return db.ThongBaos
                     .OrderByDescending(t => t.NgayTao)
                     .ToList();
        }

        // Lấy thông báo theo phòng (User)
        public List<ThongBao> GetByMaPhong(string maPhong)
        {
            return db.ThongBaos
                     .Where(t => t.MaPhong == maPhong)
                     .OrderByDescending(t => t.NgayTao)
                     .ToList();
        }

        // Lấy thông báo theo hợp đồng (User)
        public List<ThongBao> GetByMaHopDong(int maHopDong)
        {
            return db.ThongBaos
                     .Where(t => t.MaHopDong == maHopDong)
                     .OrderByDescending(t => t.NgayTao)
                     .ToList();
        }

        // Lấy chi tiết thông báo (Admin/User)
        public ThongBao GetById(int maTB)
        {
            return db.ThongBaos.Find(maTB);
        }

        // Thêm thông báo (Admin hoặc hệ thống)
        public void Add(string noiDung, int? maHopDong = null, string maPhong = null)
        {
            var tb = new ThongBao
            {
                NoiDung = noiDung,
                MaHopDong = maHopDong,
                MaPhong = maPhong,
                NgayTao = DateTime.Now
            };

            db.ThongBaos.Add(tb);
            db.SaveChanges();
        }

        // Cập nhật thông báo (Admin)
        public void Update(ThongBao tb)
        {
            var old = db.ThongBaos.Find(tb.MaTB);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(tb);
                db.SaveChanges();
            }
        }

        // Xóa thông báo (Admin)
        public void Delete(int maTB)
        {
            var tb = db.ThongBaos.Find(maTB);
            if (tb != null)
            {
                db.ThongBaos.Remove(tb);
                db.SaveChanges();
            }
        }
    }
}
