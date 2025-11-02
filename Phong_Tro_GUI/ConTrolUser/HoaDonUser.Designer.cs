namespace Phong_Tro_GUI.ConTrolUser
{
    partial class HoaDonUser
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel searchPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();

            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Size = new System.Drawing.Size(928, 60);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Text = "📄 DANH SÁCH HÓA ĐƠN CỦA BẠN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // searchPanel
            this.searchPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.searchPanel.Controls.Add(this.lblTimKiem);
            this.searchPanel.Controls.Add(this.txtTimKiem);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.searchPanel.Size = new System.Drawing.Size(928, 60);

            // lblTimKiem
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Location = new System.Drawing.Point(27, 18);
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Text = "🔍 Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)
                | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(130, 15);
            this.txtTimKiem.Size = new System.Drawing.Size(770, 30);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // dgvHoaDon
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.GridColor = System.Drawing.Color.LightGray;

            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvHoaDon.ColumnHeadersHeight = 35;

            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.RowsDefaultCellStyle = dgvRowStyle;

            this.dgvHoaDon.Location = new System.Drawing.Point(27, 135);
            this.dgvHoaDon.Size = new System.Drawing.Size(873, 320);

            // HoaDonUser (UserControl)
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.Size = new System.Drawing.Size(928, 480);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
