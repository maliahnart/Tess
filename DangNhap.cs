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
                // Gọi hàm VerifyUser để kiểm tra thông tin đăng nhập
                if (VerifyUser(Uname,pass))
                {
                    // Thông báo đăng nhập thành công
                    MessageBox.Show("Log in successfully!", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Chuyển sang trang HomePage
                    this.Hide();
                    Main frm = new Main();
                    frm.Show();
                }
                else
                {
                    // Thông báo đăng nhập thất bại
                    MessageBox.Show("Username or password incorrect.", "Announce", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool VerifyUser(string username, string password)
        {
            string query = $"SELECT * FROM TaiKhoan WHERE TenDangNhap = '{username}' AND MatKhau = '{password}'";
            DataTable result = conn.DocBang(query);
            return result.Rows.Count > 0;
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
