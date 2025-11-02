using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class PhongMain : UserControl
    {
        private readonly Connect db = new Connect();

        public PhongMain()
        {
            InitializeComponent();
        }

        private void PhongMain_Load(object sender, EventArgs e)
        {
            HienThiDanhSachPhong();
        }

        private void HienThiDanhSachPhong()
        {
            dgvDanhSachPhong.DataSource = db.Phongs
                .Select(p => new
                {
                    p.MaPhong,
                    p.TenPhong,
                    p.GiaThue,
                    p.TrangThai,
                    p.TienNghi
                })
                .ToList();
            dgvDanhSachPhong.ClearSelection();
        }

        private void dgvDanhSachPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaPhong.Text = dgvDanhSachPhong.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = dgvDanhSachPhong.Rows[e.RowIndex].Cells["TenPhong"].Value.ToString();
                txtGiaPhong.Text = dgvDanhSachPhong.Rows[e.RowIndex].Cells["GiaThue"].Value.ToString();
                cboTrangThai.Text = dgvDanhSachPhong.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
                txtMoTa.Text = dgvDanhSachPhong.Rows[e.RowIndex].Cells["TienNghi"].Value?.ToString();
            }
        }

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

                if (db.Phongs.Any(p => p.MaPhong == txtMaPhong.Text))
                {
                    MessageBox.Show("Mã phòng đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaPhong.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var phong = new Phong_Tro_DAL.Phong_Tro.Phong
                {
                    MaPhong = txtMaPhong.Text.Trim(),
                    TenPhong = txtTenPhong.Text.Trim(),
                    GiaThue = gia,
                    TrangThai = cboTrangThai.Text,
                    TienNghi = txtMoTa.Text.Trim()
                };

                db.Phongs.Add(phong);
                db.SaveChanges();

                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDanhSachPhong();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phòng: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var ma = txtMaPhong.Text.Trim();
                var phong = db.Phongs.FirstOrDefault(p => p.MaPhong == ma);
                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtGiaPhong.Text, out decimal gia))
                {
                    MessageBox.Show("Giá phòng không hợp lệ!");
                    return;
                }

                phong.TenPhong = txtTenPhong.Text.Trim();
                phong.GiaThue = gia;
                phong.TrangThai = cboTrangThai.Text;
                phong.TienNghi = txtMoTa.Text.Trim();
                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");
                HienThiDanhSachPhong();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var ma = txtMaPhong.Text.Trim();
                var phong = db.Phongs.FirstOrDefault(p => p.MaPhong == ma);
                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.Phongs.Remove(phong);
                    db.SaveChanges();
                    MessageBox.Show("Đã xóa phòng thành công!");
                    HienThiDanhSachPhong();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

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
