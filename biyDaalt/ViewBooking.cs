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
    public partial class ViewBooking : Form
    {

        bool edit = false;
        public ViewBooking()
        {
            InitializeComponent();
            setup();
        }

        private void setup()
        {
            disable();
            this.button1.Text = "Go Back";
            this.textBox1.Text = config.FirstName;
            this.textBox2.Text = config.LastName;
            this.textBox3.Text = config.Email;
            this.textBox4.Text = config.PhoneNumber;
            this.textBox5.Text = config.Address;
            Debug.WriteLine(config.Address, config.Email);
            if(config.Seat_using != null && config.Seat_using != -1)
            {
                string temp = "";
                if(config.Description != "" && config.Description != null)
                {
                    temp = "(" + config.Description + ")";
                }
                this.label7.Text = "Your reserved the seat " + config.Seat_using + " " + temp;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                edit = true;
                enable();
                this.button1.Text = "Change Info";
            }
            else
            {
                edit = false;
                disable();
                this.button1.Text = "Go Back";
            }
        }

        private void disable()
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
        }

        private void enable()
        {
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> info = new List<string>();
            if (edit)
            {
                info.Add(this.textBox1.Text);
                info.Add(this.textBox2.Text);
                info.Add(this.textBox3.Text);
                info.Add(this.textBox4.Text);
                info.Add(this.textBox5.Text);
                bool result = dataHandler.updateUserInfo(info);
                if (result)
                {
                    this.Dispose();
                }
                else
                {
                    Debug.WriteLine("something went really wrong");
                }
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
