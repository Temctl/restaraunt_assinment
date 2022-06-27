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
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tem\Source\Repos\restaraunt_biyDaalt\biyDaalt\TablesData.mdf;Integrated Security=True";


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
                                    boxIndex ++;
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
    }
}
