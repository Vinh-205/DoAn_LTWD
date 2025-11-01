using System;
using System.Collections.Generic;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Services
{
    public class ThongBaoBUS
    {
        /// <summary>
        /// Lấy danh sách thông báo theo mã phòng (mới nhất lên đầu)
        /// </summary>
        public List<ThongBao> LayThongBaoTheoPhong(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                return new List<ThongBao>();

            using (var db = new Connect())
            {
                return db.ThongBaos
                    .Where(t => t.MaPhong == maPhong)
                    .OrderByDescending(t => t.NgayTao)
                    .ToList();
            }
        }

        /// <summary>
        /// Lấy tất cả thông báo (cho chủ trọ)
        /// </summary>
        public List<ThongBao> LayTatCaThongBao()
        {
            using (var db = new Connect())
            {
                return db.ThongBaos
                    .OrderByDescending(t => t.NgayTao)
                    .ToList();
            }
        }

        /// <summary>
        /// Gửi thông báo mới
        /// </summary>
        public bool GuiThongBao(ThongBao tb)
        {
            if (tb == null)
                throw new ArgumentNullException(nameof(tb), "Thông báo không được null.");

            if (string.IsNullOrWhiteSpace(tb.NoiDung))
                throw new ArgumentException("Nội dung thông báo không được để trống.");

            if (string.IsNullOrWhiteSpace(tb.MaPhong))
                throw new ArgumentException("Phải chọn phòng cần gửi thông báo.");

            using (var db = new Connect())
            {
                tb.NgayTao = DateTime.Now;
                db.ThongBaos.Add(tb);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Xóa thông báo theo mã
        /// </summary>
        public bool XoaThongBao(int maThongBao)
        {
            using (var db = new Connect())
            {
                var tb = db.ThongBaos.FirstOrDefault(t => t.MaTB == maThongBao);
                if (tb == null) return false;

                db.ThongBaos.Remove(tb);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Cập nhật nội dung thông báo (chủ yếu khi cần sửa)
        /// </summary>
        public bool CapNhatThongBao(int maThongBao, string noiDung, string maPhong = null)
        {
            using (var db = new Connect())
            {
                var tb = db.ThongBaos.FirstOrDefault(t => t.MaTB == maThongBao);
                if (tb == null) return false;

                tb.NoiDung = noiDung?.Trim();
                if (!string.IsNullOrWhiteSpace(maPhong))
                    tb.MaPhong = maPhong;

                tb.NgayTao = DateTime.Now; // cập nhật lại thời gian
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Đếm tổng số thông báo
        /// </summary>
        public int DemTongSoThongBao()
        {
            using (var db = new Connect())
            {
                return db.ThongBaos.Count();
            }
        }
    }
}
