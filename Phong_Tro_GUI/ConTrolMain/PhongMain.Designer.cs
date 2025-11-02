namespace Phong_Tro_GUI.ConTrol
{
    partial class PhongMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSoDoPhong;
        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.GroupBox gbSoDo;
        private System.Windows.Forms.GroupBox gbDoanhThu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSoDoPhong = new System.Windows.Forms.Panel();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.gbSoDo = new System.Windows.Forms.GroupBox();
            this.gbDoanhThu = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.gbSoDo.SuspendLayout();
            this.gbDoanhThu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSoDo
            // 
            this.gbSoDo.Controls.Add(this.pnlSoDoPhong);
            this.gbSoDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbSoDo.Location = new System.Drawing.Point(20, 20);
            this.gbSoDo.Name = "gbSoDo";
            this.gbSoDo.Size = new System.Drawing.Size(700, 350);
            this.gbSoDo.TabIndex = 0;
            this.gbSoDo.TabStop = false;
            this.gbSoDo.Text = "Sơ đồ phòng";
            // 
            // pnlSoDoPhong
            // 
            this.pnlSoDoPhong.AutoScroll = true;
            this.pnlSoDoPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoDoPhong.Location = new System.Drawing.Point(3, 23);
            this.pnlSoDoPhong.Name = "pnlSoDoPhong";
            this.pnlSoDoPhong.Size = new System.Drawing.Size(694, 324);
            this.pnlSoDoPhong.TabIndex = 0;
            // 
            // gbDoanhThu
            // 
            this.gbDoanhThu.Controls.Add(this.lblTongDoanhThu);
            this.gbDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.gbDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gbDoanhThu.Location = new System.Drawing.Point(740, 20);
            this.gbDoanhThu.Name = "gbDoanhThu";
            this.gbDoanhThu.Size = new System.Drawing.Size(400, 350);
            this.gbDoanhThu.TabIndex = 1;
            this.gbDoanhThu.TabStop = false;
            this.gbDoanhThu.Text = "Doanh thu tháng hiện tại";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(20, 40);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersVisible = false;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(360, 250);
            this.dgvDoanhThu.TabIndex = 0;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(20, 305);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(170, 23);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: 0";
            // 
            // UC_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDoanhThu);
            this.Controls.Add(this.gbSoDo);
            this.Name = "UC_TrangChu";
            this.Size = new System.Drawing.Size(1170, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.gbSoDo.ResumeLayout(false);
            this.gbDoanhThu.ResumeLayout(false);
            this.gbDoanhThu.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
