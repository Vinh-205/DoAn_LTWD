using Phong_Tro_DAL.PhongTro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Phong_Tro_BUS
{
    public class ChiTietTienIchBUS
    {
        private readonly Connect db;

        public ChiTietTienIchBUS()
        {
            db = new Connect();
        }

        // ======== LẤY TẤT CẢ ========
        public List<ChiTietTienIch> LayTatCa()
        {
            try
            {
                return db.ChiTietTienIches
                         .Include(ct => ct.Phong)
                         .Include(ct => ct.TienIch)
                         .AsNoTracking()
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tải danh sách ChiTietTienIch: " + ex.Message);
            }
        }

        // ======== LẤY THEO PHÒNG ========
        public List<ChiTietTienIch> LayTheoPhong(string maPhong)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maPhong))
                    throw new ArgumentException("Mã phòng không hợp lệ!");

                return db.ChiTietTienIches
                         .Include(ct => ct.TienIch)
                         .Where(ct => ct.MaPhong == maPhong)
                         .AsNoTracking()
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải ChiTietTienIch theo phòng: " + ex.Message);
            }
        }

        // ======== THÊM ========
        public bool Them(ChiTietTienIch ct)
        {
            try
            {
                if (ct == null)
                    throw new ArgumentNullException(nameof(ct));

                bool tonTai = db.ChiTietTienIches.Any(x => x.MaPhong == ct.MaPhong && x.MaTienIch == ct.MaTienIch);
                if (tonTai)
                    throw new Exception("Chi tiết tiện ích đã tồn tại cho phòng này!");

                // Nếu giá chưa có, lấy từ TienIch
                if (ct.Gia == null)
                {
                    var tienIch = db.TienIches.Find(ct.MaTienIch);
                    if (tienIch != null && tienIch.DonGia.HasValue)
                        ct.Gia = tienIch.DonGia.Value;
                }

                db.ChiTietTienIches.Add(ct);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm ChiTietTienIch: " + ex.Message);
            }
        }

        // ======== SỬA ========
        public bool Sua(ChiTietTienIch ct)
        {
            try
            {
                if (ct == null)
                    throw new ArgumentNullException(nameof(ct));

                var existing = db.ChiTietTienIches
                                 .FirstOrDefault(x => x.MaPhong == ct.MaPhong && x.MaTienIch == ct.MaTienIch);
                if (existing == null)
                    throw new Exception("Không tìm thấy chi tiết tiện ích để cập nhật!");

                existing.Gia = ct.Gia;
                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa ChiTietTienIch: " + ex.Message);
            }
        }

        // ======== XÓA ========
        public bool Xoa(string maPhong, int maTienIch)
        {
            try
            {
                var ct = db.ChiTietTienIches
                           .FirstOrDefault(x => x.MaPhong == maPhong && x.MaTienIch == maTienIch);
                if (ct == null)
                    throw new Exception("Không tìm thấy chi tiết tiện ích để xóa!");

                db.ChiTietTienIches.Remove(ct);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa ChiTietTienIch: " + ex.Message);
            }
        }

        // ======== TÍNH TỔNG TIỀN TIỆN ÍCH THEO PHÒNG ========
        public decimal TinhTongTien(string maPhong)
        {
            try
            {
                return db.ChiTietTienIches
                         .Where(ct => ct.MaPhong == maPhong)
                         .Sum(ct => (decimal?)ct.Gia) ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
