using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class UC_ChuTroDashboard : UserControl
    {
        private bool sidebarExpand = true;
        private Timer sidebarTimer = new Timer();
        private Button currentButton = null;
        private Panel indicatorPanel;

        public UC_ChuTroDashboard()
        {
            InitializeComponent();
            SetupSidebar();
        }

        private void SetupSidebar()
        {
            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += SidebarTimer_Tick;

            // Tạo thanh highlight bên trái menu
            indicatorPanel = new Panel
            {
                Size = new Size(5, 40),
                BackColor = Color.DeepSkyBlue,
                Visible = false
            };
            pnlSidebar.Controls.Add(indicatorPanel);

            // Đăng ký hiệu ứng cho từng nút
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnMenu)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(35, 60, 120);
                    btn.ForeColor = Color.White;
                    btn.MouseEnter += Btn_MouseEnter;
                    btn.MouseLeave += Btn_MouseLeave;
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(55, 85, 160);
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            if (sender != currentButton)
                (sender as Button).BackColor = Color.FromArgb(35, 60, 120);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(35, 60, 120);
                currentButton.FlatAppearance.BorderSize = 0;
            }

            currentButton = sender as Button;
            currentButton.BackColor = Color.FromArgb(70, 110, 190);
            currentButton.FlatAppearance.BorderSize = 1;
            currentButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;

            // Thanh chỉ báo bên trái di chuyển theo nút
            indicatorPanel.Visible = true;
            indicatorPanel.Top = currentButton.Top;
            indicatorPanel.BringToFront();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 60)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();

                    foreach (Control ctrl in pnlSidebar.Controls)
                    {
                        if (ctrl is Button btn && btn != btnMenu)
                        {
                            btn.Text = ""; // ẩn chữ
                        }
                    }
                }
            }
            else
            {
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width >= 200)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();

                    // Hiện lại chữ
                    btnPhong.Text = "🏢 Quản lý phòng";
                    btnHoaDon.Text = "💰 Hóa đơn";
                    btnThongBao.Text = "💬 Thông báo";
                    btnThongKe.Text = "📊 Thống kê";
                    btnDangXuat.Text = "🚪 Đăng xuất";
                }
            }
        }
    }
}
