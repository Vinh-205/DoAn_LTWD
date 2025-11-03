using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI.ConTrolMain
{
    public partial class ThongBaoMain : UserControl
    {
        private readonly ThongBaoBUS _thongBaoBUS = new ThongBaoBUS();
        private readonly PhongBUS _phongBUS = new PhongBUS();

        public ThongBaoMain()
        {
            InitializeComponent();
            this.Load += ThongBaoMain_Load;
        }

        private void ThongBaoMain_Load(object sender, EventArgs e)
        {
            TaiDanhSachNguoiNhan();
            TaiDanhSachThongBao();
            dtNgayGui.Value = DateTime.Now;
        }

        // ==================== LOAD NGƯỜI NHẬN ====================
        private void TaiDanhSachNguoiNhan()
        {
            var listPhong = _phongBUS.LayTatCa();
            cboNguoiNhan.DataSource = listPhong;
            cboNguoiNhan.DisplayMember = "TenPhong";
            cboNguoiNhan.ValueMember = "MaPhong";
            cboNguoiNhan.SelectedIndex = -1;
        }

        // ==================== LOAD DANH SÁCH THÔNG BÁO ====================
        private void TaiDanhSachThongBao()
        {
            var ds = _thongBaoBUS.LayTatCa();
            dgvThongBao.DataSource = ds.Select(tb => new
            {
                tb.MaTB,
                tb.MaPhong,
                tb.NoiDung,
                NgayTao = tb.NgayTao.ToString("dd/MM/yyyy HH:mm") ?? ""
            }).ToList();

            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongBao.ClearSelection();
        }

        // ==================== LÀM MỚI ====================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            cboNguoiNhan.SelectedIndex = -1;
            dtNgayGui.Value = DateTime.Now;
            TaiDanhSachThongBao();
        }

        // ==================== THÊM THÔNG BÁO ====================
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text) || cboNguoiNhan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập nội dung và chọn người nhận.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tb = new ThongBao
            {
                MaPhong = cboNguoiNhan.SelectedValue.ToString(),
                NoiDung = txtNoiDung.Text.Trim(),
                NgayTao = DateTime.Now
            };

            try
            {
                bool ketQua = _thongBaoBUS.Them(tb);
                if (ketQua)
                {
                    MessageBox.Show("Gửi thông báo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachThongBao();
                    btnLamMoi.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi thông báo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== XÓA ====================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thông báo cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTB"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa thông báo này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool kq = _thongBaoBUS.Xoa(maTB);
                    if (kq)
                    {
                        MessageBox.Show("Đã xóa thông báo!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachThongBao();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa thông báo: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== SỬA ====================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thông báo để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTB"].Value);

            var tb = new ThongBao
            {
                MaTB = maTB,
                MaPhong = cboNguoiNhan.SelectedValue?.ToString(),
                NoiDung = txtNoiDung.Text.Trim(),
                NgayTao = dtNgayGui.Value
            };

            try
            {
                bool kq = _thongBaoBUS.Sua(tb);
                if (kq)
                {
                    MessageBox.Show("Đã cập nhật thông báo!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachThongBao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thông báo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CLICK DỮ LIỆU ====================
        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvThongBao.Rows[e.RowIndex];

            // Nội dung
            txtNoiDung.Text = row.Cells["NoiDung"]?.Value?.ToString() ?? "";

            // MaPhong
            if (row.Cells["MaPhong"]?.Value != null)
                cboNguoiNhan.SelectedValue = row.Cells["MaPhong"].Value.ToString();
            else
                cboNguoiNhan.SelectedIndex = -1;

            // NgayTao
            if (DateTime.TryParse(row.Cells["NgayTao"]?.Value?.ToString(), out DateTime dt))
                dtNgayGui.Value = dt;
            else
                dtNgayGui.Value = DateTime.Now;
        }

    }
}
