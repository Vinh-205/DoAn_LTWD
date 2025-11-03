using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.PhongTro;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class HopDongBUS
    {
        private readonly Connect db;

        public HopDongBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ HỢP ĐỒNG ========
        public List<HopDong> LayTatCa()
        {
            return db.HopDongs
                     .Include(hd => hd.Phong)
                     .Include(hd => hd.KhachThue)
                     .Include(hd => hd.HoaDons)
                     .AsNoTracking()
                     .OrderByDescending(hd => hd.NgayBatDau)
                     .ToList();
        }

        // ======== LẤY THEO MÃ HỢP ĐỒNG ========
        public HopDong LayTheoMa(int maHopDong)
        {
            return db.HopDongs
                     .Include(hd => hd.Phong)
                     .Include(hd => hd.KhachThue)
                     .Include(hd => hd.HoaDons)
                     .AsNoTracking()
                     .FirstOrDefault(hd => hd.MaHopDong == maHopDong);
        }

        // ======== THÊM HỢP ĐỒNG ========
        public bool Them(HopDong hd)
        {
            if (hd == null)
                throw new ArgumentNullException(nameof(hd));

            // Kiểm tra phòng đã có hợp đồng đang hoạt động
            bool daCoHopDong = db.HopDongs.Any(x => x.MaPhong == hd.MaPhong && x.TrangThai == "Đang hoạt động");
            if (daCoHopDong)
                throw new Exception($"❌ Phòng {hd.MaPhong} đã có hợp đồng đang hoạt động!");

            if (hd.NgayBatDau == default)
                hd.NgayBatDau = DateTime.Now;

            hd.TrangThai ??= "Đang hoạt động";

            db.HopDongs.Add(hd);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA HỢP ĐỒNG ========
        public bool Sua(HopDong hd)
        {
            if (hd == null)
                throw new ArgumentNullException(nameof(hd));

            var existing = db.HopDongs.Find(hd.MaHopDong);
            if (existing == null)
                throw new Exception("❌ Không tìm thấy hợp đồng để cập nhật!");

            existing.MaPhong = hd.MaPhong;
            existing.MaKhach = hd.MaKhach;
            existing.NgayBatDau = hd.NgayBatDau;
            existing.NgayKetThuc = hd.NgayKetThuc;
            existing.TienCoc = hd.TienCoc;
            existing.TienThue = hd.TienThue;
            existing.TrangThai = hd.TrangThai;
            existing.GhiChu = hd.GhiChu;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA HỢP ĐỒNG ========
        public bool Xoa(int maHopDong)
        {
            var hd = db.HopDongs.Find(maHopDong);
            if (hd == null)
                throw new Exception("❌ Không tìm thấy hợp đồng để xóa!");

            db.HopDongs.Remove(hd);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM HỢP ĐỒNG ========
        public List<HopDong> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            tuKhoa = tuKhoa.Trim().ToLower();

            return db.HopDongs
                     .Where(hd =>
                         (hd.MaPhong != null && hd.MaPhong.ToLower().Contains(tuKhoa)) ||
                         (hd.TrangThai != null && hd.TrangThai.ToLower().Contains(tuKhoa)) ||
                         (hd.GhiChu != null && hd.GhiChu.ToLower().Contains(tuKhoa)) ||
                         (hd.KhachThue.TenKhach != null && hd.KhachThue.TenKhach.ToLower().Contains(tuKhoa))
                     )
                     .Include(hd => hd.KhachThue)
                     .Include(hd => hd.Phong)
                     .AsNoTracking()
                     .OrderByDescending(hd => hd.NgayBatDau)
                     .ToList();
        }

        // ======== LẤY DANH SÁCH HỢP ĐỒNG ĐANG HOẠT ĐỘNG ========
        public List<HopDong> LayHopDongDangHoatDong()
        {
            return db.HopDongs
                     .Where(hd => hd.TrangThai == "Đang hoạt động")
                     .Include(hd => hd.Phong)
                     .Include(hd => hd.KhachThue)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== KIỂM TRA PHÒNG CÓ HỢP ĐỒNG ĐANG THUÊ KHÔNG ========
        public bool PhongDangCoHopDong(string maPhong)
        {
            return db.HopDongs.Any(hd => hd.MaPhong == maPhong && hd.TrangThai == "Đang hoạt động");
        }

        // ======== KẾT THÚC HỢP ĐỒNG ========
        public bool KetThucHopDong(int maHopDong)
        {
            var hd = db.HopDongs.Find(maHopDong);
            if (hd == null)
                throw new Exception("❌ Không tìm thấy hợp đồng để kết thúc!");

            hd.TrangThai = "Đã kết thúc";
            hd.NgayKetThuc = DateTime.Now;

            db.Entry(hd).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
