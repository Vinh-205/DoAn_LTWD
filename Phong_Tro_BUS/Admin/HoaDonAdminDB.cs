using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class HoaDonAdminDB
    {
        private readonly Connect db = new Connect();

        // Lấy toàn bộ danh sách hóa đơn
        public List<HoaDon> GetAll()
        {
            // Include để load luôn các bảng liên quan nếu cần hiển thị thông tin tổng hợp
            return db.HoaDons
                     .Include(h => h.HopDong)
                     .Include(h => h.ChiTietHoaDons)
                     .ToList();
        }

        // Lấy hóa đơn theo mã
        public HoaDon GetById(string maHD)
        {
            return db.HoaDons
                     .Include(h => h.HopDong)
                     .Include(h => h.ChiTietHoaDons)
                     .FirstOrDefault(h => h.MaHD == maHD);
        }

        // Thêm mới hóa đơn
        public void Add(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            db.SaveChanges();
        }

        // Cập nhật hóa đơn
        public void Update(HoaDon hd)
        {
            var existing = db.HoaDons.FirstOrDefault(x => x.MaHD == hd.MaHD);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(hd);
                db.SaveChanges();
            }
        }

        // Xóa hóa đơn
        public void Delete(string maHD)
        {
            var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);
            if (hd != null)
            {
                db.HoaDons.Remove(hd);
                db.SaveChanges();
            }
        }

        // Lấy danh sách hóa đơn theo tháng & năm (ví dụ để lọc báo cáo)
        public List<HoaDon> GetByMonthYear(int thang, int nam)
        {
            return db.HoaDons
                     .Where(x => x.Thang == thang && x.Nam == nam)
                     .Include(x => x.HopDong)
                     .ToList();
        }

        // Tính tổng doanh thu theo tháng
        public decimal GetTongDoanhThu(int thang, int nam)
        {
            return db.HoaDons
                     .Where(x => x.Thang == thang && x.Nam == nam && x.TongTien.HasValue)
                     .Sum(x => x.TongTien.Value);
        }
    }
}
