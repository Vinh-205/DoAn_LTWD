using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class ThongKeBUS
    {
        private readonly Connect db;

        public ThongKeBUS()
        {
            db = new Connect();
        }

        // ====== Lấy danh sách phòng ======
        public List<PhongDTO> LayDanhSachPhong()
        {
            // Dùng DTO thay vì entity, và load trực tiếp từ bảng Phongs
            var list = db.Phongs
                         .AsNoTracking()
                         .Select(p => new PhongDTO
                         {
                             MaPhong = p.MaPhong,
                             TenPhong = p.TenPhong
                         })
                         .ToList();

            return list;
        }

        // ====== Doanh thu theo từng phòng trong tháng ======
        public List<DoanhThuPhong> DoanhThuTheoPhong(int thang, int nam)
        {
            // Load hóa đơn + HopDong + Phong, sau đó group theo mã phòng
            var hoaDonList = db.HoaDons
                               .Include(hd => hd.HopDong)
                               .AsNoTracking()
                               .Where(hd => hd.Thang == thang && hd.Nam == nam)
                               .ToList(); // ép EF load xong trước

            var result = hoaDonList
                         .GroupBy(hd => hd.HopDong?.MaPhong)
                         .Select(g => new DoanhThuPhong
                         {
                             MaPhong = g.Key,
                             TongTien = g.Sum(hd => hd.TongTien ?? 0)
                         })
                         .ToList();

            return result;
        }

        // ====== Doanh thu dịch vụ theo tháng ======
        public List<DoanhThuDichVu> DoanhThuDichVuTheoThang(int thang, int nam)
        {
            // Load dữ liệu trước, vì LINQ to Entities không hiểu group phức tạp với navigation
            var chiTietList = db.ChiTietHoaDons
                                .Include(ct => ct.HoaDon)
                                .Include(ct => ct.DichVu)
                                .AsNoTracking()
                                .Where(ct => ct.HoaDon.Thang == thang && ct.HoaDon.Nam == nam)
                                .ToList();

            var result = chiTietList
                         .GroupBy(ct => new { ct.MaDV, ct.DichVu.TenDV })
                         .Select(g => new DoanhThuDichVu
                         {
                             MaDV = g.Key.MaDV,
                             TenDV = g.Key.TenDV,
                             TongTien = g.Sum(ct => ct.ThanhTien ?? 0)
                         })
                         .ToList();

            return result;
        }
    }

    // ====== Các class DTO trung gian ======
    public class PhongDTO
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
    }

    public class DoanhThuPhong
    {
        public string MaPhong { get; set; }
        public decimal TongTien { get; set; }
    }

    public class DoanhThuDichVu
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal TongTien { get; set; }
    }
}
