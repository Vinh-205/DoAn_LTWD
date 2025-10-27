using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.Admin
{
    public class PhongDB
    {
        private readonly Connect db = new Connect();

        // Lấy tất cả phòng
        public List<Phong> GetAll()
        {
            return db.Phongs
                     .Include(p => p.ChuNha)
                     .Include(p => p.HopDongs)
                     .ToList();
        }

        // Lấy phòng theo mã
        public Phong GetById(string maPhong)
        {
            return db.Phongs
                     .Include(p => p.ChuNha)
                     .FirstOrDefault(p => p.MaPhong == maPhong);
        }

        // Thêm phòng mới
        public void Add(Phong phong)
        {
            db.Phongs.Add(phong);
            db.SaveChanges();
        }

        // Cập nhật thông tin phòng
        public void Update(Phong phong)
        {
            var old = db.Phongs.FirstOrDefault(p => p.MaPhong == phong.MaPhong);
            if (old != null)
            {
                db.Entry(old).CurrentValues.SetValues(phong);
                db.SaveChanges();
            }
        }

        // Xóa phòng
        public void Delete(string maPhong)
        {
            var p = db.Phongs.FirstOrDefault(x => x.MaPhong == maPhong);
            if (p != null)
            {
                db.Phongs.Remove(p);
                db.SaveChanges();
            }
        }

        // Lọc phòng theo trạng thái
        public List<Phong> GetByTrangThai(string trangThai)
        {
            return db.Phongs
                     .Where(p => p.TrangThai == trangThai)
                     .Include(p => p.ChuNha)
                     .ToList();
        }

        // Lọc phòng theo giá thuê (từ min đến max)
        public List<Phong> GetByGia(decimal min, decimal max)
        {
            return db.Phongs
                     .Where(p => p.GiaThue >= min && p.GiaThue <= max)
                     .Include(p => p.ChuNha)
                     .ToList();
        }

        // Lọc phòng theo loại
        public List<Phong> GetByLoai(string loaiPhong)
        {
            return db.Phongs
                     .Where(p => p.LoaiPhong.Contains(loaiPhong))
                     .Include(p => p.ChuNha)
                     .ToList();
        }

        // Tìm phòng theo tên
        public List<Phong> SearchByName(string keyword)
        {
            return db.Phongs
                     .Where(p => p.TenPhong.Contains(keyword))
                     .Include(p => p.ChuNha)
                     .ToList();
        }

        // Lấy danh sách phòng theo chủ nhà
        public List<Phong> GetByChuNha(int maChu)
        {
            return db.Phongs
                     .Where(p => p.MaChu == maChu)
                     .Include(p => p.ChuNha)
                     .ToList();
        }

        // Đếm số phòng trống
        public int CountEmpty()
        {
            return db.Phongs.Count(p => p.TrangThai == "Trống");
        }
    }
}
