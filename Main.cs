using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTLC
{
    public partial class Main : Form
    {
        private Timer timerSanPham;
        private Timer timerBanHang;
        private bool menuSanPhamExpand = false;
        private bool menuBanHangExpand = false;

        public Main()
        {
            InitializeComponent();
            timerSanPham = new Timer();
            timerSanPham.Interval = 10;
            timerBanHang = new Timer();
            timerBanHang.Interval = 10;
            timerSanPham.Tick += new EventHandler(timerSanPham_Tick);
            timerBanHang.Tick += new EventHandler(timerBanHang_Tick);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MenuContainer.Height = 40; 
            menuC.Height = 40; 
            menuSanPhamExpand = false;
            menuBanHangExpand = false;
        }

        private void timerSanPham_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 5;
            int menuExpandedHeight = 160;
            int menuCollapsedHeight = 40;

            if (!menuSanPhamExpand)
            {
                if (MenuContainer.Height < menuExpandedHeight)
                {
                    MenuContainer.Height += expandSpeed;
                    if (MenuContainer.Height >= menuExpandedHeight)
                    {
                        MenuContainer.Height = menuExpandedHeight;
                        timerSanPham.Stop();
                        menuSanPhamExpand = true;
                        MoveButtons1(120);
                    }
                }
            }
            else
            {
                // Thu gọn menu sản phẩm
                if (MenuContainer.Height > menuCollapsedHeight)
                {
                    MenuContainer.Height -= expandSpeed;
                    if (MenuContainer.Height <= menuCollapsedHeight)
                    {
                        MenuContainer.Height = menuCollapsedHeight;
                        timerSanPham.Stop();
                        menuSanPhamExpand = false;
                        MoveButtons1(-120);
                    }
                }
            }
        }

        private void timerBanHang_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 5;
            int menuExpandedHeight = 120;
            int menuCollapsedHeight = 40;

            if (!menuBanHangExpand)
            {
                if (menuC.Height < menuExpandedHeight)
                {
                    menuC.Height += expandSpeed;
                    if (menuC.Height >= menuExpandedHeight)
                    {
                        menuC.Height = menuExpandedHeight;
                        timerBanHang.Stop();
                        menuBanHangExpand = true;
                        MoveButtons(90);
                    }
                }
            }
            else
            {
                if (menuC.Height > menuCollapsedHeight)
                {
                    menuC.Height -= expandSpeed;
                    if (menuC.Height <= menuCollapsedHeight)
                    {
                        menuC.Height = menuCollapsedHeight;
                        timerBanHang.Stop();
                        menuBanHangExpand = false;
                        MoveButtons(-90);
                    }
                }
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            timerSanPham.Start();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            timerBanHang.Start();
        }

        private void MoveButtons(int offsetY)
        {
            btnKhachhang.Location = new Point(btnKhachhang.Location.X, btnKhachhang.Location.Y + offsetY);
            btnNhanSu.Location = new Point(btnNhanSu.Location.X, btnNhanSu.Location.Y + offsetY);
            btnNCC.Location = new Point(btnNCC.Location.X, btnNCC.Location.Y + offsetY);
            btnThongKe.Location = new Point(btnThongKe.Location.X, btnThongKe.Location.Y + offsetY);
            picKH.Location = new Point(picKH.Location.X, picKH.Location.Y + offsetY);
            picNS.Location = new Point(picNS.Location.X, picNS.Location.Y + offsetY);
            picNCC.Location = new Point(picNCC.Location.X, picNCC.Location.Y + offsetY);
            picTK.Location = new Point(picTK.Location.X, picTK.Location.Y + offsetY);
            picLogout.Location = new Point(picLogout.Location.X, picLogout.Location.Y + offsetY);
        }
        private void MoveButtons1(int offsetY)
        {
            menuC.Location = new Point(menuC.Location.X, menuC.Location.Y + offsetY);
            btnKhachhang.Location = new Point(btnKhachhang.Location.X, btnKhachhang.Location.Y + offsetY);
            btnNhanSu.Location = new Point(btnNhanSu.Location.X, btnNhanSu.Location.Y + offsetY);
            btnNCC.Location = new Point(btnNCC.Location.X, btnNCC.Location.Y + offsetY);
            btnThongKe.Location = new Point(btnThongKe.Location.X, btnThongKe.Location.Y + offsetY);
            picKH.Location = new Point(picKH.Location.X, picKH.Location.Y + offsetY);
            picNS.Location = new Point(picNS.Location.X, picNS.Location.Y + offsetY);
            picNCC.Location = new Point(picNCC.Location.X, picNCC.Location.Y + offsetY);
            picTK.Location = new Point(picTK.Location.X, picTK.Location.Y + offsetY);
            picLogout.Location = new Point(picLogout.Location.X, picLogout.Location.Y + offsetY);
        }
    }
}
