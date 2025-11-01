using System;
using System.Windows.Forms;

namespace Phong_Tro_GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Text = "🏡 Quản lý phòng trọ";
            this.WindowState = FormWindowState.Maximized;
        }

        // Phương thức load control động
        public void LoadControl(UserControl control)
        {
            panelMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelMain.Controls.Add(control);
        }
    }
}
