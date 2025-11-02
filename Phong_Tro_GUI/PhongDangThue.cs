using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class PhongDangThue : Form
    {
        private readonly PhongBUS _phongBUS;

        public PhongDangThue()
        {
            InitializeComponent();
            _phongBUS = new PhongBUS();
        }

        private void PhongDangThue_Load(object sender, EventArgs e)
        {
            TaiDanhSachPhong();
        }

        private void TaiDanhSachPhong()
        {
            var ds = _phongBUS.LayTatCa()
                              .Select(p => new
                              {
                                  p.MaPhong,
                                  p.TenPhong,
                                  p.LoaiPhong,
                                  p.DienTich,
                                  p.GiaThue,
                                  p.TrangThai
                              })
                              .ToList();

            dgvPhong.DataSource = ds;

            dgvPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvPhong.Columns["LoaiPhong"].HeaderText = "Loại phòng";
            dgvPhong.Columns["DienTich"].HeaderText = "Diện tích (m²)";
            dgvPhong.Columns["GiaThue"].HeaderText = "Giá thuê (VNĐ)";
            dgvPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var ds = _phongBUS.TimKiem(keyword)
                              .Select(p => new
                              {
                                  p.MaPhong,
                                  p.TenPhong,
                                  p.LoaiPhong,
                                  p.DienTich,
                                  p.GiaThue,
                                  p.TrangThai
                              })
                              .ToList();
            dgvPhong.DataSource = ds;
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhong = dgvPhong.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
                var phong = _phongBUS.LayTheoMa(maPhong);
                if (phong != null)
                    HienThiThongTinPhong(phong);
            }
        }

        private void HienThiThongTinPhong(Phong phong)
        {
            lblTenPhong.Text = $"Tên phòng: {phong.TenPhong}";
            lblLoaiPhong.Text = $"Loại: {phong.LoaiPhong}";
            lblGiaThue.Text = $"Giá thuê: {phong.GiaThue?.ToString("N0")} VNĐ";
            lblDienTich.Text = $"Diện tích: {phong.DienTich} m²";
            lblTrangThai.Text = $"Trạng thái: {phong.TrangThai}";
            txtTienNghi.Text = phong.TienNghi ?? "Chưa có thông tin";
            lblChuTro.Text = $"Chủ trọ: {phong.ChuNha?.Ten ?? "Không rõ"}";

            // Ảnh minh hoạ
            if (!string.IsNullOrEmpty(phong.AnhMinhHoa) && File.Exists(phong.AnhMinhHoa))
            {
                picAnhMinhHoa.Image = Image.FromFile(phong.AnhMinhHoa);
            }
            else
            {
                picAnhMinhHoa.Image = SystemIcons.Information.ToBitmap();
            }
        }
    }
}
