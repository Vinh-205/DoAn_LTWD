namespace Phong_Tro_GUI
{
    partial class PhongDangThue
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.PictureBox picAnhMinhHoa;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblGiaThue;
        private System.Windows.Forms.Label lblDienTich;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblChuTro;
        private System.Windows.Forms.TextBox txtTienNghi;
        private System.Windows.Forms.GroupBox groupBoxChiTiet;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.picAnhMinhHoa = new System.Windows.Forms.PictureBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblGiaThue = new System.Windows.Forms.Label();
            this.lblDienTich = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblChuTro = new System.Windows.Forms.Label();
            this.txtTienNghi = new System.Windows.Forms.TextBox();
            this.groupBoxChiTiet = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMinhHoa)).BeginInit();
            this.groupBoxChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 40);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "🏠 DANH SÁCH PHÒNG ĐANG THUÊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPhong.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            this.dgvPhong.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvPhong.EnableHeadersVisualStyles = false;
            this.dgvPhong.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvPhong.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);
            this.dgvPhong.Location = new System.Drawing.Point(20, 85);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(600, 220);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(120, 50);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.Text = "🔍 Nhập tên phòng hoặc mã phòng...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTimKiem.Location = new System.Drawing.Point(30, 54);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(84, 23);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // groupBoxChiTiet
            // 
            this.groupBoxChiTiet.BackColor = System.Drawing.Color.White;
            this.groupBoxChiTiet.Controls.Add(this.lblChuTro);
            this.groupBoxChiTiet.Controls.Add(this.txtTienNghi);
            this.groupBoxChiTiet.Controls.Add(this.lblTrangThai);
            this.groupBoxChiTiet.Controls.Add(this.lblDienTich);
            this.groupBoxChiTiet.Controls.Add(this.lblGiaThue);
            this.groupBoxChiTiet.Controls.Add(this.lblLoaiPhong);
            this.groupBoxChiTiet.Controls.Add(this.lblTenPhong);
            this.groupBoxChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxChiTiet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxChiTiet.Location = new System.Drawing.Point(20, 320);
            this.groupBoxChiTiet.Name = "groupBoxChiTiet";
            this.groupBoxChiTiet.Size = new System.Drawing.Size(380, 220);
            this.groupBoxChiTiet.TabIndex = 3;
            this.groupBoxChiTiet.TabStop = false;
            this.groupBoxChiTiet.Text = "Thông tin chi tiết";
            // 
            // picAnhMinhHoa
            // 
            this.picAnhMinhHoa.BackColor = System.Drawing.Color.White;
            this.picAnhMinhHoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnhMinhHoa.Location = new System.Drawing.Point(420, 320);
            this.picAnhMinhHoa.Name = "picAnhMinhHoa";
            this.picAnhMinhHoa.Size = new System.Drawing.Size(200, 200);
            this.picAnhMinhHoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMinhHoa.TabIndex = 4;
            this.picAnhMinhHoa.TabStop = false;
            // 
            // Labels chi tiết
            // 
            this.lblTenPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenPhong.Location = new System.Drawing.Point(20, 30);
            this.lblTenPhong.Size = new System.Drawing.Size(300, 22);
            this.lblTenPhong.Text = "Tên phòng: ...";
            this.lblLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoaiPhong.Location = new System.Drawing.Point(20, 55);
            this.lblLoaiPhong.Text = "Loại phòng: ...";
            this.lblGiaThue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiaThue.Location = new System.Drawing.Point(20, 80);
            this.lblGiaThue.Text = "Giá thuê: ...";
            this.lblDienTich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDienTich.Location = new System.Drawing.Point(20, 105);
            this.lblDienTich.Text = "Diện tích: ...";
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTrangThai.Location = new System.Drawing.Point(20, 130);
            this.lblTrangThai.Text = "Trạng thái: ...";
            this.lblChuTro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChuTro.Location = new System.Drawing.Point(20, 155);
            this.lblChuTro.Text = "Chủ trọ: ...";
            // 
            // txtTienNghi
            // 
            this.txtTienNghi.BackColor = System.Drawing.Color.White;
            this.txtTienNghi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTienNghi.Location = new System.Drawing.Point(20, 180);
            this.txtTienNghi.Multiline = true;
            this.txtTienNghi.Name = "txtTienNghi";
            this.txtTienNghi.ReadOnly = true;
            this.txtTienNghi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTienNghi.Size = new System.Drawing.Size(340, 35);
            this.txtTienNghi.TabIndex = 5;
            // 
            // PhongDangThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(650, 570);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picAnhMinhHoa);
            this.Controls.Add(this.groupBoxChiTiet);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvPhong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PhongDangThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng đang thuê";
            this.Load += new System.EventHandler(this.PhongDangThue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMinhHoa)).EndInit();
            this.groupBoxChiTiet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
