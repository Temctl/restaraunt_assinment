using System.Data.SqlClient;
using System.Diagnostics;

namespace biyDaalt
{
    public partial class login : Form
    {
        public  

        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";
        public login()
        {
            InitializeComponent();
        }

        public void login_clicked(object sender, EventArgs e)
        {
            string username = this.textBox1.Text; 
            string password = this.textBox2.Text;
            string cmdString = "SELECT * FROM dbo.User_info WHERE email = @val1 AND password = @val2";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        command.Parameters.AddWithValue("@val1", username);
                        command.Parameters.AddWithValue("@val2", password);
                        Debug.WriteLine("1");
                        conn.Open();
                        Debug.WriteLine("1");
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Debug.WriteLine("1");
                                reader.Read();

                                Debug.WriteLine(reader["firstName"].ToString());
                                //while (reader.Read())
                                //{
                                //Debug.WriteLine(reader);
                                //}
                            }
                        }
                        catch(Exception exec)
                        {
                            if (exec.InnerException is (System.InvalidOperationException))
                            {
                                Debug.WriteLine("change it");
                            }
                            Debug.WriteLine(exec.GetType);  
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
            }
        }

        public void signup_clicked(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.ShowDialog();
        }


    }
}