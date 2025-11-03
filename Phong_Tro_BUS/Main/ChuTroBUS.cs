using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class ChuTroBUS : IDisposable
    {
        private readonly Connect db;

        public ChuTroBUS()
        {
            db = new Connect();
        }

        // =================== 1️⃣ LẤY TẤT CẢ ===================
        public List<ChuTro> LayTatCa()
        {
            return db.ChuTroes
                     .AsNoTracking()
                     .OrderBy(c => c.Ten)
                     .ToList();
        }

        // =================== 2️⃣ LẤY THEO MÃ ===================
        public ChuTro LayTheoMa(int maChuTro)
        {
            return db.ChuTroes
                     .AsNoTracking()
                     .FirstOrDefault(c => c.MaChuTro == maChuTro);
        }

        // =================== 3️⃣ THÊM MỚI ===================
        public bool Them(ChuTro chu)
        {
            if (chu == null)
                throw new ArgumentNullException(nameof(chu), "Dữ liệu chủ trọ không hợp lệ!");

            // Kiểm tra trùng email hoặc số điện thoại
            bool tonTai = db.ChuTroes.Any(c =>
                c.Email == chu.Email || c.SDT == chu.SDT);

            if (tonTai)
                throw new Exception("Email hoặc số điện thoại đã tồn tại!");

            db.ChuTroes.Add(chu);
            db.SaveChanges();
            return true;
        }

        // =================== 4️⃣ CẬP NHẬT ===================
        public bool Sua(ChuTro chu)
        {
            if (chu == null)
                throw new ArgumentNullException(nameof(chu), "Dữ liệu cập nhật không hợp lệ!");

            var existing = db.ChuTroes.Find(chu.MaChuTro);
            if (existing == null)
                throw new Exception("Không tìm thấy chủ trọ để cập nhật!");

            // Kiểm tra trùng email/sđt (trừ chính nó)
            bool trung = db.ChuTroes.Any(c =>
                (c.Email == chu.Email || c.SDT == chu.SDT) &&
                c.MaChuTro != chu.MaChuTro);

            if (trung)
                throw new Exception("Email hoặc số điện thoại đã tồn tại!");

            existing.Ten = chu.Ten;
            existing.Email = chu.Email;
            existing.SDT = chu.SDT;
            existing.Role = chu.Role;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // =================== 5️⃣ XÓA ===================
        public bool Xoa(int maChuTro)
        {
            var chu = db.ChuTroes.Find(maChuTro);
            if (chu == null)
                throw new Exception("Không tìm thấy chủ trọ để xóa!");

            db.ChuTroes.Remove(chu);
            db.SaveChanges();
            return true;
        }

        // =================== 6️⃣ TÌM KIẾM ===================
        public List<ChuTro> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            tuKhoa = tuKhoa.Trim().ToLower();

            return db.ChuTroes
                     .AsNoTracking()
                     .Where(c => c.Ten.ToLower().Contains(tuKhoa) ||
                                 (c.Email != null && c.Email.ToLower().Contains(tuKhoa)) ||
                                 (c.SDT != null && c.SDT.Contains(tuKhoa)) ||
                                 (c.Role != null && c.Role.ToLower().Contains(tuKhoa)))
                     .OrderBy(c => c.Ten)
                     .ToList();
        }

        // =================== 7️⃣ HỦY (Dispose) ===================
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
