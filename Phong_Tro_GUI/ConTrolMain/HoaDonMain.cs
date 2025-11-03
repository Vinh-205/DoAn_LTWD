using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI
{
    public partial class HoaDonMain : UserControl
    {
        private readonly HoaDonBUS hoaDonBUS;
        private readonly HopDongBUS hopDongBUS;

        public HoaDonMain()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
            hopDongBUS = new HopDongBUS();

            LoadComboBox();
            LoadDataGrid();
        }

        private void LoadComboBox()
        {
            try
            {
                var hopDongList = hopDongBUS.LayTatCa()
                    .Where(h => h.TrangThai == "Đang hoạt động")
                    .ToList();

                // Hiển thị tên phòng, giá trị thực là MaHopDong
                cbPhong.DataSource = hopDongList;
                cbPhong.DisplayMember = "Phong.TenPhong";
                cbPhong.ValueMember = "MaHopDong";

                cbPhongThongBao.DataSource = hopDongList.ToList();
                cbPhongThongBao.DisplayMember = "Phong.TenPhong";
                cbPhongThongBao.ValueMember = "MaHopDong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách phòng: " + ex.Message);
            }
        }

        private void LoadDataGrid()
        {
            try
            {
                var list = hoaDonBUS.LayTatCa();
                dgvHoaDon.DataSource = list.Select(hd => new
                {
                    hd.MaHD,
                    KhachHang = hd.HopDong.KhachThue.Ten,
                    Phong = hd.HopDong.Phong.TenPhong,
                    hd.Thang,
                    hd.Nam,
                    hd.TienDien,
                    hd.TienNuoc,
                    hd.TienDichVu,
                    hd.GiaPhong,
                    hd.TongTien,
                    hd.NgayLap
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu hóa đơn: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtMaHD.Clear();
            txtTenKH.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtTienPhong.Clear();
            txtTongTien.Clear();
            dtpNgayLap.Value = DateTime.Now;
            cbPhong.SelectedIndex = -1;
            cbTrangThai.SelectedIndex = -1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDataGrid();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPhong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng hợp đồng!");
                    return;
                }

                var hd = new HoaDon
                {
                    MaHD = txtMaHD.Text.Trim(),
                    MaHopDong = (int)cbPhong.SelectedValue,
                    Thang = dtpNgayLap.Value.Month,
                    Nam = dtpNgayLap.Value.Year,
                    SoDienCu = 0,
                    SoDienMoi = 0,
                    SoNuocCu = 0,
                    SoNuocMoi = 0,
                    TienDien = string.IsNullOrEmpty(txtTienDien.Text) ? 0 : decimal.Parse(txtTienDien.Text),
                    TienNuoc = string.IsNullOrEmpty(txtTienNuoc.Text) ? 0 : decimal.Parse(txtTienNuoc.Text),
                    GiaPhong = string.IsNullOrEmpty(txtTienPhong.Text) ? 0 : decimal.Parse(txtTienPhong.Text),
                    NgayLap = dtpNgayLap.Value
                };

                hd.TongTien = hoaDonBUS.TinhTongTien(hd);

                hoaDonBUS.Them(hd);
                MessageBox.Show("Thêm hóa đơn thành công!");
                LoadDataGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để sửa!");
                    return;
                }

                var selectedMaHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
                var hd = hoaDonBUS.LayTheoMa(selectedMaHD);

                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn để sửa!");
                    return;
                }

                if (cbPhong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng hợp đồng!");
                    return;
                }

                hd.MaHopDong = (int)cbPhong.SelectedValue;
                hd.Thang = dtpNgayLap.Value.Month;
                hd.Nam = dtpNgayLap.Value.Year;
                hd.TienDien = string.IsNullOrEmpty(txtTienDien.Text) ? 0 : decimal.Parse(txtTienDien.Text);
                hd.TienNuoc = string.IsNullOrEmpty(txtTienNuoc.Text) ? 0 : decimal.Parse(txtTienNuoc.Text);
                hd.GiaPhong = string.IsNullOrEmpty(txtTienPhong.Text) ? 0 : decimal.Parse(txtTienPhong.Text);
                hd.NgayLap = dtpNgayLap.Value;
                hd.TongTien = hoaDonBUS.TinhTongTien(hd);

                hoaDonBUS.Sua(hd);
                MessageBox.Show("Sửa hóa đơn thành công!");
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để xóa!");
                    return;
                }

                var selectedMaHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
                if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    hoaDonBUS.Xoa(selectedMaHD);
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    LoadDataGrid();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var keyword = txtTimKiem.Text.Trim();
                var list = hoaDonBUS.TimKiem(keyword);
                dgvHoaDon.DataSource = list.Select(hd => new
                {
                    hd.MaHD,
                    KhachHang = hd.HopDong.KhachThue.Ten,
                    Phong = hd.HopDong.Phong.TenPhong,
                    hd.Thang,
                    hd.Nam,
                    hd.TienDien,
                    hd.TienNuoc,
                    hd.TienDichVu,
                    hd.GiaPhong,
                    hd.TongTien,
                    hd.NgayLap
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHD"].Value.ToString();
                txtTenKH.Text = row.Cells["KhachHang"].Value.ToString();
                txtTienDien.Text = row.Cells["TienDien"].Value.ToString();
                txtTienNuoc.Text = row.Cells["TienNuoc"].Value.ToString();
                txtTienPhong.Text = row.Cells["GiaPhong"].Value.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value.ToString();
                dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);

                // Chọn phòng tương ứng
                cbPhong.SelectedValue = hoaDonBUS.LayTheoMa(row.Cells["MaHD"].Value.ToString()).MaHopDong;
            }
        }
    }
}
