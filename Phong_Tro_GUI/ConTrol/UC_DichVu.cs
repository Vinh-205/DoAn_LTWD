using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_DAL.Phong_Tro;
using Phong_Tro_BUS;


namespace Phong_Tro_GUI
{
    public partial class UC_DichVu : UserControl
    {
        private readonly DichVuBUS dichVuBUS = new DichVuBUS();

        public UC_DichVu()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadDichVu();
        }

        // ======== Khởi tạo DataGridView ========
        private void InitializeDataGridView()
        {
            dgvDichVu.AutoGenerateColumns = false;
            dgvDichVu.Columns.Clear();

            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã DV",
                DataPropertyName = "MaDV",
                Name = "MaDV",
                Width = 100
            });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên DV",
                DataPropertyName = "TenDV",
                Name = "TenDV",
                Width = 200
            });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn Giá",
                DataPropertyName = "DonGia",
                Name = "DonGia",
                Width = 100
            });
            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô Tả",
                DataPropertyName = "MoTa",
                Name = "MoTa",
                Width = 300
            });
        }

        // ======== Load dữ liệu lên DataGridView ========
        private void LoadDichVu()
        {
            dgvDichVu.DataSource = dichVuBUS.LayTatCa()
                .Select(d => new
                {
                    d.MaDV,
                    d.TenDV,
                    d.DonGia,
                    d.MoTa
                }).ToList();
        }

        // ======== Validate DonGia ========
        private bool TryGetDonGia(out decimal donGia)
        {
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }
            return true;
        }

        // ======== Thêm dịch vụ ========
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryGetDonGia(out decimal donGia)) return;

                var dv = new Phong_Tro_DAL.Phong_Tro.DichVu
                {
                    MaDV = txtMaDV.Text.Trim(),
                    TenDV = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtGhiChu.Text.Trim()
                };

                dichVuBUS.Them(dv);
                LoadDichVu();
                MessageBox.Show("Thêm dịch vụ thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======== Sửa dịch vụ ========
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryGetDonGia(out decimal donGia)) return;

                var dv = new Phong_Tro_DAL.Phong_Tro.DichVu
                {
                    MaDV = txtMaDV.Text.Trim(),
                    TenDV = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtGhiChu.Text.Trim()
                };

                dichVuBUS.Sua(dv);
                LoadDichVu();
                MessageBox.Show("Cập nhật dịch vụ thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======== Xóa dịch vụ ========
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDV = txtMaDV.Text.Trim();
                if (string.IsNullOrWhiteSpace(maDV))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa dịch vụ {maDV}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dichVuBUS.Xoa(maDV);
                    LoadDichVu();
                    MessageBox.Show("Xóa dịch vụ thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======== Click vào DataGridView ========
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaDV"].Value?.ToString() ?? "";
                txtTenDV.Text = row.Cells["TenDV"].Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "";
                txtGhiChu.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
            }
        }

        // ======== Làm mới form ========
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();
            LoadDichVu();
        }

        // ======== Tìm kiếm ========
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var result = string.IsNullOrWhiteSpace(keyword) ? dichVuBUS.LayTatCa() : dichVuBUS.TimKiem(keyword);
            dgvDichVu.DataSource = result.Select(d => new
            {
                d.MaDV,
                d.TenDV,
                d.DonGia,
                d.MoTa
            }).ToList();
        }
    }
}
