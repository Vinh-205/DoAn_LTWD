using System.Windows.Forms;
using System.Drawing;

namespace Phong_Tro_GUI
{
    partial class NguoiThue
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMenu;
        private Button btnThongTin;
        private Button btnPhongDangThue;
        private Button btnHoaDon;
        private Button btnThongBao;
        private Button btnDangXuat;
        private Panel panelHeader;
        private Label lblTieuDe;
        private Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnPhongDangThue = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = Color.FromArgb(230, 240, 255);
            this.pnlMenu.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.btnThongBao);
            this.pnlMenu.Controls.Add(this.btnHoaDon);
            this.pnlMenu.Controls.Add(this.btnPhongDangThue);
            this.pnlMenu.Controls.Add(this.btnThongTin);
            this.pnlMenu.Dock = DockStyle.Left;
            this.pnlMenu.Location = new Point(0, 65);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new Size(250, 585);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = Color.Firebrick;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = FlatStyle.Flat;
            this.btnDangXuat.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            this.btnDangXuat.ForeColor = Color.White;
            this.btnDangXuat.Location = new Point(40, 510);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new Size(170, 38);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "🚪  Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = Color.SteelBlue;
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatStyle = FlatStyle.Flat;
            this.btnThongBao.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            this.btnThongBao.ForeColor = Color.White;
            this.btnThongBao.Location = new Point(10, 205);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new Size(220, 38);
            this.btnThongBao.TabIndex = 3;
            this.btnThongBao.Text = "🔔  Thông báo";
            this.btnThongBao.UseVisualStyleBackColor = false;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = Color.SteelBlue;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = FlatStyle.Flat;
            this.btnHoaDon.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            this.btnHoaDon.ForeColor = Color.White;
            this.btnHoaDon.Location = new Point(10, 150);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new Size(220, 38);
            this.btnHoaDon.TabIndex = 2;
            this.btnHoaDon.Text = "🧾  Hóa đơn của tôi";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnPhongDangThue
            // 
            this.btnPhongDangThue.BackColor = Color.SteelBlue;
            this.btnPhongDangThue.FlatAppearance.BorderSize = 0;
            this.btnPhongDangThue.FlatStyle = FlatStyle.Flat;
            this.btnPhongDangThue.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            this.btnPhongDangThue.ForeColor = Color.White;
            this.btnPhongDangThue.Location = new Point(10, 95);
            this.btnPhongDangThue.Name = "btnPhongDangThue";
            this.btnPhongDangThue.Size = new Size(220, 38);
            this.btnPhongDangThue.TabIndex = 1;
            this.btnPhongDangThue.Text = "🏠  Phòng đang thuê";
            this.btnPhongDangThue.UseVisualStyleBackColor = false;
            this.btnPhongDangThue.Click += new System.EventHandler(this.btnPhongDangThue_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = Color.SteelBlue;
            this.btnThongTin.FlatAppearance.BorderSize = 0;
            this.btnThongTin.FlatStyle = FlatStyle.Flat;
            this.btnThongTin.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            this.btnThongTin.ForeColor = Color.White;
            this.btnThongTin.Location = new Point(10, 40);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new Size(220, 38);
            this.btnThongTin.TabIndex = 0;
            this.btnThongTin.Text = "👤  Thông tin cá nhân";
            this.btnThongTin.UseVisualStyleBackColor = false;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = Color.FromArgb(224, 224, 224);
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new Size(1080, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.MidnightBlue;
            this.lblTieuDe.Location = new Point(252, 11);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(574, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🌿 HỆ THỐNG DÀNH CHO NGƯỜI THUÊ 🌿";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = Color.WhiteSmoke;
            this.pnlContent.BorderStyle = BorderStyle.FixedSingle;
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Location = new Point(250, 65);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new Size(830, 585);
            this.pnlContent.TabIndex = 2;
            // 
            // NguoiThue
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1080, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hệ thống người thuê";
            this.pnlMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
