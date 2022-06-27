using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace biyDaalt
{
    public partial class welcomePage : Form
    {
        public welcomePage()
        {
            InitializeComponent();
            statusChanged();
        }
        public welcomePage(List<String> row1, List<String> row2, List<String> row3)
        {
            InitializeComponent();
            statusChanged();
            //each row has the needed info
        }


        public static void statusChanged()
        {
            if (config.logged)
            {
                button1.Text = "Switch Account";
                button5.Hide();
                richTextBox4.Show();
                button4.Show();
                label5.Text = "How was our service?";
                numericUpDown1.Show();
                label7.Show();
                label6.Show();
                label8.Show();
            }
            else
            {
                button5.Show();
                label5.Text = "Log in to write a review";
                richTextBox4.Hide();
                button4.Hide();
                numericUpDown1.Hide();
                label7.Hide();
                label6.Hide();
                label8.Hide();
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

        public void submit_review(object sender, EventArgs e)
        {
            bool result = dataHandler.submit_review(richTextBox4.Text, config.FirstName, config.LastName, Decimal.ToInt32(numericUpDown1.Value));
            if (result)
            {
                richTextBox4.Text = "";
                numericUpDown1.Value = 0;
            }
            else
            {
                Debug.WriteLine("something went wrong");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
