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
    public partial class NewPassword : Form
    {   
        List<string> info = new List<string>();
        public NewPassword()
        {
            InitializeComponent();
        }
        public NewPassword(List<string> list)
        {
            info = list;
            InitializeComponent();
        }

        public void submitClicked(object sender, EventArgs e)
        {
            if (checkPassword())
            {
                info.Add(this.textBox1.Text);
                config.setEverything(info);
            }
            else
            {
                this.label3.Text = "The password does not match.";
            }
        }
        private bool checkPassword()
        {
            if(this.textBox1.Text == this.textBox2.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
