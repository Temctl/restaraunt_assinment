using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace biyDaalt
{
    public partial class seatChoose : Form
    {
        private Button chosen_seat;
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";
        public seatChoose()
        {
            InitializeComponent();
            initilize_seat();
        }
        private void initilize_seat()
        {
            string cmdString = "SELECT Id, availability, seat_num, typeOfSeat, description, current_user_Fname, current_user_Lname, user_id FROM dbo.Tables";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        conn.Open();
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Debug.WriteLine("start");
                                while (reader.Read())
                                {
                                    string name = "button" + (reader["Id"]).ToString();
                                    Debug.WriteLine(name);
                                    
                                    Button bt = this.Controls.Find(name, true).FirstOrDefault() as Button;
                                    if ((reader["availability"].ToString()) == "0")
                                    {
                                        bt.Enabled = false;
                                        bt.Text = "unavailable";
                                    }
                                    bt.Text = reader["typeOfSeat"].ToString() + "\nSeats: " + reader["seat_num"].ToString();

                                }
                                Debug.WriteLine("end");
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                Debug.WriteLine(ex.GetType);
            }
        }
        
        public void seat_chosen(object sender, EventArgs e)
        {
            chosen_seat = (Button)sender;
        }

        private void submit(object sender, EventArgs e)
        {
            string firstname = config.firstName;
            string lastname = config.lastName;
            if (!config.Logged)
            {
                login login = new login();
                login.ShowDialog();
            }
            bool result = dataHandler.delete_user_seat(firstname, lastname);
            chosen_seat.Enabled = false;
            chosen_seat.Text = "unavailable";
            result = dataHandler.occupy_seat(chosen_seat.TabIndex, firstname, lastname);
            if (!result)
            {
                Debug.WriteLine("something wriong");
            }
        }

        private void cancel_seat(object sender, EventArgs e)
        {
            string firstname = config.firstName;
            string lastname = config.lastName;
            if (!config.Logged)
            {
                login login = new login();
                login.ShowDialog();
            }
            bool result = dataHandler.delete_user_seat(firstname, lastname);
        }
    }
}
