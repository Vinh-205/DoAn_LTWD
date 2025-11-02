using System.Windows.Forms;
using System.Drawing;

namespace Phong_Tro_GUI
{
    partial class NguoiThueUser
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
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnDangXuat);
            this.pnlMenu.Controls.Add(this.btnThongBao);
            this.pnlMenu.Controls.Add(this.btnHoaDon);
            this.pnlMenu.Controls.Add(this.btnPhongDangThue);
            this.pnlMenu.Controls.Add(this.btnThongTin);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 65);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 585);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(40, 510);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(170, 38);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = "🚪  Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongBao.FlatAppearance.BorderSize = 0;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongBao.ForeColor = System.Drawing.Color.White;
            this.btnThongBao.Location = new System.Drawing.Point(10, 205);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(220, 38);
            this.btnThongBao.TabIndex = 3;
            this.btnThongBao.Text = "🔔  Thông báo";
            this.btnThongBao.UseVisualStyleBackColor = false;
            this.btnThongBao.Click += new System.EventHandler(this.btnThongBao_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHoaDon.FlatAppearance.BorderSize = 0;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Location = new System.Drawing.Point(10, 150);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(220, 38);
            this.btnHoaDon.TabIndex = 2;
            this.btnHoaDon.Text = "🧾  Hóa đơn của tôi";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnPhongDangThue
            // 
            this.btnPhongDangThue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPhongDangThue.FlatAppearance.BorderSize = 0;
            this.btnPhongDangThue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhongDangThue.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhongDangThue.ForeColor = System.Drawing.Color.White;
            this.btnPhongDangThue.Location = new System.Drawing.Point(10, 95);
            this.btnPhongDangThue.Name = "btnPhongDangThue";
            this.btnPhongDangThue.Size = new System.Drawing.Size(220, 38);
            this.btnPhongDangThue.TabIndex = 1;
            this.btnPhongDangThue.Text = "🏠  Phòng đang thuê";
            this.btnPhongDangThue.UseVisualStyleBackColor = false;
            this.btnPhongDangThue.Click += new System.EventHandler(this.btnPhongDangThue_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongTin.FlatAppearance.BorderSize = 0;
            this.btnThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTin.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongTin.ForeColor = System.Drawing.Color.White;
            this.btnThongTin.Location = new System.Drawing.Point(10, 40);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(220, 38);
            this.btnThongTin.TabIndex = 0;
            this.btnThongTin.Text = "👤  Thông tin cá nhân";
            this.btnThongTin.UseVisualStyleBackColor = false;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1080, 65);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(252, 11);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(574, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "🌿 HỆ THỐNG DÀNH CHO NGƯỜI THUÊ 🌿";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 65);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(830, 585);
            this.pnlContent.TabIndex = 2;
            // 
            // UC_NguoiThue
            // 
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.panelHeader);
            this.Name = "UC_NguoiThue";
            this.Size = new System.Drawing.Size(1080, 650);
            this.pnlMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
