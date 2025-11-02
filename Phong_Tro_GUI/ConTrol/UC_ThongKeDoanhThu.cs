using System;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phong_Tro_GUI
{
    public partial class UC_ThongKeDoanhThu : UserControl
    {
        private readonly ThongKeBUS thongKeBUS = new ThongKeBUS();

        public UC_ThongKeDoanhThu()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            // Tháng
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i);

            // Năm
            cboNam.Items.Clear();
            for (int i = 2020; i <= DateTime.Now.Year; i++)
                cboNam.Items.Add(i);

            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = cboNam.Items.Count - 1;

            // Phòng (danh sách từ BUS hoặc DB)
            var phongList = thongKeBUS.LayDanhSachPhong();
            cboPhong.DataSource = phongList;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedItem == null || cboNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm!");
                return;
            }

            int thang = Convert.ToInt32(cboThang.SelectedItem);
            int nam = Convert.ToInt32(cboNam.SelectedItem);
            string maPhong = cboPhong.SelectedValue?.ToString();

            // === Hóa đơn theo phòng ===
            var hoaDonList = thongKeBUS.DoanhThuTheoPhong(thang, nam);
            if (!string.IsNullOrEmpty(maPhong))
                hoaDonList = hoaDonList.Where(x => x.MaPhong == maPhong).ToList();

            dgvHoaDon.DataSource = hoaDonList;

            // === Doanh thu dịch vụ ===
            var dvList = thongKeBUS.DoanhThuDichVuTheoThang(thang, nam);
            dgvDoanhThuDichVu.DataSource = dvList;

            // === Tổng hợp ===
            txtSoHD.Text = hoaDonList.Count.ToString();
            txtTongTien.Text = hoaDonList.Sum(x => x.TongTien).ToString("N0");
            txtTBHoaDon.Text = hoaDonList.Count > 0
                ? (hoaDonList.Sum(x => x.TongTien) / hoaDonList.Count).ToString("N0")
                : "0";

            // === Vẽ chart Pie ===
            chart1.Series["Series1"].Points.Clear();
            foreach (var item in hoaDonList)
            {
                chart1.Series["Series1"].Points.AddXY(item.MaPhong, item.TongTien);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart1.Legends[0].Docking = Docking.Bottom;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = null;
            dgvDoanhThuDichVu.DataSource = null;
            txtSoHD.Clear();
            txtTongTien.Clear();
            txtTBHoaDon.Clear();
            chart1.Series["Series1"].Points.Clear();
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = cboNam.Items.Count - 1;
            cboPhong.SelectedIndex = -1;
        }
    }
}
