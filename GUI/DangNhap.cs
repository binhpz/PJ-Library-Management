using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangNhap : Form
    {
        DangNhapBus dangNhapbus = new DangNhapBus{ };
        public DangNhap()
        {
           
            InitializeComponent(); 

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
        ;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitBt_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text;
            var pass = this.passwordTextBox.Text;
            if (username == "" || pass == "")
            {
                MessageBox.Show("Yêu cầu nhập tài khoản và mật khẩu!");
            }
            else if (!dangNhapbus.Login(username, pass))
            {
                MessageBox.Show("Sai thông tin đăng nhập!");
            }
            else
            {
                this.Hide();
                var menu = new Menu();
                menu.StartPosition = FormStartPosition.Manual;
                menu.Location = this.Location;
                menu.Size = this.Size;
                menu.Show();
            }

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
