using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.User
{
    public class HoaDonUserDB
    {
        private readonly Connect db = new Connect();

        // Lấy toàn bộ hóa đơn của khách theo mã khách thuê
        public List<HoaDon> GetAllByKhach(int maKhach)
        {
            return db.HoaDons
                     .Include(h => h.HopDong)
                     .Include(h => h.HopDong.Phong)
                     .Where(h => h.HopDong.MaKhach == maKhach)
                     .OrderByDescending(h => h.Nam)
                     .ThenByDescending(h => h.Thang)
                     .ToList();
        }

        // Lấy chi tiết 1 hóa đơn cụ thể
        public HoaDon GetById(string maHD)
        {
            return db.HoaDons
                     .Include(h => h.HopDong)
                     .Include(h => h.HopDong.Phong)
                     .Include(h => h.ChiTietHoaDons.Select(c => c.DichVu))
                     .FirstOrDefault(h => h.MaHD == maHD);
        }

        // Lọc hóa đơn theo tháng/năm (cho chức năng xem nhanh)
        public List<HoaDon> GetByMonthYear(int maKhach, int thang, int nam)
        {
            return db.HoaDons
                     .Include(h => h.HopDong)
                     .Include(h => h.HopDong.Phong)
                     .Where(h => h.HopDong.MaKhach == maKhach &&
                                 h.Thang == thang &&
                                 h.Nam == nam)
                     .ToList();
        }

        // Tính tổng tiền hóa đơn theo khách (ví dụ: thống kê chi tiêu)
        public decimal GetTongTienByKhach(int maKhach)
        {
            return db.HoaDons
                     .Where(h => h.HopDong.MaKhach == maKhach)
                     .Sum(h => h.TongTien ?? 0);
        }
    }
}
