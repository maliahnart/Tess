using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLC
{
    public partial class HomeReal : Form
    {
        private Timer timerSanPham;
        private Timer timerBanHang;
        bool menuSanPhamExpand = false;
        bool menuBanHangExpand = false;

        public HomeReal()
        {
            InitializeComponent();

            // Khởi tạo các Timer
            timerSanPham = new Timer();
            timerBanHang = new Timer();

            // Thiết lập thời gian Interval cho mỗi Timer
            timerSanPham.Interval = 10;
            timerBanHang.Interval = 10;

            // Đăng ký sự kiện Tick cho mỗi Timer
            timerSanPham.Tick += new EventHandler(timerSanPham_Tick);
            timerBanHang.Tick += new EventHandler(timerBanHang_Tick);
        }

        private void HomeReal_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();
            menuSanPhamExpand = false;
            menuBanHangExpand = false;
        }

        private void timerSanPham_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 5;

            if (!menuSanPhamExpand)
            {
                // Mở rộng MenuContainer1
                if (MenuContainer.Height < 250)
                {
                    MenuContainer.Height += expandSpeed;
                    if (MenuContainer.Height >= 250)
                    {
                        timerSanPham.Stop();
                        menuSanPhamExpand = true;
                    }
                }
            }
            else
            {
                // Thu gọn MenuContainer1
                if (MenuContainer.Height > 60)
                {
                    MenuContainer.Height -= expandSpeed;
                    if (MenuContainer.Height <= 60)
                    {
                        timerSanPham.Stop();
                        menuSanPhamExpand = false;
                    }
                }
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            timerSanPham.Start();
        }

        private void timerBanHang_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 10;

            if (!menuBanHangExpand)
            {
                // Mở rộng MenuContainer2
                if (MenuContainer2.Height < 203)
                {
                    MenuContainer2.Height += expandSpeed;
                    if (MenuContainer2.Height >= 203)
                    {
                        timerBanHang.Stop();
                        menuBanHangExpand = true;
                    }
                }
            }
            else
            {
                // Thu gọn MenuContainer2
                if (MenuContainer2.Height > 60)
                {
                    MenuContainer2.Height -= expandSpeed;
                    if (MenuContainer2.Height <= 60)
                    {
                        timerBanHang.Stop();
                        menuBanHangExpand = false;
                    }
                }
            }
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            timerBanHang.Start();
        }
    }
}
