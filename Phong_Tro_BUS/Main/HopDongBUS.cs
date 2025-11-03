using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class HopDongBUS : IDisposable
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
                .Include(h => h.Phong)
                .Include(h => h.KhachThue)
                .Include(h => h.HoaDons)
                .AsNoTracking()
                .OrderByDescending(h => h.NgayBatDau)
                .ToList();
        }

        // ======== LẤY THEO MÃ ========
        public HopDong LayTheoMa(int maHopDong)
        {
            return db.HopDongs
                .Include(h => h.Phong)
                .Include(h => h.KhachThue)
                .Include(h => h.HoaDons)
                .AsNoTracking()
                .FirstOrDefault(h => h.MaHopDong == maHopDong);
        }

        // ======== LẤY HỢP ĐỒNG ĐANG HOẠT ĐỘNG THEO PHÒNG ========
        public HopDong LayHopDongDangHoatDongTheoPhong(string maPhong)
        {
            return db.HopDongs
                .Include(h => h.Phong)
                .Include(h => h.KhachThue)
                .Include(h => h.HoaDons)
                .AsNoTracking()
                .FirstOrDefault(h => h.MaPhong == maPhong && h.TrangThai == "Đang hoạt động");
        }

        // ======== THÊM ========
        public bool Them(HopDong hd)
        {
            if (hd == null) throw new ArgumentNullException(nameof(hd));

            bool tonTai = db.HopDongs.Any(h => h.MaPhong == hd.MaPhong && h.TrangThai == "Đang hoạt động");
            if (tonTai) throw new Exception($"Phòng {hd.MaPhong} đã có hợp đồng đang hoạt động!");

            hd.NgayBatDau = hd.NgayBatDau == default ? DateTime.Now : hd.NgayBatDau;
            if (hd.TrangThai == null)
                hd.TrangThai = "Đang hoạt động";
            db.HopDongs.Add(hd);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA ========
        public bool Sua(HopDong hd)
        {
            if (hd == null) throw new ArgumentNullException(nameof(hd));

            var old = db.HopDongs.Find(hd.MaHopDong);
            if (old == null) throw new Exception("Không tìm thấy hợp đồng để sửa!");

            db.Entry(old).CurrentValues.SetValues(hd);
            db.SaveChanges();
            return true;
        }

        // ======== XÓA ========
        public bool Xoa(int maHopDong)
        {
            var hd = db.HopDongs.Find(maHopDong);
            if (hd == null) throw new Exception("Không tìm thấy hợp đồng!");

            db.HopDongs.Remove(hd);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM ========
        public List<HopDong> TimKiem(string tuKhoa)
        {
            tuKhoa = tuKhoa?.Trim().ToLower();
            var query = db.HopDongs.Include(h => h.KhachThue)
                                    .Include(h => h.Phong)
                                    .AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(h =>
                    h.Phong.TenPhong.ToLower().Contains(tuKhoa) ||
                    h.KhachThue.Ten.ToLower().Contains(tuKhoa) ||
                    (!string.IsNullOrEmpty(h.TrangThai) && h.TrangThai.ToLower().Contains(tuKhoa)));
            }

            return query.AsNoTracking().ToList();
        }

        // ======== KẾT THÚC HỢP ĐỒNG ========
        public bool KetThucHopDong(int maHopDong)
        {
            var hd = db.HopDongs.Find(maHopDong);
            if (hd == null) throw new Exception("Không tìm thấy hợp đồng!");

            hd.TrangThai = "Đã kết thúc";
            hd.NgayKetThuc = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        // ======== GIẢI PHÓNG TÀI NGUYÊN ========
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
