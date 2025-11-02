using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class ThongBaoBUS
    {
        private readonly Connect db;

        public ThongBaoBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ THÔNG BÁO ========
        public List<ThongBao> LayTatCa()
        {
            return db.ThongBaos
                     .Include(tb => tb.HopDong)
                     .Include(tb => tb.Phong)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ THÔNG BÁO ========
        public ThongBao LayTheoMa(int maTB)
        {
            return db.ThongBaos
                     .Include(tb => tb.HopDong)
                     .Include(tb => tb.Phong)
                     .AsNoTracking()
                     .FirstOrDefault(tb => tb.MaTB == maTB);
        }

        // ======== THÊM THÔNG BÁO ========
        public bool Them(ThongBao tb)
        {
            if (tb == null)
                throw new ArgumentNullException(nameof(tb));

            tb.NgayTao = tb.NgayTao ?? DateTime.Now;

            db.ThongBaos.Add(tb);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA THÔNG BÁO ========
        public bool Sua(ThongBao tb)
        {
            if (tb == null)
                throw new ArgumentNullException(nameof(tb));

            var existing = db.ThongBaos.Find(tb.MaTB);
            if (existing == null)
                throw new Exception("Không tìm thấy thông báo để cập nhật!");

            existing.MaHopDong = tb.MaHopDong;
            existing.MaPhong = tb.MaPhong;
            existing.NoiDung = tb.NoiDung;
            existing.NgayTao = tb.NgayTao ?? existing.NgayTao;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA THÔNG BÁO ========
        public bool Xoa(int maTB)
        {
            var tb = db.ThongBaos.Find(maTB);
            if (tb == null)
                throw new Exception("Không tìm thấy thông báo để xóa!");

            db.ThongBaos.Remove(tb);
            db.SaveChanges();
            return true;
        }
        // ======== LẤY DANH SÁCH PHÒNG ========
        public List<Phong> LayDanhSachPhong()
        {
            using (var db = new Connect())
            {
                return db.Phongs
                         .AsNoTracking()
                         .ToList();
            }
        }


        // ======== TÌM KIẾM THEO NỘI DUNG ========
        public List<ThongBao> TimKiem(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return LayTatCa();

            return db.ThongBaos
                     .Where(tb => tb.NoiDung.Contains(keyword))
                     .Include(tb => tb.HopDong)
                     .Include(tb => tb.Phong)
                     .AsNoTracking()
                     .ToList();
        }
    }
}
