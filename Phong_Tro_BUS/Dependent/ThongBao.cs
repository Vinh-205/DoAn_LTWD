using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class ThongBaoBUS : IDisposable
    {
        private readonly Connect db;

        public ThongBaoBUS()
        {
            db = new Connect();
        }

        // ========== LẤY TẤT CẢ ==========
        public List<ThongBao> LayTatCa()
        {
            try
            {
                return db.ThongBaos
                    .Include(tb => tb.MaTK_Gui)
                    .Include(tb => tb.MaTK_Nhan)
                    .AsNoTracking()
                    .OrderByDescending(tb => tb.NgayGui)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách thông báo: " + ex.Message);
            }
        }

        // ========== LẤY THEO MÃ ==========
        public ThongBao LayTheoMa(int maTB)
        {
            try
            {
                return db.ThongBaos
                    .Include(tb => tb.MaTK_Gui)
                    .Include(tb => tb.MaTK_Nhan)
                    .AsNoTracking()
                    .FirstOrDefault(tb => tb.MaTB == maTB);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông báo: " + ex.Message);
            }
        }

        // ========== LẤY THEO NGƯỜI NHẬN ==========
        public List<ThongBao> LayTheoNguoiNhan(int maTKNhan)
        {
            try
            {
                return db.ThongBaos
                    .Where(tb => tb.MaTK_Nhan == maTKNhan)
                    .Include(tb => tb.MaTK_Gui)
                    .OrderByDescending(tb => tb.NgayGui)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông báo người nhận: " + ex.Message);
            }
        }

        // ========== THÊM ==========
        public bool Them(ThongBao tb)
        {
            try
            {
                if (tb == null)
                    throw new ArgumentNullException(nameof(tb));

                tb.NgayGui = DateTime.Now;
                tb.DaDoc = false;

                db.ThongBaos.Add(tb);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm thông báo: " + ex.Message);
            }
        }

        // ========== CẬP NHẬT / SỬA ==========
        public bool Sua(ThongBao tb)
        {
            try
            {
                var existing = db.ThongBaos.Find(tb.MaTB);
                if (existing == null)
                    throw new Exception("Không tìm thấy thông báo để cập nhật!");

                existing.NoiDung = tb.NoiDung;
                existing.DaDoc = tb.DaDoc ?? existing.DaDoc;
                existing.NgayGui = tb.NgayGui ?? existing.NgayGui;

                db.Entry(existing).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa thông báo: " + ex.Message);
            }
        }

        // ========== XÓA ==========
        public bool Xoa(int maTB)
        {
            try
            {
                var tb = db.ThongBaos.Find(maTB);
                if (tb == null)
                    throw new Exception("Không tìm thấy thông báo để xóa!");

                db.ThongBaos.Remove(tb);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa thông báo: " + ex.Message);
            }
        }

        // ========== ĐÁNH DẤU ĐÃ ĐỌC ==========
        public bool DanhDauDaDoc(int maTB)
        {
            try
            {
                var tb = db.ThongBaos.Find(maTB);
                if (tb == null) return false;

                tb.DaDoc = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái thông báo: " + ex.Message);
            }
        }

        // ========== TÌM KIẾM ==========
        public List<ThongBao> TimKiem(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return LayTatCa();

                keyword = keyword.ToLower();

                return db.ThongBaos
                    .Where(tb => tb.NoiDung.ToLower().Contains(keyword))
                    .Include(tb => tb.MaTK_Gui)
                    .Include(tb => tb.MaTK_Nhan)
                    .OrderByDescending(tb => tb.NgayGui)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm thông báo: " + ex.Message);
            }
        }

        // ========== GIẢI PHÓNG ==========
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
