using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class ThongBaoMain : Form
    {
        private readonly ThongBaoBUS _thongBaoBUS = new ThongBaoBUS();

        public ThongBaoMain()
        {
            InitializeComponent();
            Load += ThongBaoo_Load;
        }

        private void ThongBaoo_Load(object sender, EventArgs e)
        {
            TaiDanhSachThongBao();
            TaiDanhSachNguoiNhan();
            dtNgayGui.Value = DateTime.Now;
        }

        /// <summary>
        /// Nạp danh sách phòng để chọn người nhận
        /// </summary>
        private void TaiDanhSachNguoiNhan()
        {
            var listPhong = _thongBaoBUS.LayDanhSachPhong(); // BUS trả về danh sách phòng

            cboNguoiNhan.DataSource = listPhong;
            cboNguoiNhan.DisplayMember = "TenPhong";
            cboNguoiNhan.ValueMember = "MaPhong";
        }

        /// <summary>
        /// Nạp danh sách thông báo
        /// </summary>
        private void TaiDanhSachThongBao()
        {
            var ds = _thongBaoBUS.LayTatCa();

            dgvThongBao.DataSource = ds.Select(tb => new
            {
                tb.MaTB,
                tb.MaPhong,
                tb.NoiDung,
                NgayTao = tb.NgayTao.HasValue ? tb.NgayTao.Value.ToString("dd/MM/yyyy HH:mm") : ""
            }).ToList();

            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtNoiDung.Clear();
            cboNguoiNhan.SelectedIndex = -1;
            dtNgayGui.Value = DateTime.Now;
            TaiDanhSachThongBao();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text) || cboNguoiNhan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập nội dung và chọn người nhận.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var tb = new ThongBao
                {
                    MaPhong = cboNguoiNhan.SelectedValue.ToString(),
                    NoiDung = txtNoiDung.Text.Trim(),
                    NgayTao = DateTime.Now
                };

                bool ketQua = _thongBaoBUS.Them(tb);

                if (ketQua)
                {
                    MessageBox.Show("Gửi thông báo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachThongBao();
                    btnLamMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Gửi thông báo thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    else
                    {
                        MessageBox.Show("Không thể xóa thông báo!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvThongBao.Rows[e.RowIndex];
                txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();
                cboNguoiNhan.SelectedValue = row.Cells["MaPhong"].Value.ToString();

                if (DateTime.TryParse(row.Cells["NgayTao"].Value.ToString(), out DateTime dt))
                    dtNgayGui.Value = dt;
            }
        }

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
                MaPhong = cboNguoiNhan.SelectedValue.ToString(),
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
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDaDoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này chỉ để hiển thị, vì bảng ThongBao không có cột DaDoc.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
