using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phong_Tro_GUI.ConTrolUser
{
    public partial class YKienUser : UserControl
    {
        public YKienUser()
        {
            InitializeComponent();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNguoiGui.Text) ||
                string.IsNullOrWhiteSpace(txtSoPhong.Text) ||
                string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi gửi!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiệu ứng nhấp nháy nhẹ khi gửi
            btnGui.BackColor = Color.LightGreen;
            Timer timer = new Timer { Interval = 300 };
            timer.Tick += (s, ev) =>
            {
                btnGui.BackColor = SystemColors.Control;
                timer.Stop();
            };
            timer.Start();

            MessageBox.Show("Cảm ơn bạn đã gửi ý kiến! Chủ trọ sẽ phản hồi sớm nhất.",
                "Gửi thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset các ô nhập
            txtTenNguoiGui.Clear();
            txtSoPhong.Clear();
            txtNoiDung.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa nội dung đã nhập?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtTenNguoiGui.Clear();
                txtSoPhong.Clear();
                txtNoiDung.Clear();
            }
        }
    }
}
