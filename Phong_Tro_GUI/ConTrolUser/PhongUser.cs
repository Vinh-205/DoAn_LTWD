using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI
{
    public partial class PhongUser : UserControl
    {
        private readonly PhongBUS _phongBUS;

        public PhongUser(int maKhach)
        {
            InitializeComponent();
            _phongBUS = new PhongBUS();
            this.Load += (s, e) => TaiPhongTheoNguoiThue(maKhach);
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
                                  p.GiaPhong,
                                  p.TrangThai,
                                  p.MoTa
                              })
                              .ToList();

            dgvPhong.DataSource = ds;

            dgvPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvPhong.Columns["GiaPhong"].HeaderText = "Giá thuê (VNĐ)";
            dgvPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvPhong.Columns["MoTa"].HeaderText = "Mô tả";

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
                                  p.GiaPhong,
                                  p.TrangThai,
                                  p.MoTa
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
            lblGiaThue.Text = $"Giá thuê: {phong.GiaPhong.ToString("N0")} VNĐ";
            lblTrangThai.Text = $"Trạng thái: {phong.TrangThai}";
            txtTienNghi.Text = phong.MoTa ?? "Không có mô tả.";
            picAnhMinhHoa.Image = SystemIcons.Information.ToBitmap();
        }

        // 🧹 Xóa thông tin khi chưa chọn phòng
        private void XoaThongTinChiTiet()
        {
            lblTenPhong.Text = "Tên phòng: —";
            lblGiaThue.Text = "Giá thuê: —";
            lblTrangThai.Text = "Trạng thái: —";
            txtTienNghi.Text = "";
            picAnhMinhHoa.Image = SystemIcons.Information.ToBitmap();
        }

        private List<dynamic> LayHopDongTheoKhach(int maKhach)
        {
            using (var db = new Phong_Tro_DAL.PhongTro.Connect())
            {
                return db.HopDongs
                         .Where(hd => hd.MaKhach == maKhach)
                         .Select(hd => new
                         {
                             hd.MaHopDong,
                             hd.MaPhong,
                             hd.MaKhach
                         })
                         .ToList<dynamic>();
            }
        }

        private void TaiPhongTheoNguoiThue(int maKhach)
        {
            var hopDongs = LayHopDongTheoKhach(maKhach);

            if (hopDongs.Count == 0)
            {
                MessageBox.Show("Hiện tại bạn chưa thuê phòng nào.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPhong.DataSource = null;
                return;
            }

            var maPhongs = hopDongs.Select(hd => hd.MaPhong).Distinct().ToList();

            var ds = _phongBUS.LayTatCa()
                              .Where(p => maPhongs.Contains(p.MaPhong))
                              .Select(p => new
                              {
                                  p.MaPhong,
                                  p.TenPhong,
                                  p.GiaPhong,
                                  p.TrangThai,
                                  p.MoTa
                              })
                              .ToList();

            dgvPhong.DataSource = ds;

            dgvPhong.Columns["MaPhong"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvPhong.Columns["GiaPhong"].HeaderText = "Giá thuê (VNĐ)";
            dgvPhong.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvPhong.Columns["MoTa"].HeaderText = "Mô tả";

            dgvPhong.ClearSelection();
            XoaThongTinChiTiet();
        }
    }
}
