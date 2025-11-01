namespace Phong_Tro_GUI
{
    partial class UC_ChuTroDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTenChuTro;
        private System.Windows.Forms.Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTenChuTro = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(35, 60, 120);
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnThongKe);
            this.pnlSidebar.Controls.Add(this.btnThongBao);
            this.pnlSidebar.Controls.Add(this.btnHoaDon);
            this.pnlSidebar.Controls.Add(this.btnPhong);
            this.pnlSidebar.Controls.Add(this.btnMenu);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 650);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(45, 70, 140);
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(200, 55);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "☰ Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.Location = new System.Drawing.Point(10, 80);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(180, 40);
            this.btnPhong.TabIndex = 1;
            this.btnPhong.Text = "🏢 Quản lý phòng";
            this.btnPhong.UseVisualStyleBackColor = true;
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(10, 130);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(180, 40);
            this.btnHoaDon.TabIndex = 2;
            this.btnHoaDon.Text = "💰 Hóa đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnThongBao
            // 
            this.btnThongBao.Location = new System.Drawing.Point(10, 180);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(180, 40);
            this.btnThongBao.TabIndex = 3;
            this.btnThongBao.Text = "💬 Thông báo";
            this.btnThongBao.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(10, 230);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(180, 40);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "📊 Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(10, 580);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(180, 40);
            this.btnDangXuat.TabIndex = 5;
            this.btnDangXuat.Text = "🚪 Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(240, 242, 250);
            this.pnlHeader.Controls.Add(this.lblTenChuTro);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(200, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 70);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Text = "🏡 HỆ THỐNG CHỦ TRỌ";
            // 
            // lblTenChuTro
            // 
            this.lblTenChuTro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTenChuTro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblTenChuTro.ForeColor = System.Drawing.Color.Gray;
            this.lblTenChuTro.Location = new System.Drawing.Point(650, 25);
            this.lblTenChuTro.Name = "lblTenChuTro";
            this.lblTenChuTro.Size = new System.Drawing.Size(210, 25);
            this.lblTenChuTro.Text = "Xin chào, Chủ Trọ 👋";
            this.lblTenChuTro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 70);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(880, 580);
            this.pnlContent.TabIndex = 2;
            // 
            // UC_ChuTroDashboard
            // 
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "UC_ChuTroDashboard";
            this.Size = new System.Drawing.Size(1080, 650);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
