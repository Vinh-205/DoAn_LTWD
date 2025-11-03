using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;
using Phong_Tro_GUI.ConTrolUser;

namespace Phong_Tro_GUI.ConTrolUser
{
    public partial class ThongTinUser : UserControl
    {
        private readonly KhachThueBUS _khachThueBUS;
        private KhachThue _khachThueHienTai;

        public ThongTinUser(int maKhach)
        {
            InitializeComponent();
            _khachThueBUS = new KhachThueBUS();
            TaiThongTin(maKhach);
        }

        private void TaiThongTin(int maKhach)
        {
            _khachThueHienTai = _khachThueBUS.LayTheoMa(maKhach);

            if (_khachThueHienTai == null)
            {
                MessageBox.Show("Không tìm thấy thông tin khách thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblTen.Text = "👤 Tên: " + _khachThueHienTai.Ten;
            lblSDT.Text = "📞 SĐT: " + _khachThueHienTai.SDT;
            lblEmail.Text = "📧 Email: " + _khachThueHienTai.Email;
            lblCCCD.Text = "🪪 CCCD: " + _khachThueHienTai.CCCD;
            lblNgaySinh.Text = "🎂 Ngày sinh: " + _khachThueHienTai.NgaySinh?.ToString("dd/MM/yyyy");
            lblDiaChi.Text = "📍 Địa chỉ: " + _khachThueHienTai.DiaChi;

            HienThiAnhTheoGioiTinh();
        }

        private void HienThiAnhTheoGioiTinh()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_khachThueHienTai.Avatar) && File.Exists(_khachThueHienTai.Avatar))
                {
                    picAvatar.Image = Image.FromFile(_khachThueHienTai.Avatar);
                    return;
                }

                // 🧩 Nếu chưa có thuộc tính GioiTinh → chọn mặc định nam
                string duongDanAnhMacDinh = Path.Combine(Application.StartupPath, "Resources", "male.png");

                if (File.Exists(duongDanAnhMacDinh))
                    picAvatar.Image = Image.FromFile(duongDanAnhMacDinh);
                else
                    picAvatar.Image = SystemIcons.Information.ToBitmap();
            }
            catch
            {
                picAvatar.Image = SystemIcons.Warning.ToBitmap();
            }
        }

    }
}

