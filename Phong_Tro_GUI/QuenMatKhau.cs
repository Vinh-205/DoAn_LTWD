using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class QuenMatKhau : Form
    {
        TaiKhoanDB taiKhoanDB = new TaiKhoanDB();

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '●'; // Ẩn mật khẩu mặc định
        }

        private void btnLayLai_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập, email và mật khẩu mới!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra tài khoản trong DB
                TaiKhoan tk = taiKhoanDB.GetAll()
                    .FirstOrDefault(t => t.TenDangNhap == username && t.Email == email);

                if (tk == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc email không đúng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật mật khẩu mới
                taiKhoanDB.ChangePassword(tk.MaTK, newPass);

                // Gửi email thông báo
                bool guiThanhCong = GuiEmail(email, username, newPass);

                if (guiThanhCong)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!\nVui lòng kiểm tra email của bạn.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtTenDangNhap.Clear();
                    txtEmail.Clear();
                    txtMatKhau.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công, nhưng không gửi được email!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🩵 Hàm gửi email mật khẩu mới
        private bool GuiEmail(string emailNguoiNhan, string username, string newPass)
        {
            try
            {
                // Gmail gửi (Tài khoản này Vĩnh có thể thay bằng của mình)
                string emailGui = "phongtro.system@gmail.com";
                string matKhauEmail = "matkhaugmail_app_password";
                // 👉 Nếu bật xác minh 2 bước, dùng App Password thay cho mật khẩu thật

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailGui, "Hệ thống Phòng Trọ");
                mail.To.Add(emailNguoiNhan);
                mail.Subject = "📢 Khôi phục mật khẩu - Ứng dụng Quản lý Phòng trọ";
                mail.Body = $"Xin chào {username},\n\n" +
                            $"Mật khẩu mới của bạn là: {newPass}\n\n" +
                            "Vui lòng đăng nhập lại hệ thống và đổi mật khẩu để đảm bảo an toàn.\n\n" +
                            "Trân trọng,\nHệ thống Quản lý Phòng Trọ.";
                mail.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(emailGui, matKhauEmail);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = chkHienMK.Checked ? '\0' : '●';
        }
    }
}
