using System;
using System.Windows.Forms;

namespace Phong_Tro_GUI.ConTrol
{
    public partial class UC_HoaDon : UserControl
    {
        private bool sidebarExpand = true;

        public UC_HoaDon()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                panelMenu.Width -= 10;
                if (panelMenu.Width <= 60)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                panelMenu.Width += 10;
                if (panelMenu.Width >= 200)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

      
    }
}
