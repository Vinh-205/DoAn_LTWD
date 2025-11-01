using System.Linq;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_BUS
{
    public class TaiKhoanBUS
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập (EF6)
        /// </summary>
        public TaiKhoan KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTK)
        {
            using (var db = new Connect())
            {
                // EF6 sẽ tìm bản ghi trùng tên, mật khẩu, loại tài khoản
                return db.TaiKhoans
                    .FirstOrDefault(t =>
                        t.TenDangNhap == tenDangNhap &&
                        t.MatKhau == matKhau &&
                        t.LoaiTK == loaiTK);
            }
        }
        public TaiKhoan LayLaiMatKhau(string tenDangNhap, string email)
        {
            using (var db = new Connect())
            {
                return db.TaiKhoans.FirstOrDefault(t =>
                    t.TenDangNhap == tenDangNhap && t.Email == email);
            }
        }
    }
}
