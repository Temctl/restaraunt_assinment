using System.Data.SqlClient;
using System.Diagnostics;

namespace biyDaalt
{
    public partial class login : Form
    {
        private const int firstName = 1;
        private const int lastName = 2;
        private const int emailIndex = 3;
        private const int passwordIndex = 4;
        private const int phoneNUmber = 5;
        private const int address = 6;

        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tem\Source\Repos\Temctl\restaraunt_biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";
        public login()
        {
            InitializeComponent();
        }

        public void login_clicked(object sender, EventArgs e)
        {
            login_helper(this.textBox1.Text, this.textBox2.Text);
        }

        public void signup_clicked(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.ShowDialog();
            welcomePage.statusChanged();
            this.Dispose();
        }



        private void login_helper(string email, string password)
        {
            if(email == config.ADMIN_EMAIL && password == config.ADMIN_PASSWORD)
            {
                config.clean();
                config.isAdmin = true;
                MessageBox.Show("Admin logged in!");
                this.Hide();
                welcomePage.seat_start();
                this.Dispose();
            }
            else
            {
                string cmdString = "SELECT * FROM dbo.User_info WHERE email = @val1 AND password = @val2";
                try
                {
                    Debug.WriteLine("fdsaf");
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        Debug.WriteLine("fdsaf");
                        using (var command = new SqlCommand(cmdString, conn))
                        {
                            command.Parameters.AddWithValue("@val1", email);
                            command.Parameters.AddWithValue("@val2", password);
                            Debug.WriteLine("fdsaf");
                            conn.Open();
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    Debug.WriteLine("1");
                                    reader.Read();

                                    List<string> info = new List<string>();
                                    info.Add(reader.GetString(firstName));
                                    info.Add(reader.GetString(lastName));
                                    info.Add(reader.GetString(emailIndex));
                                    info.Add(reader.GetString(phoneNUmber));
                                    info.Add(reader.GetString(address));
                                    info.Add(reader.GetString(passwordIndex));
                                    bool result = config.setEverything(info, false);
                                    if (result)
                                    {
                                        this.Hide();
                                        Dictionary<string, string> seat = dataHandler.returnSeat(reader.GetString(firstName), reader.GetString(lastName));
                                        if(seat.ContainsKey("error"))
                                        {
                                            
                                        }
                                        else
                                        {
                                            if (seat.ContainsKey("seat"))
                                            {
                                                config.Seat_using = Int32.Parse(seat["seat"].ToString());
                                                config.Description = seat["description"].ToString();
                                            }
                                        }
                                        MessageBox.Show("You are logged in!");
                                        welcomePage.statusChanged();
                                        this.Dispose();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email or password was wrong");
                                    }
                                }
                            }
                            catch (Exception exec)
                            {
                                if (exec.InnerException is (System.InvalidOperationException))
                                {
                                    Debug.WriteLine("change it");
                                }
                                Debug.WriteLine(exec.ToString());
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("error: ---- " + ex.ToString());
                }
            }
            
        }

        public void erase()
        {
            this.Dispose();
        }

    }
}