﻿using System;
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
        static seatChoose seatchoose;
        public welcomePage()
        {
            InitializeComponent();
            statusChanged();
        }
        public welcomePage(List<String> row1 = null, List<String> row2 = null, List<String> row3 = null)
        {
            InitializeComponent();
            statusChanged();
            //each row has the needed info
            if(row1 != null)
            {
                this.label2.Text = row1[0] + " " + row1[1];
                this.richTextBox1.Text = row1[2] + "/10\n" + row1[3];
            }
            if(row2 != null)
            {
                this.label3.Text = row2[0] + " " + row2[1];
                this.richTextBox2.Text = row2[2] + "/10\n" + row2[3];
            }
            if(row3 != null)
            {
                this.label4.Text = row3[0] + " " + row3[1];
                this.richTextBox3.Text = row3[2] + "/10\n" + row3[3];
            }
        }


        public static void statusChanged()
        {
            if (config.IsAdmin)
            {
                button1.Text = "Switch Account";
                button3.Show();
            }
            else
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
                    button3.Show();
                    button6.Show();
                    tabPage2.Show();
                }
                else
                {
                    button1.Text = "Login";
                    button5.Show();
                    label5.Text = "Log in to write a review";
                    richTextBox4.Hide();
                    button4.Hide();
                    numericUpDown1.Hide();
                    label7.Hide();
                    label6.Hide();
                    label8.Hide();
                    button3.Hide();
                    button6.Hide();
                    tabPage2.Hide();
                }
            }
        }

        public void view_bookingDetail(object sender, EventArgs e)
        {
            ViewBooking viewBooking = new ViewBooking();
            viewBooking.ShowDialog();
        }

        private void seat_choose(object sender, EventArgs e)
        {
            seat_start();
        }

        public static void seat_start()
        {
            bool temp = false;
            if (config.IsAdmin)
            {
                temp = true;
            }
            seatchoose = new seatChoose(temp);
            seatchoose.ShowDialog();
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
                MessageBox.Show("Please write the review!");
            }
        }

        private void log_out(object sender, EventArgs e)
        {
            config.clean();
            statusChanged();
        }
    }
}
