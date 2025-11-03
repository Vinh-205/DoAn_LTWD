using Phong_Tro_DAL.PhongTro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Phong_Tro_BUS
{
    public class ChiTietHoaDonBUS : IDisposable
    {
        private readonly Connect db;

        public ChiTietHoaDonBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ ========
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
                throw new ArgumentException("Mã hóa đơn không hợp lệ!", nameof(maHD));

            return db.ChiTietHoaDons
                     .Include(ct => ct.DichVu)
                     .Where(ct => ct.MaHD == maHD)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== THÊM ========
        public bool Them(ChiTietHoaDon ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));

            if (string.IsNullOrWhiteSpace(ct.MaHD) || string.IsNullOrWhiteSpace(ct.MaDV))
                throw new ArgumentException("Mã hóa đơn hoặc Mã dịch vụ không được để trống!");

            bool tonTai = db.ChiTietHoaDons.Any(x => x.MaHD == ct.MaHD && x.MaDV == ct.MaDV);
            if (tonTai)
                throw new Exception($"Chi tiết hóa đơn (MaHD: {ct.MaHD}, MaDV: {ct.MaDV}) đã tồn tại!");

            if (ct.ThanhTien == null && ct.SoLuong.HasValue && ct.SoLuong.Value > 0)
            {
                var dv = db.DichVus.AsNoTracking().FirstOrDefault(d => d.MaDV == ct.MaDV);
                if (dv != null && dv.DonGia.HasValue)
                    ct.ThanhTien = dv.DonGia.Value * ct.SoLuong.Value;
                else
                    ct.ThanhTien = 0;
            }
            else if (ct.ThanhTien == null)
            {
                ct.ThanhTien = 0;
            }

            db.ChiTietHoaDons.Add(ct);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA ========
        public bool Sua(ChiTietHoaDon ct)
        {
            if (ct == null)
                throw new ArgumentNullException(nameof(ct));

            if (string.IsNullOrWhiteSpace(ct.MaHD) || string.IsNullOrWhiteSpace(ct.MaDV))
                throw new ArgumentException("Mã hóa đơn hoặc Mã dịch vụ không được để trống!");

            var existing = db.ChiTietHoaDons.FirstOrDefault(x => x.MaHD == ct.MaHD && x.MaDV == ct.MaDV);
            if (existing == null)
                throw new Exception($"Không tìm thấy chi tiết hóa đơn (MaHD: {ct.MaHD}, MaDV: {ct.MaDV}) để cập nhật!");

            existing.SoLuong = ct.SoLuong;
            existing.ThanhTien = ct.ThanhTien ?? 0;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA ========
        public bool Xoa(string maHD, string maDV)
        {
            if (string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maDV))
                throw new ArgumentException("Mã hóa đơn hoặc Mã dịch vụ không hợp lệ!");

            var ct = db.ChiTietHoaDons.FirstOrDefault(x => x.MaHD == maHD && x.MaDV == maDV);
            if (ct == null)
                throw new Exception($"Không tìm thấy chi tiết hóa đơn (MaHD: {maHD}, MaDV: {maDV}) để xóa!");

            db.ChiTietHoaDons.Remove(ct);
            db.SaveChanges();
            return true;
        }

        // ======== TÍNH TỔNG TIỀN ========
        public decimal TinhTongTien(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return 0;

            return db.ChiTietHoaDons
                     .Where(ct => ct.MaHD == maHD)
                     .Sum(ct => ct.ThanhTien) ?? 0M;
        }

        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
