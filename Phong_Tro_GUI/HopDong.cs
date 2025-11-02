using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS.Core;
using DALHopDong = Phong_Tro_DAL.Phong_Tro.HopDong;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class HopDong : Form
    {
        private HopDongBUS bus = new HopDongBUS();

        public HopDong()
        {
            InitializeComponent();
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadDataGridView();
        }

        // Load Phong và KhachThue
        private void LoadComboBox()
        {
            using (var db = new Connect())
            {
                cboPhong.DataSource = db.Phongs.ToList();
                cboPhong.DisplayMember = "TenPhong";
                cboPhong.ValueMember = "MaPhong";

                cboNguoiThue.DataSource = db.KhachThues.ToList();
                cboNguoiThue.DisplayMember = "Ten";
                cboNguoiThue.ValueMember = "MaKhach";
            }
        }

        private void LoadDataGridView()
        {
            var data = bus.LayTatCaHopDong()
                          .Select(h => new
                          {
                              h.MaHopDong,
                              Phong = h.Phong.TenPhong,
                              KhachThue = h.KhachThue.Ten,
                              h.NgayBatDau,
                              h.NgayKetThuc,
                              h.TienCoc,
                              h.TienThue,
                              h.TrangThai,
                              h.GhiChu
                          }).ToList();
            dgvHopDong.DataSource = data;
        }

        // Lấy dữ liệu từ form -> DALHopDong
        private DALHopDong GetFormData()
        {
            if (cboPhong.SelectedValue == null || cboNguoiThue.SelectedValue == null) return null;

            return new DALHopDong
            {
                MaHopDong = string.IsNullOrEmpty(txtMaHD.Text) ? 0 : int.Parse(txtMaHD.Text),
                MaPhong = cboPhong.SelectedValue.ToString(),
                MaKhach = (int)cboNguoiThue.SelectedValue,
                NgayBatDau = dtpNgayBatDau.Value,
                NgayKetThuc = dtpNgayKetThuc.Value,
                TienThue = decimal.TryParse(txtGiaThue.Text, out var gia) ? gia : 0,
                TrangThai = "Đang hiệu lực",
                GhiChu = ""
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var hd = GetFormData();
            if (hd == null) return;

            if (bus.ThemHopDong(hd))
            {
                MessageBox.Show("Thêm hợp đồng thành công!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var hd = GetFormData();
            if (hd == null || hd.MaHopDong == 0) return;

            if (bus.CapNhatHopDong(hd))
            {
                MessageBox.Show("Cập nhật hợp đồng thành công!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text)) return;

            int ma = int.Parse(txtMaHD.Text);
            if (bus.XoaHopDong(ma))
            {
                MessageBox.Show("Xóa hợp đồng thành công!");
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtGiaThue.Clear();
            cboPhong.SelectedIndex = -1;
            cboNguoiThue.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            LoadDataGridView();
        }

        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvHopDong.Rows[e.RowIndex];
            txtMaHD.Text = row.Cells["MaHopDong"].Value.ToString();
            cboPhong.Text = row.Cells["Phong"].Value.ToString();
            cboNguoiThue.Text = row.Cells["KhachThue"].Value.ToString();
            dtpNgayBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
            dtpNgayKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
            txtGiaThue.Text = row.Cells["TienThue"].Value.ToString();
        }

        // Các event trống (có thể để hoặc xóa)
        private void txtMaHD_TextChanged(object sender, EventArgs e) { }
        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboNguoiThue_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e) { }
        private void dtpNgayKetThuc_ValueChanged(object sender, EventArgs e) { }
        private void txtGiaThue_TextChanged(object sender, EventArgs e) { }
    }
}
