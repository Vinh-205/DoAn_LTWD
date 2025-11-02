using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class ChiTietHoaDonBUS
    {
        private readonly Connect db;

        public ChiTietHoaDonBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ CHI TIẾT HÓA ĐƠN ========
        public List<ChiTietHoaDon> LayTatCa()
        {
            return db.ChiTietHoaDons
                     .Include(ct => ct.DichVu)
                     .Include(ct => ct.HoaDon)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ HÓA ĐƠN ========
        public List<ChiTietHoaDon> LayTheoHoaDon(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                throw new ArgumentException("Mã hóa đơn không hợp lệ!");

            return db.ChiTietHoaDons
                     .Include(ct => ct.DichVu)
                     .Where(ct => ct.MaHD == maHD)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== THÊM CHI TIẾT HÓA ĐƠN ========
        public bool Them(ChiTietHoaDon ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));

            bool tonTai = db.ChiTietHoaDons.Any(x => x.MaHD == ct.MaHD && x.MaDV == ct.MaDV);
            if (tonTai)
                throw new Exception("Chi tiết hóa đơn này đã tồn tại!");

            // Tính thành tiền nếu chưa có
            if (ct.ThanhTien == null && ct.SoLuong != null)
            {
                var dv = db.DichVus.Find(ct.MaDV);
                if (dv != null)
                    ct.ThanhTien = dv.DonGia * ct.SoLuong.Value;
            }


            db.ChiTietHoaDons.Add(ct);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA CHI TIẾT HÓA ĐƠN ========
        public bool Sua(ChiTietHoaDon ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));

            var existing = db.ChiTietHoaDons.FirstOrDefault(x => x.MaHD == ct.MaHD && x.MaDV == ct.MaDV);
            if (existing == null)
                throw new Exception("Không tìm thấy chi tiết hóa đơn để cập nhật!");

            existing.SoLuong = ct.SoLuong;
            existing.ThanhTien = ct.ThanhTien;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA CHI TIẾT HÓA ĐƠN ========
        public bool Xoa(string maHD, string maDV)
        {
            var ct = db.ChiTietHoaDons.FirstOrDefault(x => x.MaHD == maHD && x.MaDV == maDV);
            if (ct == null)
                throw new Exception("Không tìm thấy chi tiết hóa đơn để xóa!");

            db.ChiTietHoaDons.Remove(ct);
            db.SaveChanges();
            return true;
        }

        // ======== TÍNH TỔNG TIỀN THEO HÓA ĐƠN ========
        public decimal TinhTongTien(string maHD)
        {
            return db.ChiTietHoaDons
                     .Where(ct => ct.MaHD == maHD)
                     .Sum(ct => (decimal?)ct.ThanhTien) ?? 0;
        }
    }
}
