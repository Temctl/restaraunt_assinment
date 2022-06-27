using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace biyDaalt
{
    internal static class dataHandler
    {
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";


        public static bool submit_review(string review, string firstName, string lastName, int value)
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

        public static Dictionary<string, List<String>> return_review()
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

        public static bool occupy_seat(int index, string firstName, string lastName)
        {
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
                        command.Parameters.AddWithValue("@val1", 0);
                        command.Parameters.AddWithValue("@val2", index);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            Debug.WriteLine("2");
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

        public static bool delete_user_seat(string firstname, string lastname)
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
    }
}
