namespace Phong_Tro_GUI
{
    partial class HoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTienPhong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienDien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTienNuoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.gbThongBao = new System.Windows.Forms.GroupBox();
            this.cbPhongThongBao = new System.Windows.Forms.ComboBox();
            this.txtNoiDungThongBao = new System.Windows.Forms.TextBox();
            this.btnGuiThongBao = new System.Windows.Forms.Button();
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.gbHienTrang = new System.Windows.Forms.GroupBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.gbThongBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.gbHienTrang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(241, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "QUẢN LÝ HÓA ĐƠN";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.panelMenu.Controls.Add(this.btnThem);
            this.panelMenu.Controls.Add(this.btnSua);
            this.panelMenu.Controls.Add(this.btnXoa);
            this.panelMenu.Controls.Add(this.btnLamMoi);
            this.panelMenu.Controls.Add(this.txtTimKiem);
            this.panelMenu.Controls.Add(this.btnTimKiem);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 700);
            this.panelMenu.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(35, 40);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm HĐ";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(35, 90);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ Sửa HĐ";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(35, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xóa HĐ";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(35, 190);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(20, 260);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(160, 27);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Text = "Nhập mã hoặc tên KH...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTimKiem.Location = new System.Drawing.Point(35, 300);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(130, 40);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Controls.Add(this.txtMaHD);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.txtTenKH);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.cbPhong);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.dtpNgayLap);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.txtTienPhong);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.txtTienDien);
            this.gbThongTin.Controls.Add(this.label7);
            this.gbThongTin.Controls.Add(this.txtTienNuoc);
            this.gbThongTin.Controls.Add(this.label8);
            this.gbThongTin.Controls.Add(this.txtTongTien);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.gbThongTin.Location = new System.Drawing.Point(220, 80);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(960, 220);
            this.gbThongTin.TabIndex = 2;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin hóa đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hóa Đơn:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(150, 38);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(200, 30);
            this.txtMaHD.TabIndex = 1;
            this.txtMaHD.TextChanged += new System.EventHandler(this.txtMaHD_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(520, 38);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(200, 30);
            this.txtTenKH.TabIndex = 3;
            this.txtTenKH.TextChanged += new System.EventHandler(this.txtTenKH_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phòng:";
            // 
            // cbPhong
            // 
            this.cbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhong.Location = new System.Drawing.Point(150, 78);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(200, 31);
            this.cbPhong.TabIndex = 5;
            this.cbPhong.SelectedIndexChanged += new System.EventHandler(this.cbPhong_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Location = new System.Drawing.Point(520, 78);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(200, 30);
            this.dtpNgayLap.TabIndex = 7;
            this.dtpNgayLap.ValueChanged += new System.EventHandler(this.dtpNgayLap_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tiền phòng:";
            // 
            // txtTienPhong
            // 
            this.txtTienPhong.Location = new System.Drawing.Point(150, 118);
            this.txtTienPhong.Name = "txtTienPhong";
            this.txtTienPhong.Size = new System.Drawing.Size(200, 30);
            this.txtTienPhong.TabIndex = 9;
            this.txtTienPhong.TextChanged += new System.EventHandler(this.txtTienPhong_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tiền điện:";
            // 
            // txtTienDien
            // 
            this.txtTienDien.Location = new System.Drawing.Point(520, 118);
            this.txtTienDien.Name = "txtTienDien";
            this.txtTienDien.Size = new System.Drawing.Size(200, 30);
            this.txtTienDien.TabIndex = 11;
            this.txtTienDien.TextChanged += new System.EventHandler(this.txtTienDien_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tiền nước:";
            // 
            // txtTienNuoc
            // 
            this.txtTienNuoc.Location = new System.Drawing.Point(150, 158);
            this.txtTienNuoc.Name = "txtTienNuoc";
            this.txtTienNuoc.Size = new System.Drawing.Size(200, 30);
            this.txtTienNuoc.TabIndex = 13;
            this.txtTienNuoc.TextChanged += new System.EventHandler(this.txtTienNuoc_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(520, 158);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(200, 30);
            this.txtTongTien.TabIndex = 15;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // gbThongBao
            // 
            this.gbThongBao.Controls.Add(this.cbPhongThongBao);
            this.gbThongBao.Controls.Add(this.txtNoiDungThongBao);
            this.gbThongBao.Controls.Add(this.btnGuiThongBao);
            this.gbThongBao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.gbThongBao.Location = new System.Drawing.Point(220, 320);
            this.gbThongBao.Name = "gbThongBao";
            this.gbThongBao.Size = new System.Drawing.Size(460, 180);
            this.gbThongBao.TabIndex = 16;
            this.gbThongBao.TabStop = false;
            this.gbThongBao.Text = "Thông báo đến người thuê";
            // 
            // cbPhongThongBao
            // 
            this.cbPhongThongBao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhongThongBao.Location = new System.Drawing.Point(30, 40);
            this.cbPhongThongBao.Name = "cbPhongThongBao";
            this.cbPhongThongBao.Size = new System.Drawing.Size(200, 31);
            this.cbPhongThongBao.TabIndex = 0;
            this.cbPhongThongBao.SelectedIndexChanged += new System.EventHandler(this.cbPhongThongBao_SelectedIndexChanged);
            // 
            // txtNoiDungThongBao
            // 
            this.txtNoiDungThongBao.Location = new System.Drawing.Point(30, 80);
            this.txtNoiDungThongBao.Multiline = true;
            this.txtNoiDungThongBao.Name = "txtNoiDungThongBao";
            this.txtNoiDungThongBao.Size = new System.Drawing.Size(400, 60);
            this.txtNoiDungThongBao.TabIndex = 1;
            this.txtNoiDungThongBao.TextChanged += new System.EventHandler(this.txtNoiDungThongBao_TextChanged);
            // 
            // btnGuiThongBao
            // 
            this.btnGuiThongBao.BackColor = System.Drawing.Color.White;
            this.btnGuiThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiThongBao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuiThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnGuiThongBao.Location = new System.Drawing.Point(270, 41);
            this.btnGuiThongBao.Name = "btnGuiThongBao";
            this.btnGuiThongBao.Size = new System.Drawing.Size(160, 30);
            this.btnGuiThongBao.TabIndex = 2;
            this.btnGuiThongBao.Text = "📢 Gửi thông báo";
            this.btnGuiThongBao.UseVisualStyleBackColor = false;
            this.btnGuiThongBao.Click += new System.EventHandler(this.btnGuiThongBao_Click);
            // 
            // dgvThongBao
            // 
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongBao.Location = new System.Drawing.Point(220, 520);
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.ReadOnly = true;
            this.dgvThongBao.RowHeadersVisible = false;
            this.dgvThongBao.RowHeadersWidth = 51;
            this.dgvThongBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongBao.Size = new System.Drawing.Size(460, 150);
            this.dgvThongBao.TabIndex = 17;
            this.dgvThongBao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongBao_CellContentClick);
            // 
            // gbHienTrang
            // 
            this.gbHienTrang.Controls.Add(this.labelTrangThai);
            this.gbHienTrang.Controls.Add(this.cbTrangThai);
            this.gbHienTrang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbHienTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.gbHienTrang.Location = new System.Drawing.Point(700, 320);
            this.gbHienTrang.Name = "gbHienTrang";
            this.gbHienTrang.Size = new System.Drawing.Size(480, 180);
            this.gbHienTrang.TabIndex = 18;
            this.gbHienTrang.TabStop = false;
            this.gbHienTrang.Text = "Hiện trạng thanh toán";
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Location = new System.Drawing.Point(30, 40);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(91, 23);
            this.labelTrangThai.TabIndex = 0;
            this.labelTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Chưa thanh toán",
            "Đã thanh toán",
            "Quá hạn"});
            this.cbTrangThai.Location = new System.Drawing.Point(150, 38);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(200, 31);
            this.cbTrangThai.TabIndex = 1;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(700, 520);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(480, 150);
            this.dgvHoaDon.TabIndex = 19;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbThongBao);
            this.Controls.Add(this.gbHienTrang);
            this.Controls.Add(this.dgvThongBao);
            this.Controls.Add(this.dgvHoaDon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "HoaDon";
            this.Text = "Quản lý Hóa Đơn";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbThongBao.ResumeLayout(false);
            this.gbThongBao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.gbHienTrang.ResumeLayout(false);
            this.gbHienTrang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTienPhong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTienDien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTienNuoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTongTien;

        private System.Windows.Forms.GroupBox gbThongBao;
        private System.Windows.Forms.ComboBox cbPhongThongBao;
        private System.Windows.Forms.TextBox txtNoiDungThongBao;
        private System.Windows.Forms.Button btnGuiThongBao;
        private System.Windows.Forms.DataGridView dgvThongBao;

        private System.Windows.Forms.GroupBox gbHienTrang;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.ComboBox cbTrangThai;

        private System.Windows.Forms.DataGridView dgvHoaDon;
    }
}
