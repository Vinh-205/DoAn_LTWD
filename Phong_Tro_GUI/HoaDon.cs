using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS.Core;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class HoaDon : Form
    {
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();

        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            TaiDuLieuHoaDon();
            TaiPhongLenCombobox();
        }

        // ======================== LOAD DATA ========================
        private void TaiDuLieuHoaDon()
        {
            dgvHoaDon.DataSource = hoaDonBUS.LayTatCa()
                .Select(h => new
                {
                    h.MaHD,
                    h.HopDong.MaHopDong,
                    TenPhong = h.HopDong.Phong.TenPhong,
                    h.Thang,
                    h.Nam,
                    h.TienDien,
                    h.TienNuoc,
                    h.GiaPhong,
                    h.TongTien,
                    h.NgayLap
                }).ToList();
        }

        private void TaiPhongLenCombobox()
        {
            using (var db = new Connect())
            {
                var dsPhong = db.HopDongs
                    .Select(p => new { p.MaHopDong, TenPhong = p.Phong.TenPhong })
                    .ToList();

                cbPhong.DataSource = dsPhong;
                cbPhong.DisplayMember = "TenPhong";
                cbPhong.ValueMember = "MaHopDong";
            }
        }

        private void LamMoiForm()
        {
            txtMaHD.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtTienPhong.Clear();
            txtTongTien.Clear();
            txtTimKiem.Clear();
            cbPhong.SelectedIndex = -1;
            cbTrangThai.SelectedIndex = -1;
            dtpNgayLap.Value = DateTime.Now;
        }

        // ======================== SỰ KIỆN ========================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var hoaDon = new Phong_Tro_DAL.Phong_Tro.HoaDon
                {
                    MaHD = txtMaHD.Text.Trim(),
                    MaHopDong = Convert.ToInt32(cbPhong.SelectedValue),
                    Thang = DateTime.Now.Month,
                    Nam = DateTime.Now.Year,
                    TienDien = decimal.TryParse(txtTienDien.Text, out var td) ? td : 0,
                    TienNuoc = decimal.TryParse(txtTienNuoc.Text, out var tn) ? tn : 0,
                    GiaPhong = decimal.TryParse(txtTienPhong.Text, out var gp) ? gp : 0,
                    TongTien = decimal.TryParse(txtTongTien.Text, out var tong) ? tong : 0,
                    NgayLap = dtpNgayLap.Value
                };

                if (hoaDonBUS.ThemHoaDon(hoaDon))
                {
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    TaiDuLieuHoaDon();
                    LamMoiForm();
                }
                else
                {
                    MessageBox.Show("Không thể thêm hóa đơn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hóa đơn: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var hoaDon = new Phong_Tro_DAL.Phong_Tro.HoaDon
                {
                    MaHD = txtMaHD.Text.Trim(),
                    MaHopDong = Convert.ToInt32(cbPhong.SelectedValue),
                    Thang = DateTime.Now.Month,
                    Nam = DateTime.Now.Year,
                    TienDien = decimal.TryParse(txtTienDien.Text, out var td) ? td : 0,
                    TienNuoc = decimal.TryParse(txtTienNuoc.Text, out var tn) ? tn : 0,
                    GiaPhong = decimal.TryParse(txtTienPhong.Text, out var gp) ? gp : 0,
                    TongTien = decimal.TryParse(txtTongTien.Text, out var tong) ? tong : 0,
                    NgayLap = dtpNgayLap.Value
                };


                if (hoaDonBUS.CapNhatHoaDon(hoaDon))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    TaiDuLieuHoaDon();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn để cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa hóa đơn: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
                return;
            }

            if (hoaDonBUS.XoaHoaDon(txtMaHD.Text.Trim()))
            {
                MessageBox.Show("Xóa hóa đơn thành công!");
                TaiDuLieuHoaDon();
                LamMoiForm();
            }
            else
            {
                MessageBox.Show("Không thể xóa hóa đơn!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            TaiDuLieuHoaDon();
        }

        // ======================== TÍNH TOÁN ========================
        private void txtTienDien_TextChanged(object sender, EventArgs e) => TinhTongTien();
        private void txtTienNuoc_TextChanged(object sender, EventArgs e) => TinhTongTien();
        private void txtTienPhong_TextChanged(object sender, EventArgs e) => TinhTongTien();

        private void TinhTongTien()
        {
            decimal.TryParse(txtTienDien.Text, out var td);
            decimal.TryParse(txtTienNuoc.Text, out var tn);
            decimal.TryParse(txtTienPhong.Text, out var tp);

            txtTongTien.Text = (td + tn + tp).ToString("N0");
        }

        // ======================== TÌM KIẾM ========================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim().ToLower();
            var ds = hoaDonBUS.LayTatCa()
                .Where(h => h.MaHD.ToLower().Contains(key)
                         || h.HopDong.Phong.TenPhong.ToLower().Contains(key))
                .Select(h => new
                {
                    h.MaHD,
                    h.HopDong.MaHopDong,
                    TenPhong = h.HopDong.Phong.TenPhong,
                    h.Thang,
                    h.Nam,
                    h.TienDien,
                    h.TienNuoc,
                    h.GiaPhong,
                    h.TongTien,
                    h.NgayLap
                }).ToList();

            dgvHoaDon.DataSource = ds;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                TaiDuLieuHoaDon();
        }

        // ======================== GRID CLICK ========================
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHD"].Value.ToString();
                txtTienDien.Text = row.Cells["TienDien"].Value.ToString();
                txtTienNuoc.Text = row.Cells["TienNuoc"].Value.ToString();
                txtTienPhong.Text = row.Cells["GiaPhong"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
            }
        }
    }
}
