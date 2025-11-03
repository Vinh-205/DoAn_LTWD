namespace Phong_Tro_GUI
{
    partial class PhongMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpThongTinPhong;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblGiaPhong;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtGiaPhong;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.DataGridView dgvDanhSachPhong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpThongTinPhong = new System.Windows.Forms.GroupBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.lblGiaPhong = new System.Windows.Forms.Label();
            this.txtGiaPhong = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.dgvDanhSachPhong = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.grpThongTinPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhong)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTinPhong
            // 
            this.grpThongTinPhong.BackColor = System.Drawing.Color.Silver;
            this.grpThongTinPhong.Controls.Add(this.lblMaPhong);
            this.grpThongTinPhong.Controls.Add(this.txtMaPhong);
            this.grpThongTinPhong.Controls.Add(this.lblTenPhong);
            this.grpThongTinPhong.Controls.Add(this.txtTenPhong);
            this.grpThongTinPhong.Controls.Add(this.lblGiaPhong);
            this.grpThongTinPhong.Controls.Add(this.txtGiaPhong);
            this.grpThongTinPhong.Controls.Add(this.lblTrangThai);
            this.grpThongTinPhong.Controls.Add(this.cboTrangThai);
            this.grpThongTinPhong.Controls.Add(this.lblMoTa);
            this.grpThongTinPhong.Controls.Add(this.txtMoTa);
            this.grpThongTinPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpThongTinPhong.Location = new System.Drawing.Point(20, 80);
            this.grpThongTinPhong.Name = "grpThongTinPhong";
            this.grpThongTinPhong.Size = new System.Drawing.Size(380, 300);
            this.grpThongTinPhong.TabIndex = 1;
            this.grpThongTinPhong.TabStop = false;
            this.grpThongTinPhong.Text = "Thông tin phòng";
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.Location = new System.Drawing.Point(20, 40);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(100, 23);
            this.lblMaPhong.TabIndex = 0;
            this.lblMaPhong.Text = "Mã phòng:";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(140, 40);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(200, 30);
            this.txtMaPhong.TabIndex = 1;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.Location = new System.Drawing.Point(20, 80);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(100, 23);
            this.lblTenPhong.TabIndex = 2;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(140, 80);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(200, 30);
            this.txtTenPhong.TabIndex = 3;
            // 
            // lblGiaPhong
            // 
            this.lblGiaPhong.Location = new System.Drawing.Point(20, 120);
            this.lblGiaPhong.Name = "lblGiaPhong";
            this.lblGiaPhong.Size = new System.Drawing.Size(100, 23);
            this.lblGiaPhong.TabIndex = 4;
            this.lblGiaPhong.Text = "Giá phòng:";
            // 
            // txtGiaPhong
            // 
            this.txtGiaPhong.Location = new System.Drawing.Point(140, 120);
            this.txtGiaPhong.Name = "txtGiaPhong";
            this.txtGiaPhong.Size = new System.Drawing.Size(200, 30);
            this.txtGiaPhong.TabIndex = 5;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(20, 160);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Items.AddRange(new object[] {
            "Trống",
            "Đã thuê",
            "Bảo trì"});
            this.cboTrangThai.Location = new System.Drawing.Point(140, 160);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(200, 31);
            this.cboTrangThai.TabIndex = 7;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(20, 200);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(100, 23);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(140, 200);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(200, 60);
            this.txtMoTa.TabIndex = 9;
            // 
            // dgvDanhSachPhong
            // 
            this.dgvDanhSachPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachPhong.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDanhSachPhong.ColumnHeadersHeight = 29;
            this.dgvDanhSachPhong.Location = new System.Drawing.Point(420, 80);
            this.dgvDanhSachPhong.Name = "dgvDanhSachPhong";
            this.dgvDanhSachPhong.RowHeadersWidth = 51;
            this.dgvDanhSachPhong.Size = new System.Drawing.Size(550, 260);
            this.dgvDanhSachPhong.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Teal;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(420, 360);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 32);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(560, 360);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 32);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(707, 360);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 32);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.Location = new System.Drawing.Point(850, 360);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 32);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(296, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(400, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ PHÒNG TRỌ";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightGray;
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 67);
            this.panelHeader.TabIndex = 7;
            // 
            // PhongMain
            // 
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.grpThongTinPhong);
            this.Controls.Add(this.dgvDanhSachPhong);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "PhongMain";
            this.Size = new System.Drawing.Size(1000, 420);
            this.Load += new System.EventHandler(this.PhongMain_Load);
            this.grpThongTinPhong.ResumeLayout(false);
            this.grpThongTinPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachPhong)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
