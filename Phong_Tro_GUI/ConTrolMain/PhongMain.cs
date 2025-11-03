using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI
{
    public partial class PhongMain : UserControl
    {
        private readonly PhongBUS bus = new PhongBUS();

        public PhongMain()
        {
            InitializeComponent();
            this.Load += PhongMain_Load;
        }

        private void PhongMain_Load(object sender, EventArgs e)
        {
            HienThiDanhSachPhong();
            LamMoi();
        }

        // ==================== LOAD DỮ LIỆU ====================
        private void HienThiDanhSachPhong()
        {
            var phongList = bus.LayTatCa();
            dgvDanhSachPhong.DataSource = phongList
                .Select(p => new
                {
                    p.MaPhong,
                    p.TenPhong,
                    p.GiaPhong,
                    p.TrangThai,
                    MoTa = p.MoTa
                })
                .ToList();
            dgvDanhSachPhong.ClearSelection();
        }

        private void dgvDanhSachPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvDanhSachPhong.Rows[e.RowIndex];
            txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString();
            txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString();
            txtGiaPhong.Text = row.Cells["GiaPhong"].Value?.ToString();
            cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
        }

        // ==================== THÊM ====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhong.Text) ||
                    string.IsNullOrWhiteSpace(txtTenPhong.Text) ||
                    string.IsNullOrWhiteSpace(txtGiaPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaPhong.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var phong = new Phong
                {
                    MaPhong = txtMaPhong.Text.Trim(),
                    TenPhong = txtTenPhong.Text.Trim(),
                    GiaPhong = gia,
                    TrangThai = cboTrangThai.Text,
                    MoTa = txtMoTa.Text.Trim()
                };

                bus.Them(phong);
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhong();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phòng: " + ex.Message);
            }
        }

        // ==================== SỬA ====================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaPhong.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var phong = new Phong
                {
                    MaPhong = txtMaPhong.Text.Trim(),
                    TenPhong = txtTenPhong.Text.Trim(),
                    GiaPhong = gia,
                    TrangThai = cboTrangThai.Text,
                    MoTa = txtMoTa.Text.Trim()
                };

                bus.Sua(phong);
                MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhong();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        // ==================== XÓA ====================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
                {
                    MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bus.Xoa(txtMaPhong.Text.Trim());
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSachPhong();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        // ==================== LÀM MỚI ====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            txtGiaPhong.Clear();
            txtMoTa.Clear();
            cboTrangThai.SelectedIndex = -1;
            dgvDanhSachPhong.ClearSelection();
        }
    }
}
