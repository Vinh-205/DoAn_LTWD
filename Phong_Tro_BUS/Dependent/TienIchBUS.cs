using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class TienIchBUS : IDisposable
    {
        private readonly Connect db;

        public TienIchBUS()
        {
            db = new Connect();
        }

        // =================== 1️⃣ LẤY TẤT CẢ ===================
        public List<TienIch> LayTatCa()
        {
            return db.TienIches.AsNoTracking().ToList();
        }

        // =================== 2️⃣ THÊM ===================
        public bool Them(TienIch ti)
        {
            if (ti == null)
                throw new ArgumentNullException(nameof(ti), "Dữ liệu tiện ích không hợp lệ!");

            // Kiểm tra trùng tên
            bool tonTai = db.TienIches.Any(x => x.TenTienIch.Trim().ToLower() == ti.TenTienIch.Trim().ToLower());
            if (tonTai)
                throw new Exception("Tên tiện ích đã tồn tại!");

            db.TienIches.Add(ti);
            db.SaveChanges();
            return true;
        }

        // =================== 3️⃣ SỬA ===================
        public bool Sua(TienIch ti)
        {
            if (ti == null)
                throw new ArgumentNullException(nameof(ti), "Dữ liệu cập nhật không hợp lệ!");

            var existing = db.TienIches.Find(ti.MaTienIch);
            if (existing == null)
                throw new Exception("Không tìm thấy tiện ích để cập nhật!");

            // Kiểm tra trùng tên (trừ chính nó)
            bool trungTen = db.TienIches.Any(x =>
                x.TenTienIch.Trim().ToLower() == ti.TenTienIch.Trim().ToLower() &&
                x.MaTienIch != ti.MaTienIch);

            if (trungTen)
                throw new Exception("Tên tiện ích đã tồn tại, vui lòng chọn tên khác!");

            existing.TenTienIch = ti.TenTienIch;
            existing.DonGia = ti.DonGia;
            existing.MoTa = ti.MoTa;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // =================== 4️⃣ XÓA ===================
        public bool Xoa(int maTienIch)
        {
            var ti = db.TienIches.Include(x => x.ChiTietTienIches)
                                 .FirstOrDefault(x => x.MaTienIch == maTienIch);

            if (ti == null)
                throw new Exception("Không tìm thấy tiện ích cần xóa!");

            // Nếu tiện ích đang được dùng trong ChiTietTienIch thì không cho xóa
            if (ti.ChiTietTienIches != null && ti.ChiTietTienIches.Any())
                throw new Exception("Không thể xóa! Tiện ích này đang được sử dụng trong chi tiết phòng.");

            db.TienIches.Remove(ti);
            db.SaveChanges();
            return true;
        }

        // =================== 5️⃣ TÌM KIẾM ===================
        public List<TienIch> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            tuKhoa = tuKhoa.Trim().ToLower();

            return db.TienIches
                     .AsNoTracking()
                     .Where(x => x.TenTienIch.ToLower().Contains(tuKhoa) ||
                                 (x.MoTa != null && x.MoTa.ToLower().Contains(tuKhoa)))
                     .ToList();
        }

        // =================== 6️⃣ LẤY THEO MÃ ===================
        public TienIch LayTheoMa(int maTienIch)
        {
            return db.TienIches.AsNoTracking()
                               .FirstOrDefault(x => x.MaTienIch == maTienIch);
        }

        // =================== 7️⃣ HỦY (DISPOSE) ===================
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
