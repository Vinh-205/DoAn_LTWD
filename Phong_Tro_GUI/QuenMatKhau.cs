using System;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class QuenMatKhau : Form
    {
        private readonly TaiKhoanBUS _taiKhoanBUS = new TaiKhoanBUS();

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMK.Checked;
        }

        private void btnLayLai_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TaiKhoan tk = _taiKhoanBUS.LayLaiMatKhau(tenDangNhap, email);

                if (tk != null)
                {
                    txtMatKhau.Text = tk.MatKhau; // ⚠️ hiển thị tạm, sau này nên gửi email thay
                    MessageBox.Show("Đã tìm thấy tài khoản! Mật khẩu được hiển thị bên dưới.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản với thông tin đã nhập!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
