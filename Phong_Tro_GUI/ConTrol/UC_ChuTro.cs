using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class UC_ChuTro : UserControl
    {
        private bool sidebarExpanded = true;
        private Timer sidebarTimer;
        private Panel activeBorderPanel;

        public UC_ChuTro()
        {
            InitializeComponent();
            InitializeAnimations();
            HighlightButton(btnTrangChu);
            LoadTrangChu();
        }

        private void InitializeAnimations()
        {
            sidebarTimer = new Timer { Interval = 10 };
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            int step = 15;

            if (sidebarExpanded)
            {
                pnlSidebar.Width -= step;
                if (pnlSidebar.Width <= 60)
                {
                    sidebarExpanded = false;
                    sidebarTimer.Stop();
                    foreach (Button btn in pnlSidebar.Controls)
                        if (btn != btnMenu) btn.Text = "";
                }
            }
            else
            {
                pnlSidebar.Width += step;
                if (pnlSidebar.Width >= 200)
                {
                    sidebarExpanded = true;
                    sidebarTimer.Stop();
                    SetButtonText();
                }
            }
        }

        private void SetButtonText()
        {
            btnTrangChu.Text = "🏠 Trang chủ";
            btnPhong.Text = "🏢 Quản lý phòng";
            btnHoaDon.Text = "💰 Hóa đơn";
            btnThongBao.Text = "💬 Thông báo";
            btnThongKe.Text = "📊 Thống kê";
            btnDichVu.Text = "🧰 Dịch vụ";
            btnHopDong.Text = "📜 Hợp đồng";
            btnDangXuat.Text = "🚪 Đăng xuất";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void HighlightButton(Button selectedButton)
        {
            if (activeBorderPanel != null)
                pnlSidebar.Controls.Remove(activeBorderPanel);

            activeBorderPanel = new Panel
            {
                Size = new Size(6, selectedButton.Height),
                BackColor = Color.White,
                Location = new Point(0, selectedButton.Top)
            };
            pnlSidebar.Controls.Add(activeBorderPanel);
            activeBorderPanel.BringToFront();

            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnMenu)
                {
                    btn.BackColor = Color.FromArgb(35, 60, 120);
                    btn.ForeColor = Color.White;
                }
            }

            selectedButton.BackColor = Color.FromArgb(60, 90, 160);
        }

        private void LoadControl(Control ctrl)
        {
            pnlContent.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ctrl);
        }

        // ------------------- TRANG CHỦ -------------------
        private void LoadTrangChu()
        {
            Panel dashboard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };

            string[] titles = { "🏠 Tổng số phòng", "🧍‍♂️ Khách thuê hiện tại", "💰 Doanh thu tháng", "📅 Phòng đang thuê" };
            string[] values = { "24", "18", "35.500.000 VNĐ", "15" };
            Color[] colors =
            {
                Color.FromArgb(72, 136, 247),
                Color.FromArgb(255, 186, 0),
                Color.FromArgb(45, 203, 115),
                Color.FromArgb(255, 99, 132)
            };

            for (int i = 0; i < titles.Length; i++)
            {
                Panel card = new Panel
                {
                    Size = new Size(200, 120),
                    BackColor = colors[i],
                    BorderStyle = BorderStyle.None,
                    Location = new Point(70 + i * 230, 120),
                    Cursor = Cursors.Hand
                };

                Label lblTitle = new Label
                {
                    Text = titles[i],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblValue = new Label
                {
                    Text = values[i],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                card.MouseEnter += (s, e2) => { card.BackColor = ControlPaint.Light(colors[i]); };
                card.MouseLeave += (s, e2) => { card.BackColor = colors[i]; };

                card.Controls.Add(lblValue);
                card.Controls.Add(lblTitle);
                dashboard.Controls.Add(card);
            }

            Label welcome = new Label
            {
                Text = "🎉 Chào mừng đến hệ thống quản lý phòng trọ!",
                Dock = DockStyle.Top,
                Height = 80,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };

            dashboard.Controls.Add(welcome);

            LoadControl(dashboard);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTrangChu);
            LoadTrangChu();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPhong);
        //    LoadControl(new UC_QLPhong("ChuTro"));
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HighlightButton(btnHoaDon);
            LoadControl(new Label()
            {
                Text = "💰 Quản lý hóa đơn đang phát triển...",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            HighlightButton(btnThongBao);
            LoadControl(new Label()
            {
                Text = "💬 Khu vực thông báo đang phát triển...",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HighlightButton(btnThongKe);
            LoadControl(new UC_ThongKeDoanhThu());
           
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            HighlightButton(btnDichVu);
            LoadControl(new UC_TienIch()
            {
                
            });
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            HighlightButton(btnHopDong);
            LoadControl(new Label()
            {
                Text = "📜 Quản lý hợp đồng đang phát triển...",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter
            });
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
