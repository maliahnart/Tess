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
    public partial class UserDetails : Form
    {
        private string maNV;
        private ConnectDB conn;

        public UserDetails(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            conn = new ConnectDB();
            LoadUserInfo(maNV);
        }

        private void LoadUserInfo(string maNV)
        {
            string query = $"SELECT NhanVien.*, TaiKhoan.* FROM NhanVien JOIN TaiKhoan ON NhanVien.MaNV = TaiKhoan.MaNV WHERE NhanVien.MaNV = '{maNV}'";
            DataTable result = conn.DocBang(query);

            if (result.Rows.Count > 0)
            {

                lblHoten.Text = $"Họ và tên: {result.Rows[0]["TenNV"]}";
                lblCV.Text = $"Công việc: {result.Rows[0]["QuyenHan"]}";
                lblMa.Text = $"Mã nhân viên: {result.Rows[0]["MaNV"]}";
                lblCa.Text = $"Ngày tuyển: {Convert.ToDateTime(result.Rows[0]["NgayTuyen"]).ToShortDateString()}";
                lblNgaySinh.Text = $"Ngày sinh: {Convert.ToDateTime(result.Rows[0]["NgaySinh"]).ToShortDateString()}";
                lblSdt.Text = $"Số điện thoại: {result.Rows[0]["DienThoai"]}";
                lblDiaChi.Text = $"Địa chỉ: {result.Rows[0]["DiaChi"]}";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}



