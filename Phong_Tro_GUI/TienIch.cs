using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_DAL.Phong_Tro;
using Phong_Tro_BUS.Core;

namespace Phong_Tro_GUI
{
    public partial class TienIch : Form
    {
        private readonly TienIchBUS tienIchBUS = new TienIchBUS();

        public TienIch()
        {
            InitializeComponent();
        }

        private void TienIch_Load(object sender, EventArgs e)
        {
            LoadTienIch();
        }

        // 🟢 Hàm load danh sách tiện ích
        private void LoadTienIch()
        {
            dgvDichVu.DataSource = tienIchBUS.LayTatCaTienIch()
                .Select(t => new
                {
                    t.MaTienIch,
                    t.TenTienIch,
                    DonGia = t.DonGia.HasValue ? t.DonGia.Value.ToString("N0") : "0",
                    t.MoTa
                })
                .ToList();

            dgvDichVu.ClearSelection();
        }

        // 🟢 Khi chọn dòng trong DataGridView
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaTienIch"].Value?.ToString();
                txtTenDV.Text = row.Cells["TenTienIch"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();
            }
        }

        // 🟢 Thêm tiện ích
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenDV.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên tiện ích!", "Thông báo");
                    return;
                }

                decimal donGia = 0;
                decimal.TryParse(txtDonGia.Text, out donGia);

                var tienIch = new Phong_Tro_DAL.Phong_Tro.TienIch
                {
                    TenTienIch = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtMoTa.Text.Trim()
                };

                if (tienIchBUS.ThemTienIch(tienIch))
                {
                    MessageBox.Show("Thêm tiện ích thành công!", "Thông báo");
                    LoadTienIch();
                    LamMoiForm();
                }
                else
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tiện ích: " + ex.Message);
            }
        }

        // 🟢 Sửa tiện ích
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDV.Text))
                {
                    MessageBox.Show("Vui lòng chọn tiện ích cần sửa!", "Thông báo");
                    return;
                }

                int ma = int.Parse(txtMaDV.Text);
                decimal donGia = 0;
                decimal.TryParse(txtDonGia.Text, out donGia);

                var t = new Phong_Tro_DAL.Phong_Tro.TienIch
                {
                    MaTienIch = ma,
                    TenTienIch = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtMoTa.Text.Trim()
                };

                if (tienIchBUS.CapNhatTienIch(t))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    LoadTienIch();
                    LamMoiForm();
                }
                else
                    MessageBox.Show("Không tìm thấy tiện ích cần sửa!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa tiện ích: " + ex.Message);
            }
        }

        // 🟢 Xóa tiện ích
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDV.Text))
                {
                    MessageBox.Show("Vui lòng chọn tiện ích cần xóa!", "Thông báo");
                    return;
                }

                int ma = int.Parse(txtMaDV.Text);
                if (MessageBox.Show("Bạn có chắc muốn xóa tiện ích này không?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (tienIchBUS.XoaTienIch(ma))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadTienIch();
                        LamMoiForm();
                    }
                    else
                        MessageBox.Show("Không thể xóa tiện ích!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tiện ích: " + ex.Message);
            }
        }

        // 🟢 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            LoadTienIch();
        }

        private void LamMoiForm()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtMoTa.Clear();
            dgvDichVu.ClearSelection();
        }

        // 🟢 Tìm kiếm tiện ích theo tên
        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTenDV.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadTienIch();
                return;
            }

            dgvDichVu.DataSource = tienIchBUS.TimKiemTheoTen(keyword)
                .Select(t => new
                {
                    t.MaTienIch,
                    t.TenTienIch,
                    DonGia = t.DonGia.HasValue ? t.DonGia.Value.ToString("N0") : "0",
                    t.MoTa
                })
                .ToList();
        }
    }
}
