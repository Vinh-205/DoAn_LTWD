using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class HoaDonBUS
    {
        private readonly Connect db;

        public HoaDonBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ HÓA ĐƠN ========
        public List<HoaDon> LayTatCa()
        {
            return db.HoaDons
                     .Include(hd => hd.ChiTietHoaDons.Select(ct => ct.DichVu))
                     .Include(hd => hd.HopDong)
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY THEO MÃ HÓA ĐƠN ========
        public HoaDon LayTheoMa(string maHD)
        {
            return db.HoaDons
                     .Include(hd => hd.ChiTietHoaDons.Select(ct => ct.DichVu))
                     .Include(hd => hd.HopDong)
                     .AsNoTracking()
                     .FirstOrDefault(hd => hd.MaHD == maHD);
        }

        // ======== THÊM HÓA ĐƠN ========
        public bool Them(HoaDon hd)
        {
            if (hd == null)
                throw new ArgumentNullException(nameof(hd));

            bool tonTai = db.HoaDons.Any(x => x.MaHD == hd.MaHD);
            if (tonTai)
                throw new Exception("Mã hóa đơn đã tồn tại!");

            db.HoaDons.Add(hd);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA HÓA ĐƠN ========
        public bool Sua(HoaDon hd)
        {
            if (hd == null)
                throw new ArgumentNullException(nameof(hd));

            var existing = db.HoaDons.Find(hd.MaHD);
            if (existing == null)
                throw new Exception("Không tìm thấy hóa đơn để cập nhật!");

            existing.MaHopDong = hd.MaHopDong;
            existing.Thang = hd.Thang;
            existing.Nam = hd.Nam;
            existing.SoDienCu = hd.SoDienCu;
            existing.SoDienMoi = hd.SoDienMoi;
            existing.SoNuocCu = hd.SoNuocCu;
            existing.SoNuocMoi = hd.SoNuocMoi;
            existing.TienDien = hd.TienDien;
            existing.TienNuoc = hd.TienNuoc;
            existing.TienDichVu = hd.TienDichVu;
            existing.GiaPhong = hd.GiaPhong;
            existing.TongTien = hd.TongTien;
            existing.NgayLap = hd.NgayLap;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA HÓA ĐƠN ========
        public bool Xoa(string maHD)
        {
            var hd = db.HoaDons.Find(maHD);
            if (hd == null)
                throw new Exception("Không tìm thấy hóa đơn để xóa!");

            db.HoaDons.Remove(hd);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM HÓA ĐƠN THEO MÃ HĐ HOẶC THÁNG/NĂM ========
        public List<HoaDon> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.HoaDons
                     .Where(hd => hd.MaHD.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }

        // ======== TÍNH TỔNG TIỀN HÓA ĐƠN ========
        public decimal TinhTongTien(HoaDon hd)
        {
            decimal tienDichVu = hd.TienDichVu ?? 0;
            decimal tienDien = hd.TienDien ?? 0;
            decimal tienNuoc = hd.TienNuoc ?? 0;
            decimal giaPhong = hd.GiaPhong ?? 0;

            return tienDichVu + tienDien + tienNuoc + giaPhong;
        }
    }
}
