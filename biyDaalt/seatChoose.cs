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
        private bool seat_change_bool = false;

        private bool isAdmin = false;

        private Button chosen_seat;
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tem\Source\Repos\Temctl\restaraunt_biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";

        public seatChoose(bool isAdmin)
        {
            if (isAdmin)
            {
                this.isAdmin = true;
            }
            InitializeComponent();
            initilize_seat();
            status_change();
        }

        public static void status_change()
        {
            if (config.IsAdmin)
            {
                button19.Show();
            }
            else
            {
                button19.Hide();
            }
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
                                        string plus = "";
                                        if (isAdmin)
                                        {
                                            Debug.WriteLine("is admin?");
                                            plus = " \n" + reader["current_user_Fname"].ToString() + " " + reader["current_user_Lname"].ToString();
                                        }
                                        else
                                        {
                                            bt.Enabled = false;
                                        }
                                        bt.Text = "unavailable" + plus;
                                    }
                                    else
                                    {
                                        bt.Text = reader["typeOfSeat"].ToString() + "\nSeats: " + reader["seat_num"].ToString();
                                    }
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
            if (seat_change_bool)
            {
                Button newButton = (Button)sender;
                bool fine = dataHandler.isAvailable(newButton.TabIndex);
                if (fine)
                {
                    Dictionary<string, string> names = dataHandler.returnName(chosen_seat.TabIndex + 1);
                    dataHandler.cancel_seat(chosen_seat.TabIndex + 1);
                    bool done = dataHandler.occupy_seat(newButton.TabIndex, names["firstName"], names["lastName"]);
                    if (!done)
                    {
                        Debug.WriteLine("not done");
                    }
                }
                seat_change_bool = false;
                
            }
            else
            {
                chosen_seat = (Button)sender;
            }
        }

        private void submit(object sender, EventArgs e)
        {
            if (!config.Logged && !config.IsAdmin)
            {
                login login = new login();
                this.Hide();
                login.ShowDialog();
            }
            if (!config.IsAdmin)
            {
                this.Show();
                string firstname = config.firstName;
                string lastname = config.lastName;
                bool result = dataHandler.delete_user_seat(firstname, lastname);
                chosen_seat.Enabled = false;
                chosen_seat.Text = "unavailable";
                result = dataHandler.occupy_seat(chosen_seat.TabIndex + 1, firstname, lastname);
                if (!result)
                {
                    Debug.WriteLine("something wriong");
                }
                else
                {
                    this.Dispose();
                }
            }
            else
            {
                if(chosen_seat == null)
                {

                }
                else
                {
                    signup sign = new signup(true);
                    sign.ShowDialog();
                    string firstname = config.firstName;
                    string lastname = config.lastName;
                    bool result = dataHandler.delete_user_seat(firstname, lastname);
                    chosen_seat.Enabled = false;
                    chosen_seat.Text = "unavailable";
                    this.Hide();
                    result = dataHandler.occupy_seat(chosen_seat.TabIndex + 1, firstname, lastname);
                    if (!result)
                    {
                        Debug.WriteLine("something wriong");
                        this.Dispose();
                    }
                    else
                    {
                        this.Hide();
                        this.Dispose();
                    }
                }
                
            }
        }

        public void change_seat(object sender, EventArgs e)
        {
            if (chosen_seat != null)
            {
                seat_change_bool = true;

            }
            else
            {
                Debug.WriteLine("choose a seat");
            }
        }

        private void cancel_seat(object sender, EventArgs e)
        {
            
            if (!config.Logged && !config.IsAdmin)
            {
                login login = new login();
                login.ShowDialog();
            }
            if (!config.IsAdmin)
            {
                string firstname = config.firstName;
                string lastname = config.lastName;
                bool result = dataHandler.delete_user_seat(firstname, lastname);
                if (result)
                {
                    this.Dispose();
                }
                else
                {
                    Debug.WriteLine("something wriong");
                }
            }
            else //if the admin chose
            {
                if(chosen_seat != null)
                {
                    dataHandler.cancel_seat(chosen_seat.TabIndex + 1);
                }
                else
                {
                    Debug.WriteLine("choose a seat");
                }
            }
        }
    }
}
