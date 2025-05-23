﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;


namespace biyDaalt
{
    internal class config // file with all the user information whenthey are logged in
    {
        static string cs = dataHandler.cs;
        public static string description = "";
        public static string Description
        {
            get { return description; }
            set { description = value; }
        }


        public static int seat_using = -1;
        public static int Seat_using
        {
            get { return seat_using; }
            set { seat_using = value; }
        }

        public static bool isAdmin = false;
        public static bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public static bool logged = false;
        public static bool Logged
        {
            get { return logged; }
            set { logged = value; }
        }

        public static string firstName;
        public static string lastName;
        //public static string id;
        public static string email;
        public static string phoneNumber;
        public static string address;
        public static string password;

        //getters and setters
        public static string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public static string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        //public static string Id
        //{
           // get { return id; }
           // set { id = value; }
       // }
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }
        public static string Address
        {
            get { return address; }
            set { address = value; }
        }
        public static string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public static string Password
        {
            get { return password; }     
            set { password = value; }   
        }

        public static string ADMIN_EMAIL = "admin1";
        public static string ADMIN_PASSWORD = "admin2022";

        //
        //functions
        //
        public static bool setEverything(List<string> info, bool newUser)// sets up the class info
        {
            try
            {
                Debug.WriteLine(info[5].ToString() + " is the password right?");
                FirstName = info[0];
                LastName = info[1];
                Email = info[2];
                PhoneNumber = info[3];
                Address = info[4];
                Password = info[5];
                if (newUser)
                {
                    signup();
                }
                else
                {
                    Logged = true;
                    welcomePage.statusChanged();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void signup()// adds this user info to the database and put the value of user to the values of this class
        {
            string cmdString = "INSERT INTO [dbo].[User_info] (firstName, lastName, email, password, phoneNumber, address) VALUES (@val1, @val2, @val3, @val4, @val5, @val6)";
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
                        command.Parameters.AddWithValue("@val1", FirstName);
                        command.Parameters.AddWithValue("@val2", LastName);
                        command.Parameters.AddWithValue("@val3", Email);
                        command.Parameters.AddWithValue("@val4", Password);
                        command.Parameters.AddWithValue("@val5", PhoneNumber);
                        command.Parameters.AddWithValue("@val6", Address);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("error is: -------\n" + ex.ToString());
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        public static void clean()// cleans this class of any user info
        {
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
            Address = "";
            Logged = false;
            IsAdmin = false;
            Description = "";
            Seat_using = -1;
            welcomePage.statusChanged();
        }
    }
}
