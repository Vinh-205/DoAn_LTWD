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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMinhHoa)).BeginInit();
            this.groupBoxChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(20, 55);
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(600, 220);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(110, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTimKiem.Location = new System.Drawing.Point(30, 22);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(74, 17);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // groupBoxChiTiet
            // 
            this.groupBoxChiTiet.Controls.Add(this.lblChuTro);
            this.groupBoxChiTiet.Controls.Add(this.txtTienNghi);
            this.groupBoxChiTiet.Controls.Add(this.lblTrangThai);
            this.groupBoxChiTiet.Controls.Add(this.lblDienTich);
            this.groupBoxChiTiet.Controls.Add(this.lblGiaThue);
            this.groupBoxChiTiet.Controls.Add(this.lblLoaiPhong);
            this.groupBoxChiTiet.Controls.Add(this.lblTenPhong);
            this.groupBoxChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBoxChiTiet.Location = new System.Drawing.Point(20, 290);
            this.groupBoxChiTiet.Name = "groupBoxChiTiet";
            this.groupBoxChiTiet.Size = new System.Drawing.Size(380, 240);
            this.groupBoxChiTiet.TabIndex = 3;
            this.groupBoxChiTiet.TabStop = false;
            this.groupBoxChiTiet.Text = "Thông tin chi tiết";
            // 
            // picAnhMinhHoa
            // 
            this.picAnhMinhHoa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picAnhMinhHoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnhMinhHoa.Location = new System.Drawing.Point(420, 290);
            this.picAnhMinhHoa.Name = "picAnhMinhHoa";
            this.picAnhMinhHoa.Size = new System.Drawing.Size(200, 200);
            this.picAnhMinhHoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMinhHoa.TabIndex = 4;
            this.picAnhMinhHoa.TabStop = false;
            // 
            // labels
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTenPhong.Location = new System.Drawing.Point(20, 30);
            this.lblTenPhong.Text = "Tên phòng: ...";
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLoaiPhong.Location = new System.Drawing.Point(20, 55);
            this.lblLoaiPhong.Text = "Loại phòng: ...";
            this.lblGiaThue.AutoSize = true;
            this.lblGiaThue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGiaThue.Location = new System.Drawing.Point(20, 80);
            this.lblGiaThue.Text = "Giá thuê: ...";
            this.lblDienTich.AutoSize = true;
            this.lblDienTich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDienTich.Location = new System.Drawing.Point(20, 105);
            this.lblDienTich.Text = "Diện tích: ...";
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTrangThai.Location = new System.Drawing.Point(20, 130);
            this.lblTrangThai.Text = "Trạng thái: ...";
            this.lblChuTro.AutoSize = true;
            this.lblChuTro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChuTro.Location = new System.Drawing.Point(20, 155);
            this.lblChuTro.Text = "Chủ trọ: ...";
            // 
            // txtTienNghi
            // 
            this.txtTienNghi.BackColor = System.Drawing.Color.White;
            this.txtTienNghi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTienNghi.Location = new System.Drawing.Point(20, 180);
            this.txtTienNghi.Multiline = true;
            this.txtTienNghi.Name = "txtTienNghi";
            this.txtTienNghi.ReadOnly = true;
            this.txtTienNghi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTienNghi.Size = new System.Drawing.Size(340, 50);
            this.txtTienNghi.TabIndex = 5;
            // 
            // PhongDangThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(640, 550);
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
            this.groupBoxChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
