using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS.Services;

namespace Phong_Tro_GUI
{
    public partial class UC_ThongKeDoanhThu : UserControl
    {
        private readonly ThongKeBUS thongKeBUS = new ThongKeBUS();

        public UC_ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void UC_ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Load combobox tháng, năm
            cboThang.Items.AddRange(Enumerable.Range(1, 12).Select(x => (object)x).ToArray());
            cboNam.Items.AddRange(Enumerable.Range(2020, 10).Select(x => (object)x).ToArray());
            cboThang.SelectedIndex = DateTime.Now.Month - 1;
            cboNam.SelectedItem = DateTime.Now.Year;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedItem == null || cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm để thống kê!", "Thông báo");
                return;
            }

            int thang = Convert.ToInt32(cboThang.SelectedItem);
            int nam = Convert.ToInt32(cboNam.SelectedItem);

            // Load dữ liệu hóa đơn
            var dsHoaDon = thongKeBUS.LayDanhSachHoaDon(thang, nam);
            dgvHoaDon.DataSource = dsHoaDon;

            // Load tổng hợp
            txtSoHD.Text = thongKeBUS.DemSoHoaDon(thang, nam).ToString();
            txtTongTien.Text = thongKeBUS.TinhTongDoanhThu(thang, nam).ToString("N0") + " VNĐ";
            txtTBHoaDon.Text = thongKeBUS.TinhTrungBinhHoaDon(thang, nam).ToString("N0") + " VNĐ";

            // Load biểu đồ (Chart)
            var dataChart = thongKeBUS.LayDoanhThuTheoDichVu(thang, nam);
            chart1.Series[0].Points.Clear();
            foreach (dynamic item in dataChart)
            {
                chart1.Series[0].Points.AddXY(item.TenDichVu, item.TongTien);
            }

            // Load DataGridView doanh thu dịch vụ
            dgvDoanhThuDichVu.DataSource = dataChart;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = null;
            dgvDoanhThuDichVu.DataSource = null;
            txtSoHD.Clear();
            txtTongTien.Clear();
            txtTBHoaDon.Clear();
            chart1.Series[0].Points.Clear();
        }
    }
}
