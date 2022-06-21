using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biyDaalt
{
    internal class config // file with all the user information whenthey are logged in
    {
        public static string firstName;
        public static string lastName;
        public static string id;
        public static string email;
        public static string address;

        //getters and setters
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Address
        {
            get { return Address; }
            set { Address = value; }
        }
    }
}
