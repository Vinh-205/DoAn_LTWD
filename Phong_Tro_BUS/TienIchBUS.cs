using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Core
{
    public class TienIchBUS
    {
        /// <summary>
        /// Lấy toàn bộ danh sách tiện ích
        /// </summary>
        public List<TienIch> LayTatCaTienIch()
        {
            using (var db = new Connect())
            {
                return db.Set<TienIch>().OrderBy(t => t.TenTienIch).ToList();
            }
        }

        /// <summary>
        /// Lấy thông tin tiện ích theo mã
        /// </summary>
        public TienIch LayTienIchTheoMa(int maTienIch)
        {
            using (var db = new Connect())
            {
                return db.Set<TienIch>().FirstOrDefault(t => t.MaTienIch == maTienIch);
            }
        }

        /// <summary>
        /// Thêm tiện ích mới
        /// </summary>
        public bool ThemTienIch(TienIch tienIch)
        {
            if (tienIch == null)
                throw new ArgumentNullException(nameof(tienIch));
            if (string.IsNullOrWhiteSpace(tienIch.TenTienIch))
                throw new ArgumentException("Tên tiện ích không được để trống.");
            if (tienIch.DonGia < 0)
                throw new ArgumentException("Đơn giá không hợp lệ.");

            using (var db = new Connect())
            {
                db.Set<TienIch>().Add(tienIch);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Cập nhật tiện ích
        /// </summary>
        public bool CapNhatTienIch(TienIch tienIch)
        {
            if (tienIch == null)
                throw new ArgumentNullException(nameof(tienIch));

            using (var db = new Connect())
            {
                var old = db.Set<TienIch>().FirstOrDefault(t => t.MaTienIch == tienIch.MaTienIch);
                if (old == null) return false;

                db.Entry(old).CurrentValues.SetValues(tienIch);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Xóa tiện ích theo mã
        /// </summary>
        public bool XoaTienIch(int maTienIch)
        {
            using (var db = new Connect())
            {
                var t = db.Set<TienIch>().FirstOrDefault(ti => ti.MaTienIch == maTienIch);
                if (t == null) return false;

                db.Set<TienIch>().Remove(t);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Tìm tiện ích theo tên (có chứa từ khóa)
        /// </summary>
        public List<TienIch> TimKiemTheoTen(string tuKhoa)
        {
            using (var db = new Connect())
            {
                return db.Set<TienIch>()
                    .Where(t => t.TenTienIch.Contains(tuKhoa))
                    .OrderBy(t => t.TenTienIch)
                    .ToList();
            }
        }
    }
}
