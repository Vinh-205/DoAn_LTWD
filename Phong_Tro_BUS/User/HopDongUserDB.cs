using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS.User
{
    public class HopDongUserDB
    {
        private readonly Connect db = new Connect();

        // Lấy tất cả hợp đồng của 1 khách thuê (nếu họ thuê nhiều phòng)
        public List<HopDong> GetAllByKhach(int maKhach)
        {
            return db.HopDongs
                     .Include(h => h.Phong)
                     .Include(h => h.Phong.ChuNha)
                     .Where(h => h.MaKhach == maKhach)
                     .OrderByDescending(h => h.NgayBatDau)
                     .ToList();
        }

        // Lấy 1 hợp đồng hiện tại (chưa kết thúc) của khách thuê
        public HopDong GetCurrentHopDong(int maKhach)
        {
            return db.HopDongs
                     .Include(h => h.Phong)
                     .Include(h => h.Phong.ChuNha)
                     .FirstOrDefault(h => h.MaKhach == maKhach &&
                                          (h.TrangThai == "Đang thuê" || h.NgayKetThuc == null));
        }

        // Lấy chi tiết hợp đồng theo mã
        public HopDong GetById(int maHopDong)
        {
            return db.HopDongs
                     .Include(h => h.Phong)
                     .Include(h => h.Phong.ChuNha)
                     .Include(h => h.KhachThue)
                     .FirstOrDefault(h => h.MaHopDong == maHopDong);
        }

        // Kiểm tra xem khách có hợp đồng đang hiệu lực không
        public bool HasActiveContract(int maKhach)
        {
            return db.HopDongs.Any(h => h.MaKhach == maKhach &&
                                        (h.TrangThai == "Đang thuê" || h.NgayKetThuc == null));
        }

        // Cập nhật trạng thái hợp đồng (ví dụ: kết thúc, gia hạn, hủy)
        public void UpdateTrangThai(int maHopDong, string trangThai)
        {
            var hopDong = db.HopDongs.Find(maHopDong);
            if (hopDong != null)
            {
                hopDong.TrangThai = trangThai;
                db.SaveChanges();
            }
        }
    }
}
