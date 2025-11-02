using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Phong_Tro_DAL.Phong_Tro;
using Font = iTextSharp.text.Font;

namespace Phong_Tro_GUI
{
    public partial class ThongKeDoanhThu : Form
    {
        private Connect db = new Connect();

        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Load tháng
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i);
            cboThang.SelectedIndex = DateTime.Now.Month - 1;

            // Load năm
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear - 3; y <= currentYear; y++)
                cboNam.Items.Add(y);
            cboNam.SelectedItem = currentYear;

            // Load phòng
            cboPhong.Items.Add("Tất cả");
            var listPhong = db.Phongs.Select(p => p.MaPhong).ToList();
            foreach (var p in listPhong)
                cboPhong.Items.Add(p);
            cboPhong.SelectedIndex = 0;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = Convert.ToInt32(cboThang.SelectedItem);
                int nam = Convert.ToInt32(cboNam.SelectedItem);
                string phong = cboPhong.SelectedItem.ToString();

                // Lấy danh sách hóa đơn theo tháng/năm
                var query = from hd in db.HoaDons
                            join hdg in db.HopDongs on hd.MaHopDong equals hdg.MaHopDong
                            where hd.Thang == thang && hd.Nam == nam
                            select new
                            {
                                hd.MaHD,
                                hdg.MaPhong,
                                hd.Thang,
                                hd.Nam,
                                hd.GiaPhong,
                                hd.TienDichVu,
                                hd.TongTien,
                                hd.NgayLap
                            };

                if (phong != "Tất cả")
                    query = query.Where(q => q.MaPhong == phong);

                var list = query.ToList();
                dgvHoaDon.DataSource = list;

                // Hiển thị kết quả
                txtSoHD.Text = list.Count.ToString();
                txtTongTien.Text = string.Format("{0:N0} VNĐ", list.Sum(x => x.TongTien));
                txtTBHoaDon.Text = list.Count > 0
                    ? string.Format("{0:N0} VNĐ", list.Average(x => x.TongTien))
                    : "0 VNĐ";

                // Biểu đồ chart
                chart1.Series.Clear();
                var s = chart1.Series.Add("Doanh thu");
                s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                s.Color = Color.MediumSeaGreen;

                foreach (var item in list)
                {
                    s.Points.AddXY(item.MaPhong, Convert.ToDouble(item.TongTien));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = DateTime.Now.Month - 1;
            cboNam.SelectedItem = DateTime.Now.Year;
            cboPhong.SelectedIndex = 0;
            dgvHoaDon.DataSource = null;
            chart1.Series.Clear();
            txtSoHD.Clear();
            txtTongTien.Clear();
            txtTBHoaDon.Clear();
        }

        // ✅ Xuất Excel
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel file (*.xlsx)|*.xlsx",
                FileName = $"ThongKe_{DateTime.Now:yyyyMMddHHmm}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    var ws = package.Workbook.Worksheets.Add("DoanhThu");
                    ws.Cells["A1"].Value = "BÁO CÁO DOANH THU";
                    ws.Cells["A1"].Style.Font.Size = 16;
                    ws.Cells["A1"].Style.Font.Bold = true;
                    ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["A1:H1"].Merge = true;

                    // Header
                    for (int i = 0; i < dgvHoaDon.Columns.Count; i++)
                    {
                        ws.Cells[3, i + 1].Value = dgvHoaDon.Columns[i].HeaderText;
                        ws.Cells[3, i + 1].Style.Font.Bold = true;
                        ws.Cells[3, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    // Dữ liệu
                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvHoaDon.Columns.Count; j++)
                        {
                            ws.Cells[i + 4, j + 1].Value = dgvHoaDon.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    ws.Cells.AutoFitColumns();
                    File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                }

                MessageBox.Show("Xuất Excel thành công!", "Thông báo");
            }
        }

        // ✅ Xuất PDF
        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = $"ThongKe_{DateTime.Now:yyyyMMddHHmm}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);
                    Font fontTitle = new Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    Font fontNormal = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    Paragraph title = new Paragraph("BÁO CÁO DOANH THU", fontTitle)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(title);
                    pdfDoc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dgvHoaDon.Columns.Count);
                    table.WidthPercentage = 100;

                    // Header
                    foreach (DataGridViewColumn col in dgvHoaDon.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontNormal))
                        {
                            BackgroundColor = new BaseColor(220, 220, 220)
                        };
                        table.AddCell(cell);
                    }

                    // Rows
                    foreach (DataGridViewRow row in dgvHoaDon.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(new Phrase(cell.Value?.ToString() ?? "", fontNormal));
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("Xuất PDF thành công!", "Thông báo");
            }
        }
    }
}
