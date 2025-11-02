using System;
using System.Drawing;
using System.Windows.Forms;
using Phong_Tro_GUI; // đảm bảo UC_ThongKeDoanhThu đã được import

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
            // Khởi tạo border panel nếu muốn highlight button active
            activeBorderPanel = new Panel();
            activeBorderPanel.Size = new Size(5, 50); // chiều rộng viền
            activeBorderPanel.BackColor = Color.MidnightBlue;
            pnlSidebar.Controls.Add(activeBorderPanel); // giả sử bạn có pnlSidebar
            activeBorderPanel.Visible = false;
        }

        private void LoadUC(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        // Ví dụ: khi bấm "Thống kê"
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            LoadUC(new UC_ThongKeDoanhThu());
        }


        // Hàm di chuyển active border
        private void MoveActiveBorder(Button btn)
        {
            if (btn == null) return;
            activeBorderPanel.Visible = true;
            activeBorderPanel.Height = btn.Height;
            activeBorderPanel.Top = btn.Top;
            activeBorderPanel.BringToFront();
        }


        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
            // load UC_TrangChu nếu có
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
            // load UC_Phong nếu có
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
            // load UC_HoaDon nếu có
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            pnlContent.Controls.Clear();
            // load UC_ThongBao nếu có
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MoveActiveBorder(sender as Button);
            LoadUC(new UC_DichVu());
        }

        //private void btnHopDong_Click(object sender, EventArgs e)
        //{
        //    MoveActiveBorder(sender as Button);
        //    LoadUC(new UC_HopDong());
        //}

        //private void btnHoaDon_Click(object sender, EventArgs e)
        //{
        //    MoveActiveBorder(sender as Button);
        //    LoadUC(new UC_HoaDon());
        //}


        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            // Nếu muốn custom vẽ pnlContent
        }

        private void pnlContent_Click(object sender, EventArgs e)
        {
            // xử lý nếu click vào pnlContent
        }
    }
}
