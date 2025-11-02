using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI.ConTrolMain
{
    public partial class HopDongMain : UserControl
    {
        private HopDongBUS bus = new HopDongBUS();
        private Connect db = new Connect();

        public HopDongMain()
        {
            InitializeComponent();
            this.Load += HopDongMain_Load;
        }

        private void HopDongMain_Load(object sender, EventArgs e)
        {
            // Load dữ liệu theo đúng thứ tự
            LoadPhong();
            LoadKhachThue();
            LoadDanhSachHopDong();
            ClearFields();
        }

        // ==================== LOAD DỮ LIỆU ====================
        private void LoadDanhSachHopDong()
        {
            dgvHopDong.DataSource = bus.LayTatCa()
                .Select(hd => new
                {
                    hd.MaHopDong,
                    hd.MaPhong,
                    hd.MaKhach,
                    TenKhach = hd.KhachThue != null ? hd.KhachThue.Ten : "",
                    hd.NgayBatDau,
                    hd.NgayKetThuc,
                    hd.TienCoc,
                    hd.TienThue,
                    hd.TrangThai,
                    hd.GhiChu
                }).ToList();
        }

        private void LoadPhong()
        {
            var phongList = db.Phongs.ToList();
            cboPhong.DataSource = phongList;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
            if (phongList.Count > 0)
                cboPhong.SelectedIndex = 0;
        }

        private void LoadKhachThue()
        {
            var khList = db.KhachThues.ToList();
            cboNguoiThue.DataSource = khList;
            cboNguoiThue.DisplayMember = "Ten";
            cboNguoiThue.ValueMember = "MaKhach";
            if (khList.Count > 0)
                cboNguoiThue.SelectedIndex = 0;
        }

        // ==================== LÀM MỚI ====================
        private void ClearFields()
        {
            txtMaHD.Clear();
            cboPhong.SelectedIndex = -1;
            cboNguoiThue.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtGiaThue.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadDanhSachHopDong();
        }

        // ==================== THÊM ====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPhong.SelectedValue == null || cboNguoiThue.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ phòng và khách thuê!");
                    return;
                }

                HopDong hd = new HopDong
                {
                    MaPhong = cboPhong.SelectedValue.ToString(),
                    MaKhach = Convert.ToInt32(cboNguoiThue.SelectedValue),
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayKetThuc = dtpNgayKetThuc.Value,
                    TienThue = decimal.TryParse(txtGiaThue.Text, out decimal tt) ? tt : 0
                };

                bus.Them(hd);
                MessageBox.Show("Thêm hợp đồng thành công!");
                LoadDanhSachHopDong();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hợp đồng: " + ex.Message);
            }
        }

        // ==================== SỬA ====================
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng cần sửa!");
                    return;
                }

                HopDong hd = new HopDong
                {
                    MaHopDong = Convert.ToInt32(txtMaHD.Text),
                    MaPhong = cboPhong.SelectedValue.ToString(),
                    MaKhach = Convert.ToInt32(cboNguoiThue.SelectedValue),
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayKetThuc = dtpNgayKetThuc.Value,
                    TienThue = decimal.TryParse(txtGiaThue.Text, out decimal tt) ? tt : 0
                };

                bus.Sua(hd);
                MessageBox.Show("Sửa hợp đồng thành công!");
                LoadDanhSachHopDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa hợp đồng: " + ex.Message);
            }
        }

        // ==================== XÓA ====================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng cần xóa!");
                    return;
                }

                int maHD = Convert.ToInt32(txtMaHD.Text);

                if (MessageBox.Show("Bạn có chắc muốn xóa hợp đồng này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bus.Xoa(maHD);
                    MessageBox.Show("Xóa hợp đồng thành công!");
                    LoadDanhSachHopDong();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa hợp đồng: " + ex.Message);
            }
        }

        // ==================== CLICK DỮ LIỆU ====================
        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHopDong.Rows[e.RowIndex].Cells["MaHopDong"].Value == null)
                return;

            var row = dgvHopDong.Rows[e.RowIndex];
            txtMaHD.Text = row.Cells["MaHopDong"].Value.ToString();
            cboPhong.SelectedValue = row.Cells["MaPhong"].Value.ToString();
            cboNguoiThue.SelectedValue = row.Cells["MaKhach"].Value;

            if (DateTime.TryParse(row.Cells["NgayBatDau"].Value?.ToString(), out DateTime nbd))
                dtpNgayBatDau.Value = nbd;

            if (DateTime.TryParse(row.Cells["NgayKetThuc"].Value?.ToString(), out DateTime nkt))
                dtpNgayKetThuc.Value = nkt;

            txtGiaThue.Text = row.Cells["TienThue"].Value?.ToString();
        }
    }
}
