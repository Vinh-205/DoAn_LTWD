using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class ThongTinCaNhan : Form
    {
        private readonly KhachThueBUS _khachThueBUS;
        private KhachThue _khachThueHienTai;

        public ThongTinCaNhan(int maKhach)
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
                this.Close();
                return;
            }

            lblTen.Text = "Tên: " + _khachThueHienTai.Ten;
            lblSDT.Text = "SĐT: " + _khachThueHienTai.SDT;
            lblEmail.Text = "Email: " + _khachThueHienTai.Email;
            lblCCCD.Text = "CCCD: " + _khachThueHienTai.CCCD;
            lblNgaySinh.Text = "Ngày sinh: " + _khachThueHienTai.NgaySinh?.ToString("dd/MM/yyyy");
            lblDiaChi.Text = "Địa chỉ: " + _khachThueHienTai.DiaChi;

            // Ảnh đại diện (đường dẫn string)
            try
            {
                if (!string.IsNullOrWhiteSpace(_khachThueHienTai.Avatar) && File.Exists(_khachThueHienTai.Avatar))
                {
                    picAvatar.Image = Image.FromFile(_khachThueHienTai.Avatar);
                }
                else
                {
                    // Nếu không có ảnh -> dùng icon mặc định
                    picAvatar.Image = SystemIcons.Application.ToBitmap();
                }
            }
            catch
            {
                picAvatar.Image = SystemIcons.Warning.ToBitmap();
            }
        }
    }
}
