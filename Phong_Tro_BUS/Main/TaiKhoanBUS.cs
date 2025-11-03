using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_BUS
{
    public class TaiKhoanBUS : IDisposable
    {
        private readonly Connect db;

        public TaiKhoanBUS()
        {
            db = new Connect();
        }

        // ======== KIỂM TRA ĐĂNG NHẬP ========
        public TaiKhoan KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTK)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                throw new ArgumentException("Tên đăng nhập và mật khẩu không được để trống!");

            var tk = db.TaiKhoans
                       .AsNoTracking()
                       .FirstOrDefault(t =>
                           t.TenDangNhap == tenDangNhap &&
                           t.MatKhau == matKhau && // (nếu bạn dùng mã hoá, hãy so sánh sau khi hash)
                           t.LoaiTK == loaiTK
                       );

            return tk;
        }

        // ======== LẤY TẤT CẢ TÀI KHOẢN ========
        public List<TaiKhoan> LayTatCa()
        {
            return db.TaiKhoans
                     .AsNoTracking()
                     .OrderBy(t => t.MaTK)
                     .ToList();
        }

        // ======== LẤY THEO MÃ ========
        public TaiKhoan LayTheoMa(int maTK)
        {
            return db.TaiKhoans
                     .AsNoTracking()
                     .FirstOrDefault(t => t.MaTK == maTK);
        }

        // ======== THÊM TÀI KHOẢN ========
        public bool Them(TaiKhoan tk)
        {
            if (tk == null)
                throw new ArgumentNullException(nameof(tk));

            if (db.TaiKhoans.Any(t => t.TenDangNhap == tk.TenDangNhap))
                throw new Exception("Tên đăng nhập đã tồn tại!");

            tk.NgayTao = DateTime.Now;
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
            return true;
        }

        // ======== SỬA TÀI KHOẢN ========
        public bool Sua(TaiKhoan tk)
        {
            if (tk == null)
                throw new ArgumentNullException(nameof(tk));

            var existing = db.TaiKhoans.Find(tk.MaTK);
            if (existing == null)
                throw new Exception("Không tìm thấy tài khoản để cập nhật!");

            existing.HoTen = tk.HoTen;
            existing.Email = tk.Email;
            existing.SDT = tk.SDT;
            existing.LoaiTK = tk.LoaiTK;

            db.Entry(existing).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== ĐỔI MẬT KHẨU ========
        public bool DoiMatKhau(int maTK, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi))
                throw new ArgumentException("Mật khẩu mới không được để trống!");

            var tk = db.TaiKhoans.Find(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản!");

            tk.MatKhau = matKhauMoi; // Có thể thêm mã hoá ở đây
            db.Entry(tk).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        // ======== XÓA TÀI KHOẢN ========
        public bool Xoa(int maTK)
        {
            var tk = db.TaiKhoans.Find(maTK);
            if (tk == null)
                throw new Exception("Không tìm thấy tài khoản để xóa!");

            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return true;
        }

        // ======== TÌM KIẾM ========
        public List<TaiKhoan> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return LayTatCa();

            return db.TaiKhoans
                     .Where(t => t.TenDangNhap.Contains(tuKhoa)
                              || t.HoTen.Contains(tuKhoa)
                              || t.Email.Contains(tuKhoa)
                              || t.SDT.Contains(tuKhoa))
                     .AsNoTracking()
                     .ToList();
        }

        // ======== LẤY LẠI MẬT KHẨU ========
        public TaiKhoan LayLaiMatKhau(string tenDangNhap, string email)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Tên đăng nhập và email không được để trống!");

            return db.TaiKhoans
                     .AsNoTracking()
                     .FirstOrDefault(t =>
                         t.TenDangNhap == tenDangNhap &&
                         t.Email == email
                     );
        }

        // ======== GIẢI PHÓNG NGUỒN ========
        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
