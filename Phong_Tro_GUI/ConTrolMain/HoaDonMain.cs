using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Phong_Tro_GUI.ConTrolMain
{
    // Kế thừa từ UserControl thay vì Form
    public partial class HoaDonMain : UserControl
    {
        // Khai báo các BUS và DAL như cũ
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private readonly ThongBaoBUS thongBaoBUS = new ThongBaoBUS();
        private readonly Connect db = new Connect();

        // MOCK TẠM CÁC CLASS CẦN THIẾT NẾU CHƯA CÓ TRONG THỰC TẾ
        // Bạn có thể xóa phần này nếu các class HoaDon, ThongBao đã được định nghĩa
        private class HoaDon { public string MaHD { get; set; } public decimal TienDien { get; set; } public decimal TienNuoc { get; set; } public decimal GiaPhong { get; set; } public DateTime NgayLap { get; set; } public string MaPhong { get; set; } }
        private class ThongBao { public string MaPhong { get; set; } public string NoiDung { get; set; } public DateTime NgayTao { get; set; } }
        private class ThongBaoBUS { public void Them(ThongBao h) { } }
        private class Connect { public List<Phong> Phongs = new List<Phong> { new Phong { MaPhong = "P001", TenPhong = "Phòng 101" }, new Phong { MaPhong = "P002", TenPhong = "Phòng 102" } }; public List<Phong> PhongsToList() => Phongs; }
        private class Phong { public string MaPhong { get; set; } public string TenPhong { get; set; } }
        // End Mock

        // ==================== MOCK TẠM CHO CÁC HÀM BUS (Copy từ Form cũ) ====================
        private class HoaDonBUS
        {
            public List<dynamic> LayTatCa()
            {
                return new List<dynamic>
        {
            new { MaHD = "HD001", GiaPhong = 2500000m, TienDien = 300000m, TienNuoc = 100000m, NgayLap = DateTime.Now.AddDays(-10), TongTien = 2900000m },
            new { MaHD = "HD002", GiaPhong = 3000000m, TienDien = 400000m, TienNuoc = 150000m, NgayLap = DateTime.Now.AddDays(-5), TongTien = 3550000m }
        };
            }

            public List<dynamic> TimKiem(string k)
            {
                var all = LayTatCa();
                if (k.ToLower().Contains("hd001"))
                    return all.Where(x => x.MaHD == "HD001").ToList();
                return all;
            }

            public void Them(HoaDon h) { }
            public void Sua(HoaDon h) { }
            public void Xoa(string id) { }
            public string LayMaPhongTheoHoaDon(string maHD) => maHD == "HD001" ? "P001" : "P002";
        }
        // ==================== KẾT THÚC MOCK ====================

        public HoaDonMain()
        {
            InitializeComponent();
            // Thiết lập sự kiện Load cho UserControl sau khi component được khởi tạo
            this.Load += new EventHandler(HoaDonMain_Load);
            // Gán sự kiện Click cho nút Tìm kiếm
            this.btnTimKiem.Click += new EventHandler(this.btnTimKiem_Click);
        }

        // ==================== LOAD USERCONTROL (THAY VÌ FORM) ====================
        private void HoaDonMain_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            LoadPhong();
            ClearFields();

            // Khởi tạo các sự kiện khác được định nghĩa trong designer nhưng thiếu code
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            this.btnGuiThongBao.Click += new System.EventHandler(this.btnGuiThongBao_Click);
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick); // Đã thay bằng CellClick để bao quát hơn CellContentClick
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
        }

        // ==================== LOAD DỮ LIỆU ====================
        private void LoadHoaDon()
        {
            dgvHoaDon.DataSource = hoaDonBUS.LayTatCa();
        }

        private void LoadPhong()
        {
            // Sử dụng ToList() trên Phongs của Connect
            cbPhong.DataSource = db.Phongs.ToList();
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "MaPhong";

            cbPhongThongBao.DataSource = db.Phongs.ToList();
            cbPhongThongBao.DisplayMember = "TenPhong";
            cbPhongThongBao.ValueMember = "MaPhong";
        }

        // ==================== CÁC NÚT CHỨC NĂNG ====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu cần thiết
                if (string.IsNullOrWhiteSpace(txtMaHD.Text) || string.IsNullOrWhiteSpace(txtTienDien.Text) || string.IsNullOrWhiteSpace(txtTienNuoc.Text) || string.IsNullOrWhiteSpace(txtTienPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Mã HĐ, Tiền phòng, Tiền điện, Tiền nước.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HoaDon hd = new HoaDon
                {
                    MaHD = txtMaHD.Text.Trim(),
                    TienDien = Convert.ToDecimal(txtTienDien.Text),
                    TienNuoc = Convert.ToDecimal(txtTienNuoc.Text),
                    GiaPhong = Convert.ToDecimal(txtTienPhong.Text),
                    NgayLap = dtpNgayLap.Value
                    // MaPhong chưa được lấy từ cbPhong, cần thêm logic này nếu cần
                };

                hoaDonBUS.Them(hd);
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon();
                ClearFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Tiền phòng, Tiền điện, Tiền nước phải là định dạng số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra các trường nhập liệu cần thiết
                if (string.IsNullOrWhiteSpace(txtTienDien.Text) || string.IsNullOrWhiteSpace(txtTienNuoc.Text) || string.IsNullOrWhiteSpace(txtTienPhong.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tiền phòng, Tiền điện, Tiền nước.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HoaDon hd = new HoaDon
                {
                    MaHD = txtMaHD.Text.Trim(),
                    TienDien = Convert.ToDecimal(txtTienDien.Text),
                    TienNuoc = Convert.ToDecimal(txtTienNuoc.Text),
                    GiaPhong = Convert.ToDecimal(txtTienPhong.Text),
                    NgayLap = dtpNgayLap.Value
                };

                hoaDonBUS.Sua(hd);
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon();
                ClearFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Tiền phòng, Tiền điện, Tiền nước phải là định dạng số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn có mã: " + txtMaHD.Text.Trim() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    hoaDonBUS.Xoa(txtMaHD.Text.Trim());
                    MessageBox.Show("Đã xóa hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDon();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadHoaDon();
            // Có thể thêm logic load dữ liệu cho dgvThongBao nếu cần
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvHoaDon.DataSource = hoaDonBUS.TimKiem(keyword);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                LoadHoaDon();
        }

        // ==================== THÔNG BÁO ====================
        private void btnGuiThongBao_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhong = cbPhongThongBao.SelectedValue?.ToString();
                string noiDung = txtNoiDungThongBao.Text.Trim();

                if (string.IsNullOrEmpty(noiDung))
                {
                    MessageBox.Show("Vui lòng nhập nội dung thông báo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var thongBao = new ThongBao
                {
                    MaPhong = maPhong,
                    NoiDung = noiDung,
                    NgayTao = DateTime.Now
                };

                thongBaoBUS.Them(thongBao);
                MessageBox.Show($"Gửi thông báo thành công đến phòng {cbPhongThongBao.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoiDungThongBao.Clear();
                // Có thể thêm logic load lại dgvThongBao ở đây
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi thông báo: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== GRIDVIEW EVENT ====================
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Thay vì CellContentClick nên dùng CellClick để tránh nhầm lẫn, nhưng tôi giữ nguyên tên hàm của bạn
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                // Lấy MaHD
                string maHD = row.Cells["MaHD"].Value?.ToString();
                txtMaHD.Text = maHD;

                // Lấy MaPhong từ BUS và thiết lập ComboBox
                if (!string.IsNullOrEmpty(maHD))
                {
                    cbPhong.SelectedValue = hoaDonBUS.LayMaPhongTheoHoaDon(maHD);
                }

                // Hiển thị các thông tin khác
                txtTienPhong.Text = row.Cells["GiaPhong"].Value?.ToString(); // Chú ý: Tên cột là GiaPhong, không phải TienPhong
                txtTienDien.Text = row.Cells["TienDien"].Value?.ToString();
                txtTienNuoc.Text = row.Cells["TienNuoc"].Value?.ToString();

                // Lấy Ngày Lập
                if (row.Cells["NgayLap"].Value != null)
                {
                    dtpNgayLap.Value = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                }

                // Tính Tổng Tiền (tự động)
                if (decimal.TryParse(txtTienPhong.Text, out decimal tienPhong) &&
                    decimal.TryParse(txtTienDien.Text, out decimal tienDien) &&
                    decimal.TryParse(txtTienNuoc.Text, out decimal tienNuoc))
                {
                    txtTongTien.Text = (tienPhong + tienDien + tienNuoc).ToString();
                }
                else
                {
                    txtTongTien.Clear(); // Xóa nếu không hợp lệ
                }

                // Giả định: set trạng thái thanh toán (cần thêm cột và logic trong BUS)
                //cbTrangThai.SelectedIndex = 0; 
            }
        }

        // ==================== HÀM PHỤ ====================
        private void ClearFields()
        {
            txtMaHD.Clear();
            txtTenKH.Clear(); // Thêm TenKH
            txtTienPhong.Clear();
            txtTienDien.Clear();
            txtTienNuoc.Clear();
            txtTongTien.Clear(); // Thêm TongTien
            txtNoiDungThongBao.Clear();
            txtTimKiem.Clear();
            dtpNgayLap.Value = DateTime.Now; // Đặt lại ngày lập
            // Đặt lại ComboBox về trạng thái đầu tiên nếu cần
            if (cbPhong.Items.Count > 0) cbPhong.SelectedIndex = 0;
            if (cbPhongThongBao.Items.Count > 0) cbPhongThongBao.SelectedIndex = 0;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
        }
    }
}