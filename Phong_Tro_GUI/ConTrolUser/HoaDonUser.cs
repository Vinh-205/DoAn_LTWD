using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class HoaDonUser : Form
    {
        private Connect db = new Connect(); // EF DbContext

        public HoaDonUser()
        {
            InitializeComponent();
        }

        private void HoaDonNguoiThue_Load(object sender, EventArgs e)
        {
            SetPlaceholder();
            LoadHoaDon();
            SetupGridView();
        }

        private void SetPlaceholder()
        {
            txtTimKiem.Text = "Nhập mã hóa đơn hoặc tên phòng...";
            txtTimKiem.ForeColor = Color.Gray;

            txtTimKiem.Enter += (s, e) =>
            {
                if (txtTimKiem.Text == "Nhập mã hóa đơn hoặc tên phòng...")
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = Color.Black;
                }
            };

            txtTimKiem.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = "Nhập mã hóa đơn hoặc tên phòng...";
                    txtTimKiem.ForeColor = Color.Gray;
                }
            };
        }

        private void SetupGridView()
        {
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvHoaDon.EnableHeadersVisualStyles = false;
            dgvHoaDon.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvHoaDon.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadHoaDon()
        {
            var data = db.HoaDons
                .Include("HopDong.Phong")
                .Select(hd => new
                {
                    hd.MaHD,
                    Phong = hd.HopDong.Phong.TenPhong,
                    hd.Thang,
                    hd.Nam,
                    hd.NgayLap,
                    hd.TongTien
                })
                .ToList();

            dgvHoaDon.DataSource = data;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập mã hóa đơn hoặc tên phòng...") return;

            string keyword = txtTimKiem.Text.Trim().ToLower();

            var data = db.HoaDons
                .Include("HopDong.Phong")
                .Where(hd => hd.MaHD.ToLower().Contains(keyword)
                             || hd.HopDong.Phong.TenPhong.ToLower().Contains(keyword))
                .Select(hd => new
                {
                    hd.MaHD,
                    Phong = hd.HopDong.Phong.TenPhong,
                    hd.Thang,
                    hd.Nam,
                    hd.NgayLap,
                    hd.TongTien
                })
                .ToList();

            dgvHoaDon.DataSource = data;
        }
    }
}
