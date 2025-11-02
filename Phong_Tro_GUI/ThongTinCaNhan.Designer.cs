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
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(50, 56);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(248, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Cá Nhân";
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTen.Location = new System.Drawing.Point(250, 64);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(500, 24);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên: ";
            // 
            // lblSDT
            // 
            this.lblSDT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSDT.Location = new System.Drawing.Point(250, 96);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(500, 24);
            this.lblSDT.TabIndex = 3;
            this.lblSDT.Text = "SĐT: ";
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.Location = new System.Drawing.Point(250, 128);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(500, 24);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email: ";
            // 
            // lblCCCD
            // 
            this.lblCCCD.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblCCCD.Location = new System.Drawing.Point(250, 160);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(500, 24);
            this.lblCCCD.TabIndex = 5;
            this.lblCCCD.Text = "CCCD: ";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNgaySinh.Location = new System.Drawing.Point(250, 192);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(500, 24);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh: ";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDiaChi.Location = new System.Drawing.Point(250, 224);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(500, 24);
            this.lblDiaChi.TabIndex = 7;
            this.lblDiaChi.Text = "Địa chỉ: ";
            // 
            // ThongTinCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 320);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblDiaChi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ThongTinCaNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Cá Nhân";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
