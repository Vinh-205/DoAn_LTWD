using System;
using System.Drawing;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_GUI.ConTrolUser;

namespace Phong_Tro_GUI
{
    public partial class ChuTroMain : UserControl
    {
        private bool sidebarExpanded = true;
        private Timer sidebarTimer;
        private Panel activeBorderPanel;

        public ChuTroMain()
        {
            InitializeComponent();
            SetupSidebarBorder();
            SetupSidebarTimer();
        }

        private void SetupSidebarBorder()
        {
            // Border nhỏ bên trái để đánh dấu nút đang chọn
            activeBorderPanel = new Panel
            {
                Size = new Size(5, 50),
                BackColor = Color.MidnightBlue,
                Visible = false
            };
            pnlSidebar.Controls.Add(activeBorderPanel);
        }

        private void SetupSidebarTimer()
        {
            sidebarTimer = new Timer();
            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                pnlSidebar.Width -= 10;
                if (pnlSidebar.Width <= 60)
                {
                    sidebarExpanded = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                pnlSidebar.Width += 10;
                if (pnlSidebar.Width >= 200)
                {
                    sidebarExpanded = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        // Load user control con vào vùng content
        private void LoadUC(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        private void MoveActiveBorder(Button btn)
        {
            if (btn == null) return;
            activeBorderPanel.Visible = true;
            activeBorderPanel.Height = btn.Height;
            activeBorderPanel.Top = btn.Top;
            activeBorderPanel.BringToFront();
        }

        // === Nút Menu ===
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            LoadUC(new PhongMain());
        }


        private void btnPhong_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
            // Load UC_Phong nếu có
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            //LoadUC(new HoaDonMain());
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            LoadUC(new ThongKeMain());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            LoadUC(new DichVuMain());
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Tìm form cha của UserControl hiện tại
                Form parentForm = this.FindForm();

                // Ẩn form hiện tại (hoặc Close() nếu bạn muốn đóng hẳn)
                parentForm.Hide();

                // Mở lại form đăng nhập (đổi tên theo form của bạn)
                DangNhap frmLogin = new DangNhap();
                frmLogin.Show();
            }
        }

    }
}
