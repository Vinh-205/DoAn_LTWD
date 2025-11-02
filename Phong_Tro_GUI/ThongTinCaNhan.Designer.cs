namespace Phong_Tro_GUI
{
    partial class ThongTinCaNhan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 60;
            this.panelHeader.Controls.Add(this.lblTitle);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(40, 90);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(160, 160);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAvatar.Region = new System.Drawing.Region(new System.Drawing.Drawing2D.GraphicsPath()); // gợi ý: cắt tròn trong code-behind
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Location = new System.Drawing.Point(220, 90);
            this.panelInfo.Size = new System.Drawing.Size(550, 200);
            this.panelInfo.Controls.Add(this.lblTen);
            this.panelInfo.Controls.Add(this.lblSDT);
            this.panelInfo.Controls.Add(this.lblEmail);
            this.panelInfo.Controls.Add(this.lblCCCD);
            this.panelInfo.Controls.Add(this.lblNgaySinh);
            this.panelInfo.Controls.Add(this.lblDiaChi);
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTen.Location = new System.Drawing.Point(10, 10);
            this.lblTen.Size = new System.Drawing.Size(500, 28);
            this.lblTen.Text = "👤 Tên: ";
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSDT.Location = new System.Drawing.Point(10, 45);
            this.lblSDT.Size = new System.Drawing.Size(500, 24);
            this.lblSDT.Text = "📞 SĐT: ";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblEmail.Location = new System.Drawing.Point(10, 75);
            this.lblEmail.Size = new System.Drawing.Size(500, 24);
            this.lblEmail.Text = "📧 Email: ";
            // 
            // lblCCCD
            // 
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCCCD.Location = new System.Drawing.Point(10, 105);
            this.lblCCCD.Size = new System.Drawing.Size(500, 24);
            this.lblCCCD.Text = "🪪 CCCD: ";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNgaySinh.Location = new System.Drawing.Point(10, 135);
            this.lblNgaySinh.Size = new System.Drawing.Size(500, 24);
            this.lblNgaySinh.Text = "🎂 Ngày sinh: ";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDiaChi.Location = new System.Drawing.Point(10, 165);
            this.lblDiaChi.Size = new System.Drawing.Size(500, 24);
            this.lblDiaChi.Text = "📍 Địa chỉ: ";
            // 
            // ThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 340);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.panelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Cá Nhân";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
