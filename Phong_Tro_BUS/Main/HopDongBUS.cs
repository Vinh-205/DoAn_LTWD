using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
                     .Include(hd => hd.ThongBaos)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ HỢP ĐỒNG ========
        public HopDong LayTheoMa(int maHopDong)
        {
            return db.HopDongs
                     .Include(hd => hd.Phong)
                     .Include(hd => hd.KhachThue)
                     .Include(hd => hd.HoaDons)
                     .Include(hd => hd.ThongBaos)
                     .AsNoTracking()
                     .FirstOrDefault(hd => hd.MaHopDong == maHopDong);
        }

        // ======== THÊM HỢP ĐỒNG ========
        public bool Them(HopDong hd)
        {
            if (hd == null)
                throw new ArgumentNullException(nameof(hd));

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
                throw new Exception("Không tìm thấy hợp đồng để cập nhật!");

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
                throw new Exception("Không tìm thấy hợp đồng để xóa!");

            db.HopDongs.Remove(hd);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM HỢP ĐỒNG ========
        public List<HopDong> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.HopDongs
                     .Where(hd => hd.MaPhong.Contains(tuKhoa) ||
                                  hd.TrangThai.Contains(tuKhoa) ||
                                  hd.GhiChu.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }
    }
}
