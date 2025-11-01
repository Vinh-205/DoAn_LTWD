using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Core
{
    public class ChiTietHoaDonBUS
    {
        /// <summary>
        /// Lấy tất cả chi tiết của một hóa đơn
        /// </summary>
        public List<ChiTietHoaDon> LayChiTietTheoHoaDon(string maHD)
        {
            using (var db = new Connect())
            {
                return db.ChiTietHoaDons
                    .Include(c => c.DichVu)
                    .Include(c => c.HoaDon)
                    .Where(c => c.MaHD == maHD)
                    .ToList();
            }
        }

        /// <summary>
        /// Thêm mới chi tiết hóa đơn
        /// </summary>
        public bool ThemChiTiet(ChiTietHoaDon chiTiet)
        {
            if (chiTiet == null) return false;
            if (chiTiet.SoLuong == null || chiTiet.SoLuong <= 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0.");

            // Lấy đơn giá từ bảng DichVu
            using (var db = new Connect())
            {
                var dv = db.DichVus.FirstOrDefault(d => d.MaDV == chiTiet.MaDV);
                if (dv == null)
                    throw new Exception("Dịch vụ không tồn tại.");

                chiTiet.ThanhTien = chiTiet.SoLuong * dv.DonGia;
                db.ChiTietHoaDons.Add(chiTiet);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Cập nhật chi tiết hóa đơn (dựa trên MaHD + MaDV)
        /// </summary>
        public bool CapNhatChiTiet(ChiTietHoaDon chiTiet)
        {
            using (var db = new Connect())
            {
                var old = db.ChiTietHoaDons
                    .FirstOrDefault(c => c.MaHD == chiTiet.MaHD && c.MaDV == chiTiet.MaDV);
                if (old == null) return false;

                // cập nhật lại tiền
                var dv = db.DichVus.FirstOrDefault(d => d.MaDV == chiTiet.MaDV);
                if (dv != null)
                    chiTiet.ThanhTien = chiTiet.SoLuong * dv.DonGia;

                db.Entry(old).CurrentValues.SetValues(chiTiet);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Xóa chi tiết hóa đơn
        /// </summary>
        public bool XoaChiTiet(string maHD, string maDV)
        {
            using (var db = new Connect())
            {
                var ct = db.ChiTietHoaDons.FirstOrDefault(c => c.MaHD == maHD && c.MaDV == maDV);
                if (ct == null) return false;

                db.ChiTietHoaDons.Remove(ct);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Tính tổng tiền của hóa đơn
        /// </summary>
        public decimal TinhTongTien(string maHD)
        {
            using (var db = new Connect())
            {
                return db.ChiTietHoaDons
                    .Where(c => c.MaHD == maHD)
                    .Sum(c => (decimal?)c.ThanhTien) ?? 0;
            }
        }
    }
}
