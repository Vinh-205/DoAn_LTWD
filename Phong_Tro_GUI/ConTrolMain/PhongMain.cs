using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS; // Dùng ThongKeBUS

namespace Phong_Tro_GUI.ConTrol
{
    public partial class PhongMain : UserControl
    {
        private readonly ThongKeBUS thongKeBUS;

        public PhongMain()
        {
            InitializeComponent();
            thongKeBUS = new ThongKeBUS();
            LoadSoDoPhong();
            LoadDoanhThu();
        }

        private void LoadSoDoPhong()
        {
            pnlSoDoPhong.Controls.Clear();
            var listPhong = thongKeBUS.LayDanhSachPhong();
            int x = 20, y = 20, count = 0;

            foreach (var phong in listPhong)
            {
                Button btnPhong = new Button
                {
                    Text = phong.TenPhong,
                    Size = new Size(100, 60),
                    Location = new Point(x, y),
                    BackColor = Color.LightSeaGreen,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = phong.MaPhong
                };
                btnPhong.Click += BtnPhong_Click;
                pnlSoDoPhong.Controls.Add(btnPhong);

                count++;
                x += 120;
                if (count % 5 == 0)
                {
                    x = 20;
                    y += 80;
                }
            }
        }

        private void BtnPhong_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string maPhong = btn?.Tag?.ToString();
            MessageBox.Show($"Phòng {btn.Text} - Mã {maPhong}");
        }

        private void LoadDoanhThu()
        {
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;

            var doanhThu = thongKeBUS.DoanhThuTheoPhong(thang, nam);
            dgvDoanhThu.DataSource = doanhThu.Select(d => new
            {
                Mã_Phòng = d.MaPhong,
                Doanh_Thu = d.TongTien
            }).ToList();

            lblTongDoanhThu.Text = "Tổng doanh thu tháng " + thang + ": " +
                doanhThu.Sum(x => x.TongTien).ToString("N0") + " VNĐ";
        }
    }
}
