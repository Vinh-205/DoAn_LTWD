// FormPhong.Designer.cs
namespace Phong_Tro_GUI
{
    partial class FormPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.gbPhong = new System.Windows.Forms.GroupBox();
            this.panelHall = new System.Windows.Forms.Panel();
            this.labelHall = new System.Windows.Forms.Label();
            this.btnPhong_P001 = new System.Windows.Forms.Button();
            this.btnPhong_P002 = new System.Windows.Forms.Button();
            this.btnPhong_P003 = new System.Windows.Forms.Button();
            this.btnPhong_P004 = new System.Windows.Forms.Button();
            this.btnPhong_P005 = new System.Windows.Forms.Button();
            this.btnPhong_P006 = new System.Windows.Forms.Button();
            this.btnPhong_P007 = new System.Windows.Forms.Button();
            this.btnPhong_P008 = new System.Windows.Forms.Button();
            this.btnPhong_P009 = new System.Windows.Forms.Button();
            this.btnPhong_P010 = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.gbPhong.SuspendLayout();
            this.panelHall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(200, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(201, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Sơ đồ phòng trọ";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.panelMenu.Controls.Add(this.btnThem);
            this.panelMenu.Controls.Add(this.btnSua);
            this.panelMenu.Controls.Add(this.btnXoa);
            this.panelMenu.Controls.Add(this.btnLamMoi);
            this.panelMenu.Controls.Add(this.txtTimKiem);
            this.panelMenu.Controls.Add(this.btnTimKiem);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 700);
            this.panelMenu.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnThem.Location = new System.Drawing.Point(35, 40);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "➕ Thêm phòng";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnSua.Location = new System.Drawing.Point(35, 90);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(130, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "✏️ Sửa phòng";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnXoa.Location = new System.Drawing.Point(35, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xóa phòng";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnLamMoi.Location = new System.Drawing.Point(35, 190);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 40);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(20, 260);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(160, 27);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.Text = "Nhập tên phòng...";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnTimKiem.Location = new System.Drawing.Point(35, 300);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(130, 40);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // gbPhong
            // 
            this.gbPhong.Controls.Add(this.panelHall);
            this.gbPhong.Controls.Add(this.btnPhong_P001);
            this.gbPhong.Controls.Add(this.btnPhong_P002);
            this.gbPhong.Controls.Add(this.btnPhong_P003);
            this.gbPhong.Controls.Add(this.btnPhong_P004);
            this.gbPhong.Controls.Add(this.btnPhong_P005);
            this.gbPhong.Controls.Add(this.btnPhong_P006);
            this.gbPhong.Controls.Add(this.btnPhong_P007);
            this.gbPhong.Controls.Add(this.btnPhong_P008);
            this.gbPhong.Controls.Add(this.btnPhong_P009);
            this.gbPhong.Controls.Add(this.btnPhong_P010);
            this.gbPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.gbPhong.Location = new System.Drawing.Point(220, 80);
            this.gbPhong.Name = "gbPhong";
            this.gbPhong.Size = new System.Drawing.Size(700, 500);
            this.gbPhong.TabIndex = 2;
            this.gbPhong.TabStop = false;
            this.gbPhong.Text = "Sơ đồ dãy phòng";
            // 
            // panelHall
            // 
            this.panelHall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelHall.Controls.Add(this.labelHall);
            this.panelHall.Location = new System.Drawing.Point(50, 215);
            this.panelHall.Name = "panelHall";
            this.panelHall.Size = new System.Drawing.Size(600, 50);
            this.panelHall.TabIndex = 10;
            // 
            // labelHall
            // 
            this.labelHall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHall.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.labelHall.ForeColor = System.Drawing.Color.DimGray;
            this.labelHall.Location = new System.Drawing.Point(0, 0);
            this.labelHall.Name = "labelHall";
            this.labelHall.Size = new System.Drawing.Size(600, 50);
            this.labelHall.TabIndex = 0;
            this.labelHall.Text = "Hành lang";
            this.labelHall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPhong_P001
            // 
            this.btnPhong_P001.BackColor = System.Drawing.Color.White;
            this.btnPhong_P001.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P001.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P001.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P001.Location = new System.Drawing.Point(50, 80);
            this.btnPhong_P001.Name = "btnPhong_P001";
            this.btnPhong_P001.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P001.TabIndex = 11;
            this.btnPhong_P001.Text = "Phòng 1";
            this.btnPhong_P001.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P002
            // 
            this.btnPhong_P002.BackColor = System.Drawing.Color.White;
            this.btnPhong_P002.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P002.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P002.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P002.Location = new System.Drawing.Point(170, 80);
            this.btnPhong_P002.Name = "btnPhong_P002";
            this.btnPhong_P002.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P002.TabIndex = 12;
            this.btnPhong_P002.Text = "Phòng 2";
            this.btnPhong_P002.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P003
            // 
            this.btnPhong_P003.BackColor = System.Drawing.Color.White;
            this.btnPhong_P003.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P003.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P003.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P003.Location = new System.Drawing.Point(290, 80);
            this.btnPhong_P003.Name = "btnPhong_P003";
            this.btnPhong_P003.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P003.TabIndex = 13;
            this.btnPhong_P003.Text = "Phòng 3";
            this.btnPhong_P003.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P004
            // 
            this.btnPhong_P004.BackColor = System.Drawing.Color.White;
            this.btnPhong_P004.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P004.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P004.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P004.Location = new System.Drawing.Point(410, 80);
            this.btnPhong_P004.Name = "btnPhong_P004";
            this.btnPhong_P004.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P004.TabIndex = 14;
            this.btnPhong_P004.Text = "Phòng 4";
            this.btnPhong_P004.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P005
            // 
            this.btnPhong_P005.BackColor = System.Drawing.Color.White;
            this.btnPhong_P005.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P005.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P005.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P005.Location = new System.Drawing.Point(530, 80);
            this.btnPhong_P005.Name = "btnPhong_P005";
            this.btnPhong_P005.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P005.TabIndex = 15;
            this.btnPhong_P005.Text = "Phòng 5";
            this.btnPhong_P005.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P006
            // 
            this.btnPhong_P006.BackColor = System.Drawing.Color.White;
            this.btnPhong_P006.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P006.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P006.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P006.Location = new System.Drawing.Point(54, 333);
            this.btnPhong_P006.Name = "btnPhong_P006";
            this.btnPhong_P006.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P006.TabIndex = 16;
            this.btnPhong_P006.Text = "Phòng 6";
            this.btnPhong_P006.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P007
            // 
            this.btnPhong_P007.BackColor = System.Drawing.Color.White;
            this.btnPhong_P007.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P007.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P007.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P007.Location = new System.Drawing.Point(170, 333);
            this.btnPhong_P007.Name = "btnPhong_P007";
            this.btnPhong_P007.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P007.TabIndex = 17;
            this.btnPhong_P007.Text = "Phòng 7";
            this.btnPhong_P007.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P008
            // 
            this.btnPhong_P008.BackColor = System.Drawing.Color.White;
            this.btnPhong_P008.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P008.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P008.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P008.Location = new System.Drawing.Point(290, 333);
            this.btnPhong_P008.Name = "btnPhong_P008";
            this.btnPhong_P008.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P008.TabIndex = 18;
            this.btnPhong_P008.Text = "Phòng 8";
            this.btnPhong_P008.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P009
            // 
            this.btnPhong_P009.BackColor = System.Drawing.Color.White;
            this.btnPhong_P009.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P009.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P009.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P009.Location = new System.Drawing.Point(410, 333);
            this.btnPhong_P009.Name = "btnPhong_P009";
            this.btnPhong_P009.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P009.TabIndex = 19;
            this.btnPhong_P009.Text = "Phòng 9";
            this.btnPhong_P009.UseVisualStyleBackColor = false;
            // 
            // btnPhong_P010
            // 
            this.btnPhong_P010.BackColor = System.Drawing.Color.White;
            this.btnPhong_P010.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhong_P010.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPhong_P010.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnPhong_P010.Location = new System.Drawing.Point(530, 333);
            this.btnPhong_P010.Name = "btnPhong_P010";
            this.btnPhong_P010.Size = new System.Drawing.Size(100, 60);
            this.btnPhong_P010.TabIndex = 20;
            this.btnPhong_P010.Text = "Phòng 10";
            this.btnPhong_P010.UseVisualStyleBackColor = false;
            // 
            // dgvPhong
            // 
            this.dgvPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(940, 80);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(240, 500);
            this.dgvPhong.TabIndex = 3;
            // 
            // FormPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gbPhong);
            this.Controls.Add(this.dgvPhong);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FormPhong";
            this.Text = "Quản lý Sơ đồ Phòng trọ";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.gbPhong.ResumeLayout(false);
            this.panelHall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox gbPhong;
        private System.Windows.Forms.Panel panelHall;
        private System.Windows.Forms.Label labelHall;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Button btnPhong_P001;
        private System.Windows.Forms.Button btnPhong_P002;
        private System.Windows.Forms.Button btnPhong_P003;
        private System.Windows.Forms.Button btnPhong_P004;
        private System.Windows.Forms.Button btnPhong_P005;
        private System.Windows.Forms.Button btnPhong_P006;
        private System.Windows.Forms.Button btnPhong_P007;
        private System.Windows.Forms.Button btnPhong_P008;
        private System.Windows.Forms.Button btnPhong_P009;
        private System.Windows.Forms.Button btnPhong_P010;
    }
}
