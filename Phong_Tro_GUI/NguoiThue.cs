using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class NguoiThue : Form
    {
        private Panel activeIndicator;

        public NguoiThue()
        {
            InitializeComponent();
            InitializeMenuEffects();
            HighlightButton(btnThongTin);
            LoadContent("👤 Thông tin cá nhân của bạn sẽ hiển thị tại đây.");
        }

        private void InitializeMenuEffects()
        {
            activeIndicator = new Panel
            {
                BackColor = Color.MidnightBlue,
                Size = new Size(6, 38)
            };
            pnlMenu.Controls.Add(activeIndicator);
            activeIndicator.BringToFront();
        }

        private void HighlightButton(Button selectedButton)
        {
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is Button btn && btn != btnDangXuat)
                {
                    btn.BackColor = Color.SteelBlue;
                    btn.ForeColor = Color.White;
                }
            }

            selectedButton.BackColor = Color.MidnightBlue;
            selectedButton.ForeColor = Color.WhiteSmoke;
            activeIndicator.Location = new Point(0, selectedButton.Top);
        }

        private void LoadControl(Control ctrl)
        {
            pnlContent.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(ctrl);
        }

        private void LoadContent(string text)
        {
            pnlContent.Controls.Clear();
            Label lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlContent.Controls.Add(lbl);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            HighlightButton(btnThongTin);
            LoadContent("👤 Thông tin cá nhân của bạn sẽ hiển thị tại đây.");
        }

        private void btnPhongDangThue_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPhongDangThue);
            //LoadControl(new UC_QLPhong("KhachThue"));
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HighlightButton(btnHoaDon);
            LoadContent("🧾 Danh sách hóa đơn thanh toán của bạn.");
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            HighlightButton(btnThongBao);
            LoadContent("🔔 Các thông báo mới nhất từ chủ trọ.");
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                "Xác nhận",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
