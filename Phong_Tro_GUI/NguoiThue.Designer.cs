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
        private Label lblTieuDe;
        private Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThongBao = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnPhongDangThue = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
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
            this.pnlMenu.Location = new System.Drawing.Point(12, 78);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(235, 360);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.Firebrick;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Location = new System.Drawing.Point(35, 271);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(170, 38);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "🚪  Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // btnThongBao
            // 
            this.btnThongBao.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongBao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongBao.ForeColor = System.Drawing.Color.White;
            this.btnThongBao.Location = new System.Drawing.Point(3, 211);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(222, 38);
            this.btnThongBao.TabIndex = 1;
            this.btnThongBao.Text = "🔔  Thông báo";
            this.btnThongBao.UseVisualStyleBackColor = false;
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoaDon.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnHoaDon.Location = new System.Drawing.Point(6, 152);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(222, 38);
            this.btnHoaDon.TabIndex = 2;
            this.btnHoaDon.Text = "🧾  Hóa đơn của tôi";
            this.btnHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnPhongDangThue
            // 
            this.btnPhongDangThue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPhongDangThue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhongDangThue.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhongDangThue.ForeColor = System.Drawing.Color.White;
            this.btnPhongDangThue.Location = new System.Drawing.Point(6, 97);
            this.btnPhongDangThue.Name = "btnPhongDangThue";
            this.btnPhongDangThue.Size = new System.Drawing.Size(222, 38);
            this.btnPhongDangThue.TabIndex = 3;
            this.btnPhongDangThue.Text = "🏠  Phòng đang thuê";
            this.btnPhongDangThue.UseVisualStyleBackColor = false;
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTin.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Bold);
            this.btnThongTin.ForeColor = System.Drawing.Color.White;
            this.btnThongTin.Location = new System.Drawing.Point(6, 40);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(222, 38);
            this.btnThongTin.TabIndex = 4;
            this.btnThongTin.Text = "👤  Thông tin cá nhân";
            this.btnThongTin.UseVisualStyleBackColor = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(202, 11);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(550, 40);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "🌿 HỆ THỐNG DÀNH CHO NGƯỜI THUÊ 🌿";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Location = new System.Drawing.Point(253, 78);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(687, 360);
            this.pnlContent.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(954, 65);
            this.panelHeader.TabIndex = 4;
            // 
            // NguoiThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(954, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Name = "NguoiThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người thuê - Quản lý phòng trọ";
            this.pnlMenu.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
    }
}
