using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class DichVu : Form
    {
        private Connect db = new Connect(); // EF context

        public DichVu()
        {
            InitializeComponent();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        // 🟢 Hiển thị danh sách dịch vụ
        private void LoadDichVu()
        {
            dgvDichVu.DataSource = db.DichVus
                .Select(d => new
                {
                    d.MaDV,
                    d.TenDV,
                    d.DonGia,
                    d.MoTa
                }).ToList();

            dgvDichVu.ClearSelection();
        }

        // 🟢 Làm mới dữ liệu
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtDonViTinh.Clear();
            txtGhiChu.Clear();
            txtTimKiem.Clear();
            LoadDichVu();
        }

        // 🟢 Khi click vào dòng trong DataGridView
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

        // 🟢 Thêm dịch vụ
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDV.Text) ||
                    string.IsNullOrWhiteSpace(txtTenDV.Text) ||
                    string.IsNullOrWhiteSpace(txtDonGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                    return;
                }

                if (db.DichVus.Any(d => d.MaDV == txtMaDV.Text))
                {
                    MessageBox.Show("Mã dịch vụ đã tồn tại!", "Thông báo");
                    return;
                }

                var dv = new Phong_Tro_DAL.Phong_Tro.DichVu
                {
                    MaDV = txtMaDV.Text.Trim(),
                    TenDV = txtTenDV.Text.Trim(),
                    DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                    MoTa = txtGhiChu.Text.Trim()
                };

                db.DichVus.Add(dv);
                db.SaveChanges();
                LoadDichVu();

                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi");
            }
        }

        // 🟢 Sửa dịch vụ
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDV.Text))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!", "Thông báo");
                    return;
                }

                var dv = db.DichVus.FirstOrDefault(d => d.MaDV == txtMaDV.Text);
                if (dv == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ!", "Thông báo");
                    return;
                }

                dv.TenDV = txtTenDV.Text.Trim();
                dv.DonGia = decimal.Parse(txtDonGia.Text.Trim());
                dv.MoTa = txtGhiChu.Text.Trim();

                db.SaveChanges();
                LoadDichVu();

                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi");
            }
        }

        // 🟢 Xóa dịch vụ
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaDV.Text))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo");
                    return;
                }

                var dv = db.DichVus.FirstOrDefault(d => d.MaDV == txtMaDV.Text);
                if (dv == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ!", "Thông báo");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DichVus.Remove(dv);
                    db.SaveChanges();
                    LoadDichVu();

                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi");
            }
        }

        // 🟢 Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadDichVu();
                return;
            }

            dgvDichVu.DataSource = db.DichVus
                .Where(d => d.MaDV.ToLower().Contains(keyword) ||
                            d.TenDV.ToLower().Contains(keyword))
                .Select(d => new
                {
                    d.MaDV,
                    d.TenDV,
                    d.DonGia,
                    d.MoTa
                }).ToList();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }
    }
}
