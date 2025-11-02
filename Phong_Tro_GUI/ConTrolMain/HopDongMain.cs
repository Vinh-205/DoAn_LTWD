using System;
using System.Windows.Forms;
using Phong_Tro_BUS;
using Phong_Tro_DAL.Phong_Tro;

namespace Phong_Tro_GUI
{
    public partial class HopDongMain : Form
    {
        private HopDongBUS bus = new HopDongBUS();

        public HopDongMain()
        {
            InitializeComponent();
        }
    }
}
