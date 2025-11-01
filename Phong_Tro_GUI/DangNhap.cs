using System;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoanDB taiKhoanDB = new TaiKhoanDB();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            // Ẩn mật khẩu mặc định
            txtPassword.UseSystemPasswordChar = true;

            // Load danh sách vai trò
            cboRole.Items.Add("Chủ trọ");
            cboRole.Items.Add("Người thuê");
            cboRole.SelectedIndex = 0;
        }

        // ✅ Hiện / Ẩn mật khẩu
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        // ✅ Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cboRole.SelectedItem.ToString();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TaiKhoan tk = taiKhoanDB.Login(username, password);

                if (tk != null)
                {
                    // Kiểm tra vai trò hợp lệ
                    if ((role == "Chủ trọ" && tk.LoaiTK == "Admin") ||
                        (role == "Người thuê" && tk.LoaiTK == "User"))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide(); // Ẩn form đăng nhập

                        // ✅ Mở form tương ứng
                        if (role == "Chủ trọ")
                        {
                            ChuTro frm = new ChuTro();
                            frm.ShowDialog();
                        }
                        else
                        {
                            NguoiThue frm = new NguoiThue();
                            frm.ShowDialog();
                        }

                        // Khi form con đóng → hiện lại form đăng nhập
                        this.Show();

                        // Reset dữ liệu
                        txtUsername.Clear();
                        txtPassword.Clear();
                        cboRole.SelectedIndex = 0;
                        chkShowPass.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Sai loại tài khoản. Vui lòng chọn đúng vai trò!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Thoát chương trình
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        // ✅ Label "Quên mật khẩu"
        private void lblQuenMK_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form đăng nhập

            QuenMatKhau frm = new QuenMatKhau();
            frm.ShowDialog();

            // Khi form quên mật khẩu đóng → hiện lại form đăng nhập
            this.Show();
        }
    }
}
