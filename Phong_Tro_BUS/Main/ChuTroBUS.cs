using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class ChuTroBUS
    {
        private readonly Connect db;

        public ChuTroBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ ========
        public List<ChuTro> LayTatCa()
        {
            return db.ChuTro
                     .Include(c => c.Phongs)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ CHỦ ========
        public ChuTro LayTheoMa(int maChu)
        {
            return db.ChuTro
                     .Include(c => c.Phongs)
                     .AsNoTracking()
                     .FirstOrDefault(c => c.MaChu == maChu);
        }

        // ======== THÊM ========
        public bool Them(ChuTro chu)
        {
            if (chu == null)
                throw new ArgumentNullException(nameof(chu));

            db.ChuTro.Add(chu);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA ========
        public bool Sua(ChuTro chu)
        {
            if (chu == null)
                throw new ArgumentNullException(nameof(chu));

            var existing = db.ChuTro.Find(chu.MaChu);
            if (existing == null)
                throw new Exception("Không tìm thấy chủ trọ để cập nhật!");

            existing.Ten = chu.Ten;
            existing.Email = chu.Email;
            existing.SDT = chu.SDT;
            existing.Role = chu.Role;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA ========
        public bool Xoa(int maChu)
        {
            var chu = db.ChuTro.Find(maChu);
            if (chu == null)
                throw new Exception("Không tìm thấy chủ trọ để xóa!");

            db.ChuTro.Remove(chu);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM ========
        public List<ChuTro> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.ChuTro
                     .Where(c => c.Ten.Contains(tuKhoa) || c.Email.Contains(tuKhoa) || c.SDT.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }
    }
}
