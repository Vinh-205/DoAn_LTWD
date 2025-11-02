using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class KhachThueBUS
    {
        private readonly Connect db;

        public KhachThueBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ KHÁCH THUÊ ========
        public List<KhachThue> LayTatCa()
        {
            return db.KhachThues
                     .Include(k => k.HopDongs)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ KHÁCH ========
        public KhachThue LayTheoMa(int maKhach)
        {
            return db.KhachThues
                     .Include(k => k.HopDongs)
                     .AsNoTracking()
                     .FirstOrDefault(k => k.MaKhach == maKhach);
        }

        // ======== THÊM KHÁCH THUÊ ========
        public bool Them(KhachThue kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh));

            db.KhachThues.Add(kh);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA KHÁCH THUÊ ========
        public bool Sua(KhachThue kh)
        {
            if (kh == null)
                throw new ArgumentNullException(nameof(kh));

            var existing = db.KhachThues.Find(kh.MaKhach);
            if (existing == null)
                throw new Exception("Không tìm thấy khách thuê để cập nhật!");

            existing.Ten = kh.Ten;
            existing.SDT = kh.SDT;
            existing.Email = kh.Email;
            existing.CCCD = kh.CCCD;
            existing.NgaySinh = kh.NgaySinh;
            existing.DiaChi = kh.DiaChi;
            existing.Avatar = kh.Avatar;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA KHÁCH THUÊ ========
        public bool Xoa(int maKhach)
        {
            var kh = db.KhachThues.Find(maKhach);
            if (kh == null)
                throw new Exception("Không tìm thấy khách thuê để xóa!");

            db.KhachThues.Remove(kh);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM KHÁCH THUÊ ========
        public List<KhachThue> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.KhachThues
                     .Where(k => k.Ten.Contains(tuKhoa) ||
                                 k.SDT.Contains(tuKhoa) ||
                                 k.Email.Contains(tuKhoa) ||
                                 k.CCCD.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }
    }
}
