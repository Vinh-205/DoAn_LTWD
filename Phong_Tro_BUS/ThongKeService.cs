using System;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Services
{
    public class ThongKeBUS
    {
        /// <summary>
        /// Tính tổng doanh thu của một tháng và năm.
        /// </summary>
        public decimal TongDoanhThuThang(int thang, int nam)
        {
            using (var db = new Connect())
            {
                // Nếu đã có cột TongTien trong HoaDon → không cần join ChiTietHoaDon
                return db.HoaDons
                    .Where(h => h.Thang == thang && h.Nam == nam)
                    .Sum(h => (decimal?)h.TongTien) ?? 0m;
            }
        }

        /// <summary>
        /// Tính tổng doanh thu của một năm (tùy chọn thêm).
        /// </summary>
        public decimal TongDoanhThuNam(int nam)
        {
            using (var db = new Connect())
            {
                return db.HoaDons
                    .Where(h => h.Nam == nam)
                    .Sum(h => (decimal?)h.TongTien) ?? 0m;
            }
        }
    }
}
