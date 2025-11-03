using System;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.PhongTro;

namespace Phong_Tro_GUI
{
    public partial class QuenMatKhau : Form
    {
        private readonly TaiKhoanBUS _taiKhoanBUS = new TaiKhoanBUS();
        private bool _daTimThay = false; // Đánh dấu đã tìm thấy tài khoản hay chưa

        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.ReadOnly = true;               // Không cho nhập
            txtMatKhau.Enabled = false;               // Làm mờ ô mật khẩu
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

            // === Lần nhấn thứ 1: kiểm tra và hiển thị mật khẩu ===
            if (!_daTimThay)
            {
                try
                {
                    TaiKhoan tk = _taiKhoanBUS.LayLaiMatKhau(tenDangNhap, email);

                    if (tk != null)
                    {
                        txtMatKhau.Enabled = true;
                        txtMatKhau.Text = tk.MatKhau;
                        _daTimThay = true;

                        MessageBox.Show("Đã tìm thấy tài khoản! Mật khẩu được hiển thị bên dưới.\n" +
                                        "Nhấn 'Lấy lại' lần nữa để quay lại đăng nhập.",
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
            else
            {
                // === Lần nhấn thứ 2: hỏi có quay lại đăng nhập không ===
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn quay lại màn hình đăng nhập không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DangNhap frmDangNhap = new DangNhap();
                    frmDangNhap.Show();
                    this.Hide();
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
