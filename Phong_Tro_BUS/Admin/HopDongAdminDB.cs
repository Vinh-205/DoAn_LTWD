using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class HopDongAdminDB
    {
        private readonly Connect db = new Connect();

        // Lấy toàn bộ danh sách hợp đồng
        public List<HopDong> GetAll()
        {
            return db.HopDongs
                     .Include(h => h.Phong)
                     .Include(h => h.KhachThue)
                     .Include(h => h.HoaDons)
                     .ToList();
        }

        // Lấy hợp đồng theo mã
        public HopDong GetById(int maHopDong)
        {
            return db.HopDongs
                     .Include(h => h.Phong)
                     .Include(h => h.KhachThue)
                     .FirstOrDefault(h => h.MaHopDong == maHopDong);
        }

        // Thêm hợp đồng mới
        public void Add(HopDong hd)
        {
            db.HopDongs.Add(hd);
            db.SaveChanges();
        }

        // Cập nhật hợp đồng
        public void Update(HopDong hd)
        {
            var old = db.HopDongs.FirstOrDefault(x => x.MaHopDong == hd.MaHopDong);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(hd);
                db.SaveChanges();
            }
        }

        // Xóa hợp đồng
        public void Delete(int maHopDong)
        {
            var hd = db.HopDongs.FirstOrDefault(x => x.MaHopDong == maHopDong);
            if (hd != null)
            {
                db.HopDongs.Remove(hd);
                db.SaveChanges();
            }
        }

        // Lấy danh sách hợp đồng đang hoạt động
        public List<HopDong> GetActive()
        {
            return db.HopDongs
                     .Where(h => h.TrangThai == "Đang hoạt động")
                     .Include(h => h.Phong)
                     .Include(h => h.KhachThue)
                     .ToList();
        }

        // Lấy danh sách hợp đồng sắp hết hạn (ví dụ trong vòng 7 ngày)
        public List<HopDong> GetExpiredSoon()
        {
            DateTime today = DateTime.Today;
            DateTime warningDate = today.AddDays(7);
            return db.HopDongs
                     .Where(h => h.NgayKetThuc.HasValue &&
                                 DbFunctions.TruncateTime(h.NgayKetThuc) <= warningDate &&
                                 h.TrangThai == "Đang hoạt động")
                     .Include(h => h.KhachThue)
                     .Include(h => h.Phong)
                     .ToList();
        }

        // Lấy hợp đồng theo khách thuê
        public List<HopDong> GetByKhach(int maKhach)
        {
            return db.HopDongs
                     .Where(h => h.MaKhach == maKhach)
                     .Include(h => h.Phong)
                     .Include(h => h.KhachThue)
                     .ToList();
        }

        // Đếm số hợp đồng đang hoạt động
        public int CountActive()
        {
            return db.HopDongs.Count(h => h.TrangThai == "Đang hoạt động");
        }
    }
}
