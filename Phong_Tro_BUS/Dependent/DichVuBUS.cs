using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class DichVuBUS : IDisposable
    {
        private readonly Connect db;

        public DichVuBUS()
        {
            db = new Connect();
        }

        // ================== LẤY TẤT CẢ ==================
        public List<DichVu> LayTatCa()
        {
            try
            {
                return db.DichVus.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách dịch vụ: " + ex.Message);
            }
        }

        // ================== LẤY THEO MÃ ==================
        public DichVu LayTheoMa(string maDV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDV))
                    throw new ArgumentException("Mã dịch vụ không hợp lệ!");

                return db.DichVus.AsNoTracking().FirstOrDefault(x => x.MaDV == maDV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dịch vụ theo mã: " + ex.Message);
            }
        }

        // ================== THÊM ==================
        public bool Them(DichVu dv)
        {
            try
            {
                if (dv == null)
                    throw new ArgumentNullException(nameof(dv));

                if (string.IsNullOrWhiteSpace(dv.MaDV))
                    throw new Exception("Mã dịch vụ không được để trống!");

                if (db.DichVus.Any(x => x.MaDV == dv.MaDV))
                    throw new Exception($"Dịch vụ có mã '{dv.MaDV}' đã tồn tại!");

                db.DichVus.Add(dv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm dịch vụ: " + ex.Message);
            }
        }

        // ================== SỬA ==================
        public bool Sua(DichVu dv)
        {
            try
            {
                if (dv == null)
                    throw new ArgumentNullException(nameof(dv));

                var existing = db.DichVus.Find(dv.MaDV);
                if (existing == null)
                    throw new Exception($"Không tìm thấy dịch vụ có mã '{dv.MaDV}'!");

                existing.TenDV = dv.TenDV;
                existing.DonGia = dv.DonGia;
                existing.MoTa = dv.MoTa;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật dịch vụ: " + ex.Message);
            }
        }

        // ================== XÓA ==================
        public bool Xoa(string maDV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDV))
                    throw new ArgumentException("Mã dịch vụ không hợp lệ!");

                var dv = db.DichVus.Find(maDV);
                if (dv == null)
                    throw new Exception($"Không tìm thấy dịch vụ có mã '{maDV}' để xóa!");

                db.DichVus.Remove(dv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa dịch vụ: " + ex.Message);
            }
        }

        // ================== TÌM KIẾM ==================
        public List<DichVu> TimKiem(string tuKhoa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return LayTatCa();

                tuKhoa = tuKhoa.Trim().ToLower();

                return db.DichVus
                         .Where(x => x.TenDV.ToLower().Contains(tuKhoa))
                         .AsNoTracking()
                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm dịch vụ: " + ex.Message);
            }
        }

        // ================== TÍNH TỔNG GIÁ DỊCH VỤ ==================
        public decimal TongGiaDichVu()
        {
            try
            {
                return db.DichVus.Sum(x => (decimal?)x.DonGia) ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        // ================== GIẢI PHÓNG ==================
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
