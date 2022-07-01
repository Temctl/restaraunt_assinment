using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biyDaalt
{
    public partial class signup : Form
    {
        bool custom = false;
        public signup()
        {
            InitializeComponent();
        }
        public signup(bool custom_user)
        {
            custom = custom_user;
            InitializeComponent();
        }

        public void submit_clicked(object sender, EventArgs e)
        {
            if (custom)
            {
                config.FirstName = this.textBox1.Text;
                config.LastName = this.textBox2.Text;
                config.Email = this.textBox3.Text;
                config.PhoneNumber = this.textBox4.Text;
                config.Address = this.textBox5.Text;
                config.Password = "";
                config.signup();
                this.Dispose();
            }
            else
            {
                NewPassword password = new NewPassword(getInfo());
                password.ShowDialog();
                this.Dispose();
            }
        }

        private List<string> getInfo()
        {
            List<string> list = new List<string>();
            list.Add(this.textBox1.Text);
            list.Add(this.textBox2.Text);
            list.Add(this.textBox3.Text);
            list.Add(this.textBox4.Text);
            list.Add(this.textBox5.Text);
            return list;
        }

        public void erase()
        {
            this.Dispose();
        }


    }
}
