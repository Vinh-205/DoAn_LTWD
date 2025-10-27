namespace Phong_Tro_GUI
{
    partial class ChuTro
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnQuanLyPhong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThongBao;
        private System.Windows.Forms.Button btnQuanLyHoaDon;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTenChuTro;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnQuanLyHoaDon = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnQuanLyPhong = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblTenChuTro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnThoat);
            this.pnlMenu.Controls.Add(this.btnTrangChu);
            this.pnlMenu.Controls.Add(this.btnQuanLyHoaDon);
            this.pnlMenu.Controls.Add(this.btnThongBao);
            this.pnlMenu.Controls.Add(this.btnThongKe);
            this.pnlMenu.Controls.Add(this.btnQuanLyPhong);
            this.pnlMenu.Location = new System.Drawing.Point(8, 109);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 388);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(30, 334);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(160, 35);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "🚪 Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.Location = new System.Drawing.Point(30, 13);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(160, 35);
            this.btnTrangChu.TabIndex = 5;
            this.btnTrangChu.Text = "🏠 Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            // 
            // btnQuanLyHoaDon
            // 
            this.btnQuanLyHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnQuanLyHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(30, 141);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(160, 35);
            this.btnQuanLyHoaDon.TabIndex = 1;
            this.btnQuanLyHoaDon.Text = "💰 Quản lý hóa đơn";
            this.btnQuanLyHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongBao.ForeColor = System.Drawing.Color.White;
            this.btnThongBao.Location = new System.Drawing.Point(30, 267);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(160, 35);
            this.btnThongBao.TabIndex = 2;
            this.btnThongBao.Text = "💬 Thông báo";
            this.btnThongBao.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(30, 203);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(160, 35);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "📊 Thống kê doanh thu";
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnQuanLyPhong
            // 
            this.btnQuanLyPhong.BackColor = System.Drawing.Color.SteelBlue;
            this.btnQuanLyPhong.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyPhong.Location = new System.Drawing.Point(30, 74);
            this.btnQuanLyPhong.Name = "btnQuanLyPhong";
            this.btnQuanLyPhong.Size = new System.Drawing.Size(160, 35);
            this.btnQuanLyPhong.TabIndex = 4;
            this.btnQuanLyPhong.Text = "🏢 Quản lý phòng";
            this.btnQuanLyPhong.UseVisualStyleBackColor = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(39, 519);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(160, 35);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "❌ Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(231, 24);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(666, 35);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "🏡 HỆ THỐNG QUẢN LÝ PHÒNG TRỌ - CHỦ TRỌ";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenChuTro
            // 
            this.lblTenChuTro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblTenChuTro.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTenChuTro.Location = new System.Drawing.Point(35, 81);
            this.lblTenChuTro.Name = "lblTenChuTro";
            this.lblTenChuTro.Size = new System.Drawing.Size(174, 25);
            this.lblTenChuTro.TabIndex = 0;
            this.lblTenChuTro.Text = "\"Xin chào, họ và tên !\"";
            this.lblTenChuTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.lblTieuDe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1094, 78);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(238, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 497);
            this.panel2.TabIndex = 4;
            // 
            // ChuTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1094, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.lblTenChuTro);
            this.Controls.Add(this.pnlMenu);
            this.Name = "ChuTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chủ trọ - Quản lý phòng trọ";
            this.pnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Panel panel2;
    }
}
