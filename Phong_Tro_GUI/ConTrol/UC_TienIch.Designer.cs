using System.Windows.Forms;
using System.Drawing;

namespace Phong_Tro_GUI
{
    partial class UC_TienIch : UserControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private DataGridView dgvDichVu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlFormNhap;
        private TextBox txtMaDV;
        private TextBox txtTenDV;
        private TextBox txtDonGia;
        private TextBox txtMoTa;
        private Label lblMaDV;
        private Label lblTenDV;
        private Label lblDonGia;
        private Label lblMoTa;
        private Panel panelHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlFormNhap = new System.Windows.Forms.Panel();
            this.lblMaDV = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.pnlFormNhap.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(140, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(600, 42);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "⚙️ QUẢN LÝ TIỆN ÍCH PHÒNG TRỌ ⚙️";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Location = new System.Drawing.Point(20, 268);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.RowHeadersWidth = 51;
            this.dgvDichVu.Size = new System.Drawing.Size(720, 220);
            this.dgvDichVu.TabIndex = 0;            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(759, 73);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 35);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "➕  Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(759, 123);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 35);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "✏️  Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(759, 173);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 35);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "🗑️  Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(759, 227);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 35);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "🔄  Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // pnlFormNhap
            // 
            this.pnlFormNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlFormNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormNhap.Controls.Add(this.lblMaDV);
            this.pnlFormNhap.Controls.Add(this.txtMaDV);
            this.pnlFormNhap.Controls.Add(this.lblTenDV);
            this.pnlFormNhap.Controls.Add(this.txtTenDV);
            this.pnlFormNhap.Controls.Add(this.lblDonGia);
            this.pnlFormNhap.Controls.Add(this.txtDonGia);
            this.pnlFormNhap.Controls.Add(this.lblMoTa);
            this.pnlFormNhap.Controls.Add(this.txtMoTa);
            this.pnlFormNhap.Location = new System.Drawing.Point(20, 73);
            this.pnlFormNhap.Name = "pnlFormNhap";
            this.pnlFormNhap.Size = new System.Drawing.Size(720, 189);
            this.pnlFormNhap.TabIndex = 1;
            // 
            // lblMaDV
            // 
            this.lblMaDV.Location = new System.Drawing.Point(24, 23);
            this.lblMaDV.Name = "lblMaDV";
            this.lblMaDV.Size = new System.Drawing.Size(75, 25);
            this.lblMaDV.TabIndex = 0;
            this.lblMaDV.Text = "Mã dịch vụ:";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.txtMaDV.Location = new System.Drawing.Point(105, 20);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(150, 22);
            this.txtMaDV.TabIndex = 1;
            // 
            // lblTenDV
            // 
            this.lblTenDV.Location = new System.Drawing.Point(324, 23);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(86, 25);
            this.lblTenDV.TabIndex = 2;
            this.lblTenDV.Text = "Tên dịch vụ:";
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(416, 20);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(250, 22);
            this.txtTenDV.TabIndex = 3;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(24, 79);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(57, 25);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(105, 76);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(150, 22);
            this.txtDonGia.TabIndex = 5;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(324, 79);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(48, 25);
            this.lblMoTa.TabIndex = 6;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(416, 74);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(250, 60);
            this.txtMoTa.TabIndex = 7;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelHeader.Controls.Add(this.lblTieuDe);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(891, 67);
            this.panelHeader.TabIndex = 6;
            // 
            // TienIch (UserControl)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.pnlFormNhap);
            this.Controls.Add(this.dgvDichVu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "TienIch";
            this.Size = new System.Drawing.Size(891, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.pnlFormNhap.ResumeLayout(false);
            this.pnlFormNhap.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
