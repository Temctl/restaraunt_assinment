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

        public static Dictionary<string, object> return_review()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string cmdString = "SELECT top 3 * FROM dbo.Reviews order by Id desc";
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
                                int columns = 4;
                                List < List<string>> rows = new List<List<string>>();
                                while (reader.Read())
                                {
                                    List<string> row = new List<string>();
                                    for (int i = 1; i <= columns; i++)
                                    {
                                        Debug.WriteLine(i);
                                        Debug.WriteLine(reader.GetString(i));
                                        row.Add(reader.GetString(i));
                                        
                                    }
                                    rows.Add(row);
                                }
                                result["review"] = rows;
                                Debug.WriteLine("1");
                                return result;
                            }
                        }
                        catch (Exception exec)
                        {
                            Debug.WriteLine(exec.GetType);
                            result["review"] = false;
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("error: ---- " + ex.ToString);
                result["review"] = false;
                return result;
            }
        }
    }
}
