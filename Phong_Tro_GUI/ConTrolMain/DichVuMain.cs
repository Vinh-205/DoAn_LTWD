using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;                  // Kết nối tầng BUS
using Phong_Tro_DAL.PhongTro;        // Kết nối tầng DAL (DichVu, Connect, ...)

namespace Phong_Tro_GUI
{
    public partial class DichVuMain : UserControl
    {
        private readonly DichVuBUS dichVuBUS = new DichVuBUS();

        public DichVuMain()
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadDichVu();
        }

        // ================== KHỞI TẠO DATAGRIDVIEW ==================
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
                Width = 120,
                DefaultCellStyle = { Format = "N0" }
            });

            dgvDichVu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô Tả",
                DataPropertyName = "MoTa",
                Name = "MoTa",
                Width = 250
            });
        }

        // ================== LOAD DỮ LIỆU ==================
        private void LoadDichVu()
        {
            try
            {
                var data = dichVuBUS.LayTatCa()
                    .Select(d => new
                    {
                        d.MaDV,
                        d.TenDV,
                        d.DonGia,
                        d.MoTa
                    })
                    .ToList();

                dgvDichVu.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== HÀM KIỂM TRA ĐƠN GIÁ ==================
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

        // ================== NÚT THÊM ==================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryGetDonGia(out decimal donGia)) return;

                var dv = new DichVu
                {
                    MaDV = txtMaDV.Text.Trim(),
                    TenDV = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtGhiChu.Text.Trim()
                };

                dichVuBUS.Them(dv);
                LoadDichVu();
                MessageBox.Show("✅ Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi thêm dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== NÚT SỬA ==================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryGetDonGia(out decimal donGia)) return;

                var dv = new DichVu
                {
                    MaDV = txtMaDV.Text.Trim(),
                    TenDV = txtTenDV.Text.Trim(),
                    DonGia = donGia,
                    MoTa = txtGhiChu.Text.Trim()
                };

                dichVuBUS.Sua(dv);
                LoadDichVu();
                MessageBox.Show("✅ Cập nhật dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== NÚT XÓA ==================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maDV = txtMaDV.Text.Trim();
                if (string.IsNullOrEmpty(maDV))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa dịch vụ {maDV}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dichVuBUS.Xoa(maDV);
                    LoadDichVu();
                    MessageBox.Show("✅ Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi xóa dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== CLICK DATAGRIDVIEW ==================
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["MaDV"].Value?.ToString();
                txtTenDV.Text = row.Cells["TenDV"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
                txtGhiChu.Text = row.Cells["MoTa"].Value?.ToString();
            }
        }

        // ================== NÚT LÀM MỚI ==================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();
            LoadDichVu();
        }

        // ================== NÚT TÌM KIẾM ==================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                var result = string.IsNullOrWhiteSpace(tuKhoa)
                    ? dichVuBUS.LayTatCa()
                    : dichVuBUS.TimKiem(tuKhoa);

                dgvDichVu.DataSource = result
                    .Select(d => new
                    {
                        d.MaDV,
                        d.TenDV,
                        d.DonGia,
                        d.MoTa
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
