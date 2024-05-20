using HTQLSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{


    public partial class Login : Form
    {
        HTQLSVEntities db = new HTQLSVEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text == "" || txbPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            var user = db.Accounts.Where(s => s.UserName == txbUserName.Text).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == txbPassword.Text)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.Hide();
                    DashBoard view = new DashBoard();
                    view.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại");
            }
        }
    }
}
