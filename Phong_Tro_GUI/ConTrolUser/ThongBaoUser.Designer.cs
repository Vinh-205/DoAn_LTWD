namespace Phong_Tro_GUI.ConTrolUser
{
    partial class ThongBaoUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvThongBao;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.GroupBox groupBoxChiTiet;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvThongBao = new System.Windows.Forms.DataGridView();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.groupBoxChiTiet = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).BeginInit();
            this.groupBoxChiTiet.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThongBao
            // 
            this.dgvThongBao.AllowUserToAddRows = false;
            this.dgvThongBao.AllowUserToDeleteRows = false;
            this.dgvThongBao.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.dgvThongBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvThongBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongBao.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvThongBao.ColumnHeadersHeight = 29;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvThongBao.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvThongBao.EnableHeadersVisualStyles = false;
            this.dgvThongBao.GridColor = System.Drawing.Color.LightGray;
            this.dgvThongBao.Location = new System.Drawing.Point(20, 115);
            this.dgvThongBao.MultiSelect = false;
            this.dgvThongBao.Name = "dgvThongBao";
            this.dgvThongBao.ReadOnly = true;
            this.dgvThongBao.RowHeadersVisible = false;
            this.dgvThongBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongBao.Size = new System.Drawing.Size(560, 250);
            this.dgvThongBao.TabIndex = 3;
            this.dgvThongBao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongBao_CellClick);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(156, 72);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.Text = "Nhập từ khóa...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTimKiem.Location = new System.Drawing.Point(30, 75);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(120, 23);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BackColor = System.Drawing.Color.White;
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoiDung.Location = new System.Drawing.Point(20, 55);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(520, 80);
            this.txtNoiDung.TabIndex = 0;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhong.ForeColor = System.Drawing.Color.Black;
            this.lblPhong.Location = new System.Drawing.Point(20, 25);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(78, 21);
            this.lblPhong.TabIndex = 1;
            this.lblPhong.Text = "Phòng: —";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgay.ForeColor = System.Drawing.Color.Black;
            this.lblNgay.Location = new System.Drawing.Point(400, 25);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(70, 21);
            this.lblNgay.TabIndex = 2;
            this.lblNgay.Text = "Ngày: —";
            // 
            // groupBoxChiTiet
            // 
            this.groupBoxChiTiet.BackColor = System.Drawing.Color.White;
            this.groupBoxChiTiet.Controls.Add(this.txtNoiDung);
            this.groupBoxChiTiet.Controls.Add(this.lblNgay);
            this.groupBoxChiTiet.Controls.Add(this.lblPhong);
            this.groupBoxChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxChiTiet.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxChiTiet.Location = new System.Drawing.Point(20, 380);
            this.groupBoxChiTiet.Name = "groupBoxChiTiet";
            this.groupBoxChiTiet.Size = new System.Drawing.Size(560, 150);
            this.groupBoxChiTiet.TabIndex = 4;
            this.groupBoxChiTiet.TabStop = false;
            this.groupBoxChiTiet.Text = "📄 Chi tiết thông báo";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(600, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "📢 THÔNG BÁO NGƯỜI DÙNG";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThongBaoUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.groupBoxChiTiet);
            this.Controls.Add(this.dgvThongBao);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Name = "ThongBaoUser";
            this.Size = new System.Drawing.Size(600, 560);
            this.Load += new System.EventHandler(this.ThongBaoUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongBao)).EndInit();
            this.groupBoxChiTiet.ResumeLayout(false);
            this.groupBoxChiTiet.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
