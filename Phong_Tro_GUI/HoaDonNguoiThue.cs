using System;
using System.ComponentModel;
using System.Windows.Forms;
using Phong_Tro_BUS;
using System.Linq;

namespace Phong_Tro_GUI
{
    public partial class HoaDonNguoiThue : Form
    {
        private HoaDonBUS hoaDonBUS;

        public HoaDonNguoiThue()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
        }

        private void HoaDonNguoiThue_Load(object sender, EventArgs e)
        {
            // Ngăn lỗi khi mở Designer
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            LoadDanhSachHoaDon();
        }

        private void LoadDanhSachHoaDon()
        {
            try
            {
                var ds = hoaDonBUS.LayTatCa()
                    .Select(hd => new
                    {
                        hd.MaHD,
                        hd.Thang,
                        hd.Nam,
                        hd.GiaPhong,
                        hd.TienDien,
                        hd.TienNuoc,
                        hd.TienDichVu,
                        hd.TongTien,
                        NgayLap = hd.NgayLap?.ToString("dd/MM/yyyy")
                    })
                    .ToList();

                dgvHoaDon.DataSource = ds;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách hóa đơn!\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvHoaDon.Columns["GiaPhong"].HeaderText = "Giá phòng";
            dgvHoaDon.Columns["TienDien"].HeaderText = "Tiền điện";
            dgvHoaDon.Columns["TienNuoc"].HeaderText = "Tiền nước";
            dgvHoaDon.Columns["TienDichVu"].HeaderText = "Dịch vụ";
            dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvHoaDon.DataSource = hoaDonBUS.TimKiem(keyword)
                .Select(hd => new
                {
                    hd.MaHD,
                    hd.Thang,
                    hd.Nam,
                    hd.GiaPhong,
                    hd.TienDien,
                    hd.TienNuoc,
                    hd.TienDichVu,
                    hd.TongTien,
                    NgayLap = hd.NgayLap?.ToString("dd/MM/yyyy")
                }).ToList();
        }
    }
}
