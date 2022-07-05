using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace biyDaalt
{
    public static class dataHandler 
    {
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tem\Source\Repos\Temctl\restaraunt_biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";


        public static bool submit_review(string review, string firstName, string lastName, int value)// submits review to the database under this name with the value that the user gave
        {
            string cmdString = "INSERT INTO [dbo].[Reviews] (review, firstName, lastName, value) VALUES (@val1, @val2, @val3, @val4)";
            //string cmdString = "select * from Users";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = cmdString;
                        //adding the parameters
                        command.Parameters.AddWithValue("@val1", review);
                        command.Parameters.AddWithValue("@val2", firstName);
                        command.Parameters.AddWithValue("@val3", lastName);
                        command.Parameters.AddWithValue("@val4", value);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("error is: -------\n" + ex.ToString());
                            return false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Dictionary<string, List<String>> return_review()//returns dictionary of the last three rows of review data
        {
            Dictionary<string, List<String>> result = new Dictionary<string, List<String>>();
            string cmdString = "SELECT top 3 review, firstName, lastName, value FROM dbo.Reviews order by Id desc";
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
                                int boxIndex = 1;
                                List<String> rows = new List<String>();
                                while (reader.Read())
                                {
                                    rows.Add(reader["firstName"].ToString());
                                    rows.Add(reader["lastName"].ToString());
                                    rows.Add(reader["value"].ToString());
                                    rows.Add(reader["review"].ToString());
                                    result[boxIndex.ToString()] = rows;
                                    boxIndex++;
                                }
                                Debug.WriteLine("1");
                                return result;
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.GetType);
                            List<String> temp = new List<String>();
                            temp.Add(exec.ToString());
                            result["error"] = temp;
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                Debug.WriteLine(ex.GetType);
                List<String> temp = new List<String>();
                temp.Add(ex.ToString());
                result["error"] = temp;
                return result;
            }
        }

        public static bool occupy_seat(int index, string firstName, string lastName)// reserve this seat(index) on this person (firstname lastName)
        {
            Debug.WriteLine("seat index is " + index);
            string cmdString = "update dbo.Tables set current_user_Fname = @val3, current_user_Lname = @val4, availability = @val1 where Id = @val2";
            //string cmdString = "select * from Users";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = cmdString;
                        //adding the parameters
                        int temp = 0;
                        if(firstName == "")
                        {
                            temp = 1;
                        }
                        command.Parameters.AddWithValue("@val3", firstName);
                        command.Parameters.AddWithValue("@val4", lastName);
                        command.Parameters.AddWithValue("@val1", temp);
                        command.Parameters.AddWithValue("@val2", index);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            config.Seat_using = index;
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("error is: -------\n" + ex.ToString());
                            return false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool delete_user_seat(string firstname, string lastname)// deletes the reserved seat that is on this name
        {
            string cmdString = "SELECT Id FROM dbo.Tables where current_user_Fname = @val1 and current_user_Lname = @val2";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        command.Parameters.AddWithValue("@val1", firstname);
                        command.Parameters.AddWithValue("@val2", lastname);
                        conn.Open();
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Debug.WriteLine("id is " + (int)reader["Id"]);
                                        occupy_seat(((int)reader["Id"]), "", "");
                                    }
                                }
                                return true; 
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.ToString());
                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                return false;
            }
        }
        public static bool cancel_seat(int seat_index)//admin will cancel a seat
        {
            return occupy_seat(seat_index, "", "");
        }

        public static Dictionary<string, string> returnName(int seat_index)// returns the name of the reserved user at this seat
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string cmdString = "SELECT current_user_Fname, current_user_Lname FROM dbo.Tables where Id = @val1";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        command.Parameters.AddWithValue("@val1", seat_index);
                        conn.Open();
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        result["firstName"] = reader["current_user_Fname"].ToString();
                                        result["lastName"] = reader["current_user_Lname"].ToString();
                                    }
                                    Debug.WriteLine("1");
                                    return result;
                                }
                                else
                                {
                                    result["error"] = "not found";
                                    return result;
                                }
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.ToString());
                            string temp = (exec.ToString());
                            result["error"] = temp;
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                string temp = (ex.ToString());
                result["error"] = temp;
                return result;
            }
        }


        public static Dictionary<string, string> returnSeat(string firstName, string lastName)// resturns what seat this user with this name is reserved at.
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string cmdString = "SELECT Id, description FROM dbo.Tables WHERE current_user_Fname = @val1 AND current_user_Lname = @val2";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        Debug.WriteLine(" fdhjskfhdjksfhjdsiahfj");
                        command.Parameters.AddWithValue("@val1", firstName);
                        command.Parameters.AddWithValue("@val2", lastName);
                        conn.Open();
                        try
                        {
                            Debug.WriteLine(" fdhjskfhdjksfhjdsiahfj");
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Debug.WriteLine(" fdhjskfhdjksfhjdsiahfj");
                                if (reader.HasRows)
                                {
                                    Debug.WriteLine(" fdhjskfhdjksfhjdsiahfj");
                                    while (reader.Read())
                                    {
                                        Debug.WriteLine(reader["Id"].ToString() + " fdhjskfhdjksfhjdsiahfj");
                                        Debug.WriteLine(reader["description"].ToString() + " fdhjskfhdjksfhjdsiahfj");
                                        result["seat"] = reader["Id"].ToString();
                                        result["description"] = reader["description"].ToString();
                                    }
                                }
                                Debug.WriteLine("1");
                                return result;
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.ToString());
                            string temp = (exec.ToString());
                            result["error"] = temp;
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                string temp = (ex.ToString());
                result["error"] = temp;
                return result;
            }
        }

        public static bool isAvailable(int seat_index)// returns if this seat is available to reserve 
        {
            string cmdString = "SELECT Id FROM dbo.Tables where Id = @val1";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand(cmdString, conn))
                    {
                        command.Parameters.AddWithValue("@val1", seat_index);
                        conn.Open();
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine("blahblah_____ " + exec.ToString());
                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                return false;
            }
        }

        public static bool updateUserInfo(List<string> info)//updates the logged in users info
        {
            bool result;
            result = deleteUser(info[2]);
            if (result)
            {
                update_seatUserNames(config.FirstName, config.LastName, info[0].ToString(), info[1].ToString());
                info.Add(config.Password);
                return config.setEverything(info, true);
            }
            else
            {
                return false;
            }
            
        }

        public static bool deleteUser(string email)// deletes from users with this email
        {
            string cmdString = "delete from [dbo].[User_info] where email = @val1";
            //string cmdString = "select * from Users";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = cmdString;
                        //adding the parameters
                        command.Parameters.AddWithValue("@val1", email);
                        try
                        {
                            Debug.WriteLine("coming here :" + email);
                            conn.Open();
                            command.ExecuteNonQuery();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            return false;
                            Debug.WriteLine("error is: -------\n" + ex.ToString());
                        }
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool update_seatUserNames(string old_firstName, string old_lastName, string firstName, string lastName)
        {
            string cmdString = "update [dbo].[Tables] set current_user_Fname = @val1, current_user_Lname = @val2 where current_user_Fname = @val3 and current_user_Lname = @val4";
            //string cmdString = "select * from Users";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = cmdString;
                        //adding the parameters
                        command.Parameters.AddWithValue("@val1", firstName);
                        command.Parameters.AddWithValue("@val2", lastName);
                        command.Parameters.AddWithValue("@val3", old_firstName);
                        command.Parameters.AddWithValue("@val4", old_lastName);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            Debug.WriteLine("stuff is right");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("error is: -------\n" + ex.ToString());
                            return false;
                        }
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
