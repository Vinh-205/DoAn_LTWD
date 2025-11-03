using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class PhongBUS
    {
        private readonly Connect db;

        public PhongBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ PHÒNG ========
        public List<Phong> LayTatCa() 
        { 
            return db.Phongs
                .Include(p => p.ChuNha)
                .Include(p => p.ChiTietTienIches)
                .Include(p => p.HopDongs)
                .Include(p => p.ThongBaos)
                .AsNoTracking()
                .ToList(); }

        // ======== LẤY THEO MÃ PHÒNG ========
        public Phong LayTheoMa(string maPhong)
        {
            return db.Phongs
                     .Include(p => p.ChuNha)
                     .Include(p => p.ChiTietTienIches)
                     .Include(p => p.HopDongs)
                     .Include(p => p.ThongBaos)
                     .AsNoTracking()
                     .FirstOrDefault(p => p.MaPhong == maPhong);
        }

        // ======== THÊM PHÒNG ========
        public bool Them(Phong phong)
        {
            if (phong == null)
                throw new ArgumentNullException(nameof(phong));

            bool tonTai = db.Phongs.Any(p => p.MaPhong == phong.MaPhong);
            if (tonTai)
                throw new Exception("Mã phòng đã tồn tại!");

            db.Phongs.Add(phong);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA PHÒNG ========
        public bool Sua(Phong phong)
        {
            if (phong == null)
                throw new ArgumentNullException(nameof(phong));

            var existing = db.Phongs.Find(phong.MaPhong);
            if (existing == null)
                throw new Exception("Không tìm thấy phòng để cập nhật!");

            existing.MaChu = phong.MaChu;
            existing.TenPhong = phong.TenPhong;
            existing.LoaiPhong = phong.LoaiPhong;
            existing.DienTich = phong.DienTich;
            existing.GiaThue = phong.GiaThue;
            existing.TrangThai = phong.TrangThai;
            existing.TienNghi = phong.TienNghi;
            existing.AnhMinhHoa = phong.AnhMinhHoa;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA PHÒNG ========
        public bool Xoa(string maPhong)
        {
            var phong = db.Phongs.Find(maPhong);
            if (phong == null)
                throw new Exception("Không tìm thấy phòng để xóa!");

            db.Phongs.Remove(phong);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM PHÒNG ========
        public List<Phong> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.Phongs
                     .Where(p => p.TenPhong.Contains(tuKhoa) ||
                                 p.LoaiPhong.Contains(tuKhoa) ||
                                 p.TrangThai.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }
    }
}
