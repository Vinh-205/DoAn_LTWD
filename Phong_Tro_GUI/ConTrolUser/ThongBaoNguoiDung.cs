using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class ThongBaoNguoiDung : Form
    {
        private readonly ThongBaoBUS _thongBaoBUS;

        public ThongBaoNguoiDung()
        {
            InitializeComponent();
            _thongBaoBUS = new ThongBaoBUS();
        }

        private void ThongBaoNguoiDung_Load(object sender, EventArgs e)
        {
            TaiDanhSachThongBao();
            dgvThongBao.ClearSelection();
        }

        private void TaiDanhSachThongBao()
        {
            var ds = _thongBaoBUS.LayTatCa()
                                 .OrderByDescending(tb => tb.NgayTao)
                                 .Select(tb => new
                                 {
                                     tb.MaTB,
                                     tb.MaPhong,
                                     tb.NoiDung,
                                     NgayTao = tb.NgayTao.HasValue ? tb.NgayTao.Value.ToString("dd/MM/yyyy HH:mm") : ""
                                 })
                                 .ToList();

            dgvThongBao.DataSource = ds;

            dgvThongBao.Columns["MaTB"].HeaderText = "Mã TB";
            dgvThongBao.Columns["MaPhong"].HeaderText = "Phòng";
            dgvThongBao.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvThongBao.Columns["NgayTao"].HeaderText = "Ngày tạo";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var ds = _thongBaoBUS.TimKiem(keyword)
                                 .OrderByDescending(tb => tb.NgayTao)
                                 .Select(tb => new
                                 {
                                     tb.MaTB,
                                     tb.MaPhong,
                                     tb.NoiDung,
                                     NgayTao = tb.NgayTao.HasValue ? tb.NgayTao.Value.ToString("dd/MM/yyyy HH:mm") : ""
                                 })
                                 .ToList();

            dgvThongBao.DataSource = ds;
        }

        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvThongBao.Rows[e.RowIndex];
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                lblPhong.Text = "Phòng: " + row.Cells["MaPhong"].Value?.ToString();
                lblNgay.Text = "Ngày: " + row.Cells["NgayTao"].Value?.ToString();
            }
        }
    }
}
