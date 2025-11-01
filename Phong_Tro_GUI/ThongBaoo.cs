using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phong_Tro_BUS.Shared;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class ThongBaoo : Form
    {
        private readonly ThongBaoDB tbBUS = new ThongBaoDB();
        private List<ThongBao> danhSachThongBao = new List<ThongBao>();

        public ThongBaoo()
        {
            InitializeComponent();
        }

        private void ThongBaoo_Load(object sender, EventArgs e)
        {
            LoadThongBao();
        }

        // 🩵 Load danh sách thông báo vào DataGridView
        private void LoadThongBao()
        {
            try
            {
                danhSachThongBao = tbBUS.GetAll();
                dgvThongBao.DataSource = danhSachThongBao
                    .Select(tb => new
                    {
                        tb.MaTB,
                        tb.NoiDung,
                        tb.NgayTao,
                        tb.MaPhong,
                        tb.MaHopDong
                    }).ToList();

                dgvThongBao.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông báo: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🩵 Khi click vào 1 dòng trong bảng → hiện nội dung chi tiết
        private void dgvThongBao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvThongBao.Rows.Count)
            {
                var row = dgvThongBao.Rows[e.RowIndex];
                txtTieuDe.Text = row.Cells["NoiDung"].Value?.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                dtNgayGui.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value ?? DateTime.Now);
            }
        }

        // 🩵 Gửi thông báo mới
        private void btnGui_Click(object sender, EventArgs e)
        {
            string noiDung = txtNoiDung.Text.Trim();
            if (string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập nội dung thông báo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                tbBUS.Add(noiDung);
                MessageBox.Show("Gửi thông báo thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThongBao();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi thông báo: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🩵 Sửa thông báo
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thông báo cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTB"].Value);
            var tb = tbBUS.GetById(maTB);

            if (tb != null)
            {
                tb.NoiDung = txtNoiDung.Text.Trim();
                tb.NgayTao = dtNgayGui.Value;

                tbBUS.Update(tb);
                MessageBox.Show("Cập nhật thông báo thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadThongBao();
            }
        }

        // 🩵 Xóa thông báo
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongBao.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thông báo cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maTB = Convert.ToInt32(dgvThongBao.CurrentRow.Cells["MaTB"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa thông báo này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tbBUS.Delete(maTB);
                LoadThongBao();
                LamMoiForm();
            }
        }

        // 🩵 Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void LamMoiForm()
        {
            txtTieuDe.Clear();
            txtNoiDung.Clear();
            dtNgayGui.Value = DateTime.Now;
            dgvThongBao.ClearSelection();
        }

        // 🩵 Đánh dấu là "Đã đọc"
        private void btnDaDoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thông báo đã được đánh dấu là đã đọc (demo).",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
