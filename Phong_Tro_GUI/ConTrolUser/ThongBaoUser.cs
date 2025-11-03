using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI.ConTrolUser
{
    public partial class ThongBaoUser : UserControl
    {
        private readonly ThongBaoBUS _thongBaoBUS;

        public ThongBaoUser()
        {
            InitializeComponent();
            _thongBaoBUS = new ThongBaoBUS();
        }

        private void ThongBaoUser_Load(object sender, EventArgs e)
        {
            TaiDanhSachThongBao();
            dgvThongBao.ClearSelection();
        }

        private void TaiDanhSachThongBao()
        {
            // Lấy danh sách thông báo không có NgayTao
            var ds = _thongBaoBUS.LayTatCa()
                                 .OrderByDescending(tb => tb.MaTB)
                                 .Select(tb => new
                                 {
                                     tb.MaTB,
                                     tb.NoiDung,
                                     tb.NgayGui,
                                     tb.DaDoc,
                                     tb.MaTK_Nhan,
                                 })
                                 .ToList();

            dgvThongBao.DataSource = ds;

            dgvThongBao.Columns["MaTB"].HeaderText = "Mã TB";
            dgvThongBao.Columns["MaPhong"].HeaderText = "Phòng";
            dgvThongBao.Columns["NoiDung"].HeaderText = "Nội dung";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            var ds = _thongBaoBUS.TimKiem(keyword)
                                 .OrderByDescending(tb => tb.MaTB)
                                 .Select(tb => new
                                 {
                                     tb.MaTB,
                                     tb.DaDoc,
                                     tb.MaTK_Nhan,
                                     tb.MaTK_Gui,
                                     tb.NoiDung
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
                lblNgay.Text = "Ngày: Không xác định";
            }
        }
    }
}
