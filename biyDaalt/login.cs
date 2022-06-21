using System.Data.SqlClient;

namespace biyDaalt
{
    public partial class login : Form
    {
        string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
        public login()
        {
            InitializeComponent();
        }

        public void login_clicked(object sender, EventArgs e)
        {
            string username = this.textBox1.Text; 
            string password = this.textBox2.Text;
            string cmdString = "SELECT * FROM dbo.Users WHERE email = @val1 AND password = @val2";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        command.Parameters.AddWithValue("@val1", username);
                        command.Parameters.AddWithValue("@val2", password);
                        conn.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int count = reader.FieldCount;
                            while (reader.Read())
                            {
                                Console.WriteLine(reader);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        public void signup_clicked(object sender, EventArgs e)
        {
            string cmdString = "INSERT INTO dbo.Users (firstName, lastName, email, password, phoneNumber, address) VALUES (@val1, @val2, @val3, @val4, @val5, @val6)";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = cmdString;
                        //comm.Parameters.AddWithValue("@val1", txtbox1.Text);
                        //comm.Parameters.AddWithValue("@val2", txtbox2.Text);
                        //comm.Parameters.AddWithValue("@val3", txtbox3.Text);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception){

                        }
                    }
                }
                
            }
            catch (Exception)
            {

            }
        }
    }
}