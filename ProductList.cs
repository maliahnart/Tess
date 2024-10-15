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
    public partial class ProductList : Form
    {
        private string maNV;

        private ConnectDB conn;

        public ProductList(string maNV)
        {
            InitializeComponent();
            conn = new ConnectDB();
            this.maNV = maNV;

        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            DataTable dataTable = conn.DocBang("SELECT TenHang, SoLuong, DonGiaBan, GhiChu FROM HangHoa");
            dtDanhSach.DataSource = dataTable;
            if (dtDanhSach.Columns.Contains("ChiTiet"))
            {
                dtDanhSach.Columns["ChiTiet"].Visible = true;
            }
            if (dtDanhSach.Columns.Contains("Sua"))
            {
                dtDanhSach.Columns["Sua"].Visible = true;
            }
            if (dtDanhSach.Columns.Contains("Xoa"))
            {
                dtDanhSach.Columns["Xoa"].Visible = true;
            }
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtDanhSach.Rows.Count; i++)
                {
                    dtDanhSach.Rows[i].Cells[0].Value = i + 1;
                }
            }
            dtDanhSach.AllowUserToAddRows = false;
            
        }

        private void picdetail_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDetails userDetailsForm = new UserDetails(maNV);
            userDetailsForm.ShowDialog();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage(maNV);
            homePage.ShowDialog();
        }
    }
}

