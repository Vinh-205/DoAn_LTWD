using System;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class DangNhap : Form
    {
        private readonly TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            cboRole.Items.AddRange(new string[] { "ChuTro", "KhachThue" });
            cboRole.SelectedIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text.Trim();
                string role = cboRole.SelectedItem.ToString();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TaiKhoan tk = taiKhoanBUS.KiemTraDangNhap(user, pass, role);

                if (tk != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    // 👉 Mở form chính có chứa UserControl tùy vai trò
                    Form mainForm = new Form
                    {
                        Text = role == "ChuTro" ? "Chủ Trọ - Quản lý phòng trọ" : "Người Thuê - Giao diện người dùng",
                        WindowState = FormWindowState.Maximized,
                        BackColor = System.Drawing.Color.White
                    };

                    // 👉 Nạp UserControl phù hợp
                    if (role == "ChuTro")
                    {
                        var ucChuTro = new UC_ChuTro();
                        ucChuTro.Dock = DockStyle.Fill;
                        mainForm.Controls.Add(ucChuTro);
                    }
                    else if (role == "KhachThue")
                    {
                        
                         var ucNguoiThue = new UC_NguoiThue();
                        ucNguoiThue.Dock = DockStyle.Fill;
                        mainForm.Controls.Add(ucNguoiThue);
                    }

                    mainForm.FormClosed += (s, args) => Application.Exit();
                    mainForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
