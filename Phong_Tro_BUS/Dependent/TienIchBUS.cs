using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;
using System.Data.Entity;

namespace Phong_Tro_BUS
{
    public class TienIchBUS
    {
        private readonly Connect db;

        public TienIchBUS()
        {
            db = new Connect();
        }

        // ======== LẤY DANH SÁCH ========
        public List<TienIch> LayTatCa()
        {
            return db.TienIches.AsNoTracking().ToList();
        }

        // ======== THÊM ========
        public bool Them(TienIch ti)
        {
            if (ti == null)
                throw new ArgumentNullException(nameof(ti));

            // Kiểm tra trùng tên tiện ích
            bool tonTai = db.TienIches.Any(x => x.TenTienIch == ti.TenTienIch);
            if (tonTai)
                throw new Exception("Tên tiện ích đã tồn tại!");

            db.TienIches.Add(ti);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA ========
        public bool Sua(TienIch ti)
        {
            if (ti == null)
                throw new ArgumentNullException(nameof(ti));

            var existing = db.TienIches.Find(ti.MaTienIch);
            if (existing == null)
                throw new Exception("Không tìm thấy tiện ích để cập nhật!");

            existing.TenTienIch = ti.TenTienIch;
            existing.DonGia = ti.DonGia;
            existing.MoTa = ti.MoTa;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA ========
        public bool Xoa(int maTienIch)
        {
            var ti = db.TienIches.Find(maTienIch);
            if (ti == null)
                throw new Exception("Không tìm thấy tiện ích cần xóa!");

            db.TienIches.Remove(ti);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM ========
        public List<TienIch> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.TienIches
                     .Where(x => x.TenTienIch.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ ========
        public TienIch LayTheoMa(int maTienIch)
        {
            return db.TienIches.AsNoTracking().FirstOrDefault(x => x.MaTienIch == maTienIch);
        }
    }
}
