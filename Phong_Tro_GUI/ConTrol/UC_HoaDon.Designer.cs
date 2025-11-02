namespace Phong_Tro_GUI.ConTrol
{
    partial class UC_HoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Timer sidebarTimer;

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.GroupBox gbThongBao;
        private System.Windows.Forms.GroupBox gbTrangThai;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridView dgvThongBao;

        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.TextBox txtTongTien;

        private System.Windows.Forms.ComboBox cbPhongThongBao;
        private System.Windows.Forms.TextBox txtNoiDungThongBao;
        private System.Windows.Forms.Button btnGuiThongBao;

        private System.Windows.Forms.ComboBox cbTrangThai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // === Timer Sidebar ===
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);

            // === Panel Menu ===
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(215, 230, 225);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 200;

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();

            System.Drawing.Font fontBtn = new System.Drawing.Font("Segoe UI", 9F);

            this.btnThem.Text = "➕ Thêm HĐ";
            this.btnThem.BackColor = System.Drawing.Color.Teal;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = fontBtn;
            this.btnThem.Location = new System.Drawing.Point(35, 40);
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "✏️ Sửa HĐ";
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = fontBtn;
            this.btnSua.Location = new System.Drawing.Point(35, 90);
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Text = "🗑️ Xóa HĐ";
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = fontBtn;
            this.btnXoa.Location = new System.Drawing.Point(35, 140);
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.BackColor = System.Drawing.Color.Gray;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = fontBtn;
            this.btnLamMoi.Location = new System.Drawing.Point(35, 190);
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.txtTimKiem.Location = new System.Drawing.Point(20, 260);
            this.txtTimKiem.Size = new System.Drawing.Size(160, 27);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Text = "Nhập mã hoặc tên KH...";
            this.txtTimKiem.GotFocus += (s, e) =>
            {
                if (txtTimKiem.Text == "Nhập mã hoặc tên KH...")
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = System.Drawing.Color.Black;
                }
            };
            this.txtTimKiem.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = "Nhập mã hoặc tên KH...";
                    txtTimKiem.ForeColor = System.Drawing.Color.Gray;
                }
            };

            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.btnTimKiem.Font = fontBtn;
            this.btnTimKiem.Location = new System.Drawing.Point(35, 300);
            this.btnTimKiem.Size = new System.Drawing.Size(130, 40);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.panelMenu.Controls.AddRange(new System.Windows.Forms.Control[] {
                btnThem, btnSua, btnXoa, btnLamMoi, txtTimKiem, btnTimKiem
            });

            // === Header ===
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(178, 224, 210);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;

            this.btnMenu = new System.Windows.Forms.Button();
            this.btnMenu.Text = "☰";
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(40, 55, 71);
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.Width = 60;
            this.btnMenu.Height = 60;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);

            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitle.Text = "QUẢN LÝ HÓA ĐƠN";
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(40, 55, 71);
            this.labelTitle.Location = new System.Drawing.Point(80, 15);
            this.labelTitle.AutoSize = true;

            this.panelHeader.Controls.Add(this.btnMenu);
            this.panelHeader.Controls.Add(this.labelTitle);

            // === GroupBox: Thông tin hóa đơn ===
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.gbThongTin.Text = "Thông tin hóa đơn";
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongTin.Location = new System.Drawing.Point(220, 80);
            this.gbThongTin.Size = new System.Drawing.Size(900, 180);

            this.txtMaHD = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(130, 35), Width = 180 };
            this.txtTenKH = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(450, 35), Width = 180 };
            this.cbPhong = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(130, 75), Width = 180 };
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker { Location = new System.Drawing.Point(450, 75), Width = 180 };
            this.txtTienPhong = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(130, 115), Width = 180 };
            this.txtTienDien = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(450, 115), Width = 180 };
            this.txtTienNuoc = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(740, 35), Width = 130 };
            this.txtTongTien = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(740, 75), Width = 130, ReadOnly = true };

            this.gbThongTin.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                new System.Windows.Forms.Label(){Text="Mã Hóa Đơn:",Location=new System.Drawing.Point(20,40),AutoSize=true},
                txtMaHD,
                new System.Windows.Forms.Label(){Text="Khách hàng:",Location=new System.Drawing.Point(340,40),AutoSize=true},
                txtTenKH,
                new System.Windows.Forms.Label(){Text="Phòng:",Location=new System.Drawing.Point(20,80),AutoSize=true},
                cbPhong,
                new System.Windows.Forms.Label(){Text="Ngày lập:",Location=new System.Drawing.Point(340,80),AutoSize=true},
                dtpNgayLap,
                new System.Windows.Forms.Label(){Text="Tiền phòng:",Location=new System.Drawing.Point(20,120),AutoSize=true},
                txtTienPhong,
                new System.Windows.Forms.Label(){Text="Tiền điện:",Location=new System.Drawing.Point(340,120),AutoSize=true},
                txtTienDien,
                new System.Windows.Forms.Label(){Text="Tiền nước:",Location=new System.Drawing.Point(650,40),AutoSize=true},
                txtTienNuoc,
                new System.Windows.Forms.Label(){Text="Tổng tiền:",Location=new System.Drawing.Point(650,80),AutoSize=true},
                txtTongTien
            });

            // === GroupBox: Thông báo ===
            this.gbThongBao = new System.Windows.Forms.GroupBox();
            this.gbThongBao.Text = "Thông báo đến người thuê";
            this.gbThongBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongBao.Location = new System.Drawing.Point(220, 270);
            this.gbThongBao.Size = new System.Drawing.Size(440, 180);

            this.cbPhongThongBao = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, 40), Width = 180 };
            this.btnGuiThongBao = new System.Windows.Forms.Button
            {
                Text = "📢 Gửi thông báo",
                Location = new System.Drawing.Point(220, 38),
                Size = new System.Drawing.Size(150, 35),
                BackColor = System.Drawing.Color.MediumSeaGreen,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            this.btnGuiThongBao.Click += new System.EventHandler(this.btnGuiThongBao_Click);

            this.txtNoiDungThongBao = new System.Windows.Forms.TextBox
            {
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(350, 80),
                Multiline = true
            };

            this.gbThongBao.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                cbPhongThongBao, btnGuiThongBao, txtNoiDungThongBao
            });

            // === GroupBox: Trạng thái ===
            this.gbTrangThai = new System.Windows.Forms.GroupBox();
            this.gbTrangThai.Text = "Hiện trạng thanh toán";
            this.gbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbTrangThai.Location = new System.Drawing.Point(680, 270);
            this.gbTrangThai.Size = new System.Drawing.Size(440, 180);

            this.cbTrangThai = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 45), Width = 200 };
            this.cbTrangThai.Items.AddRange(new string[] { "Đã thanh toán", "Chưa thanh toán" });

            this.gbTrangThai.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                new System.Windows.Forms.Label(){Text="Trạng thái:",Location=new System.Drawing.Point(20,50),AutoSize=true},
                cbTrangThai
            });

            // === DataGridView Hóa đơn ===
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dgvHoaDon.Location = new System.Drawing.Point(220, 470);
            this.dgvHoaDon.Size = new System.Drawing.Size(440, 200);
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // === DataGridView Thông báo ===
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.dgvThongBao.Location = new System.Drawing.Point(680, 470);
            this.dgvThongBao.Size = new System.Drawing.Size(440, 200);
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvThongBao.ReadOnly = true;
            this.dgvThongBao.RowHeadersVisible = false;
            this.dgvThongBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // === Add Controls ===
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbThongBao);
            this.Controls.Add(this.gbTrangThai);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.dgvThongBao);

            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Size = new System.Drawing.Size(1150, 700);
        }
    }
}
