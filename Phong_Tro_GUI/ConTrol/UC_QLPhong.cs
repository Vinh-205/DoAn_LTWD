using Phong_Tro_DAL.Phong_Tro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Phong_Tro
{
    public partial class UC_Phong : UserControl
    {
    //    // Danh sách nút phòng
    //    private List<Button> roomButtons = new List<Button>();
    //    private int numberOfRooms = 10; // Số phòng hiện có

    //    public UC_Phong()
    //    {
    //        InitializeComponent();
    //        InitializeRoomButtons();
    //    }

    //    private void InitializeRoomButtons()
    //    {
    //        // Xóa các nút hiện tại trong GroupBox (nếu có)
    //        gbPhong.Controls.Clear();

    //        // Thêm hành lang
    //        panelHall = new Panel
    //        {
    //            BackColor = Color.Gainsboro,
    //            Size = new Size(580, 50),
    //            Location = new Point(50, 167)
    //        };
    //        labelHall = new Label
    //        {
    //            Dock = DockStyle.Fill,
    //            Font = new Font("Segoe UI", 10, FontStyle.Italic),
    //            ForeColor = Color.DimGray,
    //            Text = "Hành lang",
    //            TextAlign = ContentAlignment.MiddleCenter
    //        };
    //        panelHall.Controls.Add(labelHall);
    //        gbPhong.Controls.Add(panelHall);

    //        // Tạo các nút phòng
    //        int xStart = 50;
    //        int yStartTop = 40;
    //        int yStartBottom = 285;
    //        int btnWidth = 100;
    //        int btnHeight = 60;
    //        int gap = 20;

    //        for (int i = 0; i < numberOfRooms; i++)
    //        {
    //            Button btn = new Button
    //            {
    //                Size = new Size(btnWidth, btnHeight),
    //                FlatStyle = FlatStyle.Flat,
    //                BackColor = Color.White,
    //                ForeColor = Color.FromArgb(40, 55, 71),
    //                Font = new Font("Segoe UI", 9),
    //                Text = $"Phòng {i + 1}",
    //            };

    //            // Xác định vị trí
    //            int row = (i < numberOfRooms / 2) ? 0 : 1;
    //            int col = (i < numberOfRooms / 2) ? i : i - numberOfRooms / 2;
    //            int x = xStart + col * (btnWidth + gap);
    //            int y = (row == 0) ? yStartTop : yStartBottom;
    //            btn.Location = new Point(x, y);

    //            // Thêm sự kiện click
    //            btn.Click += RoomButton_Click;

    //            gbPhong.Controls.Add(btn);
    //            roomButtons.Add(btn);
    //        }
    //    }

    //    // Sự kiện click chung cho các phòng
    //    private void RoomButton_Click(object sender, EventArgs e)
    //    {
    //        Button clickedRoom = sender as Button;
    //        MessageBox.Show($"Bạn đã chọn {clickedRoom.Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //    }

    //    // Hàm load dữ liệu vào DataGridView
    //    public void LoadRoomData(List<PhongInfo> rooms)
    //    {
    //        dgvPhong.DataSource = null;
    //        dgvPhong.DataSource = rooms;
    //    }

    //    // Thay đổi trạng thái phòng (ví dụ: trống / đã thuê)
    //    public void UpdateRoomStatus(int roomIndex, bool isOccupied)
    //    {
    //        if (roomIndex < 0 || roomIndex >= roomButtons.Count) return;

    //        roomButtons[roomIndex].BackColor = isOccupied ? Color.LightCoral : Color.LightGreen;
    //    }
    //}

    //// Class mô tả thông tin phòng
    //public class PhongInfo
    //{
    //    public string MaPhong { get; set; }
    //    public string TenPhong { get; set; }
    //    public string TrangThai { get; set; } // Trống / Đã thuê
    }
}
