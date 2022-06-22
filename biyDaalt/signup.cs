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
        public signup()
        {
            InitializeComponent();
        }

        public void submit_clicked(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(this.textBox1.Text);
            list.Add(this.textBox2.Text);
            list.Add(this.textBox3.Text);
            list.Add(this.textBox4.Text);
            list.Add(this.textBox5.Text);
            NewPassword password = new NewPassword(list);
            password.ShowDialog();
            this.Dispose();
        }

        
    }
}
