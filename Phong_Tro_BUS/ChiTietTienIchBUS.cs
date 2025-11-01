using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Core
{
    public class ChiTietTienIchBUS
    {
        /// <summary>
        /// Lấy danh sách tiện ích của một phòng
        /// </summary>
        public List<ChiTietTienIch> LayTheoPhong(string maPhong)
        {
            using (var db = new Connect())
            {
                return db.ChiTietTienIches
                    .Include(c => c.TienIch)
                    .Include(c => c.Phong)
                    .Where(c => c.MaPhong == maPhong)
                    .ToList();
            }
        }

        /// <summary>
        /// Thêm mới tiện ích cho phòng
        /// </summary>
        public bool ThemChiTiet(ChiTietTienIch chiTiet)
        {
            if (chiTiet == null) return false;

            using (var db = new Connect())
            {
                // Kiểm tra trùng khóa chính
                var exists = db.ChiTietTienIches.Any(c => c.MaPhong == chiTiet.MaPhong && c.MaTienIch == chiTiet.MaTienIch);
                if (exists)
                    throw new System.Exception("Tiện ích này đã tồn tại trong phòng.");

                db.ChiTietTienIches.Add(chiTiet);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Cập nhật giá tiện ích cho phòng
        /// </summary>
        public bool CapNhatChiTiet(ChiTietTienIch chiTiet)
        {
            using (var db = new Connect())
            {
                var old = db.ChiTietTienIches
                    .FirstOrDefault(c => c.MaPhong == chiTiet.MaPhong && c.MaTienIch == chiTiet.MaTienIch);
                if (old == null) return false;

                db.Entry(old).CurrentValues.SetValues(chiTiet);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Xóa tiện ích của phòng
        /// </summary>
        public bool XoaChiTiet(string maPhong, int maTienIch)
        {
            using (var db = new Connect())
            {
                var ct = db.ChiTietTienIches.FirstOrDefault(c => c.MaPhong == maPhong && c.MaTienIch == maTienIch);
                if (ct == null) return false;

                db.ChiTietTienIches.Remove(ct);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Tổng giá tiện ích của một phòng
        /// </summary>
        public decimal TongTienTienIch(string maPhong)
        {
            using (var db = new Connect())
            {
                return db.ChiTietTienIches
                    .Where(c => c.MaPhong == maPhong)
                    .Sum(c => (decimal?)c.Gia) ?? 0;
            }
        }
    }
}
