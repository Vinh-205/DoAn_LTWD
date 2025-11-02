using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class PhongUser : UserControl
    {
        private readonly PhongBUS _phongBUS;

        public PhongUser()
        {
            InitializeComponent();
            _phongBUS = new PhongBUS();
            this.Load += PhongUser_Load;
        }

        private void PhongUser_Load(object sender, EventArgs e)
        {
            CaiDatTimKiemPlaceholder();
            CaiDatBangPhong();
            TaiDanhSachPhong();
        }

        // 🌸 Hiển thị placeholder cho ô tìm kiếm
        private void CaiDatTimKiemPlaceholder()
        {
            txtTimKiem.Text = "🔍 Nhập tên hoặc mã phòng...";
            txtTimKiem.ForeColor = Color.Gray;

            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == "🔍 Nhập tên hoặc mã phòng...")
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = "🔍 Nhập tên hoặc mã phòng...";
                    txtTimKiem.ForeColor = Color.Gray;
                }
            };
        }

        // 🎨 Cấu hình DataGridView
        private void CaiDatBangPhong()
        {
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvPhong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPhong.EnableHeadersVisualStyles = false;
            dgvPhong.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPhong.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPhong.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // 📋 Tải danh sách phòng
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

            dgvPhong.ClearSelection();
            XoaThongTinChiTiet();
        }

        // 🔍 Tìm kiếm khi nhập
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.ForeColor == Color.Gray) return;

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

        // 🏠 Khi chọn 1 phòng
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

        // 💡 Hiển thị thông tin chi tiết
        private void HienThiThongTinPhong(Phong phong)
        {
            lblTenPhong.Text = $"Tên phòng: {phong.TenPhong}";
            lblLoaiPhong.Text = $"Loại: {phong.LoaiPhong}";
            lblGiaThue.Text = $"Giá thuê: {phong.GiaThue?.ToString("N0")} VNĐ";
            lblDienTich.Text = $"Diện tích: {phong.DienTich} m²";
            lblTrangThai.Text = $"Trạng thái: {phong.TrangThai}";
            txtTienNghi.Text = phong.TienNghi ?? "Chưa có thông tin";
            lblChuTro.Text = $"Chủ trọ: {phong.ChuNha?.Ten ?? "Không rõ"}";

            if (!string.IsNullOrEmpty(phong.AnhMinhHoa) && File.Exists(phong.AnhMinhHoa))
                picAnhMinhHoa.Image = Image.FromFile(phong.AnhMinhHoa);
            else
                picAnhMinhHoa.Image = SystemIcons.Information.ToBitmap();
        }

        // 🧹 Xóa thông tin khi chưa chọn phòng
        private void XoaThongTinChiTiet()
        {
            lblTenPhong.Text = "Tên phòng: —";
            lblLoaiPhong.Text = "Loại: —";
            lblGiaThue.Text = "Giá thuê: —";
            lblDienTich.Text = "Diện tích: —";
            lblTrangThai.Text = "Trạng thái: —";
            lblChuTro.Text = "Chủ trọ: —";
            txtTienNghi.Text = "";
            picAnhMinhHoa.Image = SystemIcons.Information.ToBitmap();
        }
    }
}
