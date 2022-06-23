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
    public partial class welcomePage : Form
    {
        public welcomePage()
        {
            InitializeComponent();
            statusChanged();
        }

        public void statusChanged()
        {
            if (config.logged)
            {
                this.button1.Text = "Switch Account";
                this.button5.Hide();
            }
            else
            {
                this.richTextBox4.Hide();
                this.button4.Hide();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void login(object sender, EventArgs e)
        {
            login login = new login();
            login.ShowDialog();
        }
    }
}
