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
    public partial class HomePage : Form
    {
        private ConnectDB conn;
        public HomePage()
        {
            InitializeComponent();
            conn = new ConnectDB();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            LoadCustomer();
            LoadProduct();
            LoadStored();
            LoadRevenue();
        }
        private void LoadEmployeeData()
        {
            string totalQuery = "SELECT COUNT(*) AS Bang1 FROM TaiKhoan ";
            DataTable totalResult = conn.DocBang(totalQuery);
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo.Text = $"Tổng số: {totalResult.Rows[0]["Bang1"]}";
            }
            string positionQuery = "SELECT QuyenHan, COUNT(*) AS Count FROM TaiKhoan GROUP BY QuyenHan";
            DataTable positionResult = conn.DocBang(positionQuery);
            int managers = 0;
            int staff = 0;
            foreach (DataRow row in positionResult.Rows)
            {
                string position = row["QuyenHan"].ToString();
                int count = Convert.ToInt32(row["Count"]);

                if (position == "Admin")
                {
                    managers = count;
                }
                else if (position == "NhanVien")
                {
                    staff = count;
                }
            }
            lblQuanLy.Text = $"Quản lý: {managers}";
            lblNhanVien.Text = $"Nhân viên: {staff}";
        }
        private void LoadCustomer()
        {
            string totalQuery = "SELECT COUNT(*) AS Bang2 FROM KhachHang";
            DataTable totalResult = conn.DocBang(totalQuery);
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo2.Text = $"Tổng số: {totalResult.Rows[0]["Bang2"]}";
            }
        }
        private void LoadProduct()
        {
            string totalQuery = "SELECT SUM(SoLuong) AS Bang3 FROM ChiTietHoaDonBan";
            DataTable totalResult = conn.DocBang(totalQuery);
            if (totalResult.Rows.Count > 0)
            {
                lblTongSo3.Text = $"Tổng số: {totalResult.Rows[0]["Bang3"]}";
            }
            string totalKH = "SELECT Count(MaKhach) AS Bang4 FROM HoaDonBan";
            DataTable totalResult1 = conn.DocBang(totalKH);
            if (totalResult1.Rows.Count > 0)
            {
                lblKH.Text = $"Số lượng KH: {totalResult1.Rows[0]["Bang4"]}";
            }
        }
        private void LoadStored()
        {
            string totalQuery = "SELECT Count(MaHang) AS Bang3 FROM HangHoa";
            DataTable totalResult = conn.DocBang(totalQuery);
            if (totalResult.Rows.Count > 0)
            {
                lblSP.Text = $"SL sản phẩm: {totalResult.Rows[0]["Bang3"]}";
            }
            string totalKH = "SELECT SUM(SoLuong) AS Bang3 FROM HangHoa";
            DataTable totalResult1 = conn.DocBang(totalKH);
            if (totalResult1.Rows.Count > 0)
            {
                lblTK.Text = $"SL tồn kho: {totalResult1.Rows[0]["Bang3"]}";
            }
            string totalN = "SELECT SUM(SoLuong) AS Bang4 FROM ChiTietHoaDonNhap";
            DataTable totalResult2 = conn.DocBang(totalN);
            if (totalResult2.Rows.Count > 0)
            {
                lblN.Text = $"SL nhập: {totalResult2.Rows[0]["Bang4"]}";
            }
        }
        private void LoadRevenue()
        {
            string totalQuery = "SELECT SUM(TongTien) AS Bang3 FROM HoaDonBan";
            DataTable totalResult = conn.DocBang(totalQuery);
            if (totalResult.Rows.Count > 0)
            {
                lblDT.Text = $"Doanh thu: {totalResult.Rows[0]["Bang3"]}";
            }
            string totalKH = "SELECT SUM(GiamGia) AS Bang3 FROM HoaDonBan";
            DataTable totalResult1 = conn.DocBang(totalKH);
            if (totalResult1.Rows.Count > 0)
            {
                lblGG.Text = $"Giảm giá: {totalResult1.Rows[0]["Bang3"]}";
            }
        }



    }
}
