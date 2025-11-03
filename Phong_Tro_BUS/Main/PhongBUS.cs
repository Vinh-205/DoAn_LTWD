using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class PhongBUS : IDisposable
    {
        private readonly Connect db;

        public PhongBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ PHÒNG ========
        public List<Phong> LayTatCa()
        {
            return db.Phongs
                .Include(p => p.ChiTietTienIches)
                .Include(p => p.HopDongs)
                .Include(p => p.ThuePhongs)
                .AsNoTracking()
                .ToList();
        }

        // ======== LẤY THEO MÃ PHÒNG ========
        public Phong LayTheoMa(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                throw new ArgumentException("Mã phòng không hợp lệ!", nameof(maPhong));

            return db.Phongs
                .Include(p => p.ChiTietTienIches)
                .Include(p => p.HopDongs)
                .Include(p => p.ThuePhongs)
                .AsNoTracking()
                .FirstOrDefault(p => p.MaPhong == maPhong);
        }

        // ======== THÊM PHÒNG ========
        public bool Them(Phong phong)
        {
            if (phong == null)
                throw new ArgumentNullException(nameof(phong));

            if (db.Phongs.Any(p => p.MaPhong == phong.MaPhong))
                throw new Exception("Mã phòng đã tồn tại!");

            db.Phongs.Add(phong);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA PHÒNG ========
        public bool Sua(Phong phong)
        {
            if (phong == null)
                throw new ArgumentNullException(nameof(phong));

            var existing = db.Phongs.Find(phong.MaPhong);
            if (existing == null)
                throw new Exception("Không tìm thấy phòng để cập nhật!");

            existing.TenPhong = phong.TenPhong;
            existing.GiaPhong = phong.GiaPhong;
            existing.TrangThai = phong.TrangThai;
            existing.MoTa = phong.MoTa;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA PHÒNG ========
        public bool Xoa(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                throw new ArgumentException("Mã phòng không hợp lệ!", nameof(maPhong));

            var phong = db.Phongs.Find(maPhong);
            if (phong == null)
                throw new Exception("Không tìm thấy phòng để xóa!");

            db.Phongs.Remove(phong);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM PHÒNG ========
        public List<Phong> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.Phongs
                .Where(p => p.TenPhong.Contains(tuKhoa)
                         || p.TrangThai.Contains(tuKhoa)
                         || p.MoTa.Contains(tuKhoa))
                .AsNoTracking()
                .ToList();
        }

        // ======== GIẢI PHÓNG TÀI NGUYÊN ========
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
