using Guna.UI2.WinForms;
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
    public partial class DangNhap : Form
    {
        private ConnectDB conn;
        public DangNhap()
        {
            InitializeComponent();
            conn = new ConnectDB();
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Uname = txtUser.Text;
            string pass = txtPassword.Text;

            // Kiểm tra các trường có rỗng hay không
            if (Uname.Trim() == "")
            {
                MessageBox.Show("Required enter username!", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pass.Trim() == "")
            {
                MessageBox.Show("Required enter password!", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Gọi hàm VerifyUser để kiểm tra thông tin đăng nhập và lấy mã nhân viên
                string maNV = VerifyUser(Uname, pass);
                if (maNV != null)
                {
                    // Thông báo đăng nhập thành công
                    guna2MessageDialogSuccess.Show();

                    // Chuyển sang trang UserDetails và truyền mã nhân viên
                    this.Hide();
                    HomePage homePage = new HomePage(maNV); // Chuyển mã nhân viên vào HomePage
                    homePage.Show();

                }
                else
                {
                    // Thông báo đăng nhập thất bại
                    MessageBox.Show("Username or password incorrect.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public string VerifyUser(string username, string password)
        {
            string query = $"SELECT MaNV FROM TaiKhoan WHERE TenDangNhap = '{username}' AND MatKhau = '{password}'";
            DataTable result = conn.DocBang(query);

            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["MaNV"].ToString(); // Lấy mã nhân viên
            }

            return null; // Trả về null nếu không tìm thấy
        }


        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private bool isPasswordVisible = false;

        private void opShow_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; // Toggle the state

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '•'; // Hide password
            }
        }


    }

}
