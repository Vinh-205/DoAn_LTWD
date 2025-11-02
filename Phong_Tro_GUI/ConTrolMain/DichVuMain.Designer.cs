using System.Windows.Forms;
using System.Drawing;

namespace Phong_Tro_GUI
{
    partial class DichVuMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.labelTitle = new Label();
            this.panelMenu = new Panel();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnLamMoi = new Button();
            this.txtTimKiem = new TextBox();
            this.btnTimKiem = new Button();
            this.gbThongTin = new GroupBox();
            this.label1 = new Label();
            this.txtMaDV = new TextBox();
            this.label2 = new Label();
            this.txtTenDV = new TextBox();
            this.label3 = new Label();
            this.txtDonGia = new TextBox();
            this.label4 = new Label();
            this.txtDonViTinh = new TextBox();
            this.label5 = new Label();
            this.txtGhiChu = new TextBox();
            this.dgvDichVu = new DataGridView();
            this.MaDV = new DataGridViewTextBoxColumn();
            this.TenDV = new DataGridViewTextBoxColumn();
            this.DonGia = new DataGridViewTextBoxColumn();
            this.MoTa = new DataGridViewTextBoxColumn();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(178, 224, 210);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Location = new Point(200, 0);
            this.panelHeader.Size = new Size(1000, 60);

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.labelTitle.ForeColor = Color.FromArgb(40, 55, 71);
            this.labelTitle.Location = new Point(20, 15);
            this.labelTitle.Text = "QUẢN LÝ DỊCH VỤ";

            // panelMenu
            this.panelMenu.BackColor = Color.FromArgb(230, 240, 235);
            this.panelMenu.Controls.Add(this.btnThem);
            this.panelMenu.Controls.Add(this.btnSua);
            this.panelMenu.Controls.Add(this.btnXoa);
            this.panelMenu.Controls.Add(this.btnLamMoi);
            this.panelMenu.Controls.Add(this.txtTimKiem);
            this.panelMenu.Controls.Add(this.btnTimKiem);
            this.panelMenu.Location = new Point(0, 0);
            this.panelMenu.Size = new Size(200, 700);

            // btnThem
            this.btnThem.BackColor = Color.Teal;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(35, 40);
            this.btnThem.Size = new Size(130, 40);
            this.btnThem.Text = "➕ Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.BackColor = Color.SteelBlue;
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.ForeColor = Color.White;
            this.btnSua.Location = new Point(35, 90);
            this.btnSua.Size = new Size(130, 40);
            this.btnSua.Text = "✏️ Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.BackColor = Color.Firebrick;
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Location = new Point(35, 140);
            this.btnXoa.Size = new Size(130, 40);
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi
            this.btnLamMoi.BackColor = Color.DarkGray;
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.Location = new Point(35, 190);
            this.btnLamMoi.Size = new Size(130, 40);
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // txtTimKiem
            this.txtTimKiem.Location = new Point(20, 260);
            this.txtTimKiem.Size = new Size(160, 27);
            this.txtTimKiem.Text = "Nhập tên dịch vụ...";

            // btnTimKiem
            this.btnTimKiem.BackColor = Color.White;
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.ForeColor = Color.MediumSlateBlue;
            this.btnTimKiem.Location = new Point(35, 300);
            this.btnTimKiem.Size = new Size(130, 40);
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // gbThongTin
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Controls.Add(this.txtMaDV);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.txtTenDV);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.txtDonGia);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.txtDonViTinh);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.txtGhiChu);
            this.gbThongTin.Font = new Font("Segoe UI", 10F);
            this.gbThongTin.Location = new Point(220, 80);
            this.gbThongTin.Size = new Size(960, 200);
            this.gbThongTin.Text = "Thông tin dịch vụ";

            // label1
            this.label1.Location = new Point(30, 40);
            this.label1.Size = new Size(100, 23);
            this.label1.Text = "Mã DV:";
            // txtMaDV
            this.txtMaDV.Location = new Point(150, 38);
            this.txtMaDV.Size = new Size(200, 30);

            // label2
            this.label2.Location = new Point(400, 40);
            this.label2.Size = new Size(100, 23);
            this.label2.Text = "Tên DV:";
            // txtTenDV
            this.txtTenDV.Location = new Point(520, 38);
            this.txtTenDV.Size = new Size(300, 30);

            // label3
            this.label3.Location = new Point(30, 80);
            this.label3.Size = new Size(100, 23);
            this.label3.Text = "Đơn giá:";
            // txtDonGia
            this.txtDonGia.Location = new Point(150, 78);
            this.txtDonGia.Size = new Size(200, 30);

            // label4
            this.label4.Location = new Point(400, 80);
            this.label4.Size = new Size(100, 23);
            this.label4.Text = "Đơn vị tính:";
            // txtDonViTinh
            this.txtDonViTinh.Location = new Point(520, 78);
            this.txtDonViTinh.Size = new Size(200, 30);

            // label5
            this.label5.Location = new Point(30, 120);
            this.label5.Size = new Size(100, 23);
            this.label5.Text = "Ghi chú:";
            // txtGhiChu
            this.txtGhiChu.Location = new Point(150, 118);
            this.txtGhiChu.Size = new Size(670, 30);

            // dgvDichVu
            this.dgvDichVu.BackgroundColor = Color.White;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Location = new Point(220, 286);
            this.dgvDichVu.Size = new Size(960, 402);
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.CellClick += new DataGridViewCellEventHandler(this.dgvDichVu_CellClick);

            // Add columns
            this.dgvDichVu.Columns.AddRange(new DataGridViewColumn[] {
                this.MaDV,
                this.TenDV,
                this.DonGia,
                this.MoTa
            });

            // MaDV
            this.MaDV.HeaderText = "Mã DV";
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.Width = 150;

            // TenDV
            this.TenDV.HeaderText = "Tên DV";
            this.TenDV.DataPropertyName = "TenDV";
            this.TenDV.Width = 300;

            // DonGia
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.Width = 150;

            // MoTa
            this.MoTa.HeaderText = "Ghi chú";
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.Width = 350;

            // UC_DichVu
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.dgvDichVu);
            this.Size = new Size(1200, 700);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelMenu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private GroupBox gbThongTin;
        private Label label1;
        private TextBox txtMaDV;
        private Label label2;
        private TextBox txtTenDV;
        private Label label3;
        private TextBox txtDonGia;
        private Label label4;
        private TextBox txtDonViTinh;
        private Label label5;
        private TextBox txtGhiChu;
        private DataGridView dgvDichVu;
        private DataGridViewTextBoxColumn MaDV;
        private DataGridViewTextBoxColumn TenDV;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn MoTa;
    }
}
