using biyDaalt;
using System.Diagnostics;

namespace biyDaalt_test
{
    public class biyDaalt_test
    {
        string testfirstname = "testname3";
        string testlastname = "testlastName3";


        /*
         occupy_seat_working
         */

        [Fact]
        public void occupy_seat_working1()//for clearing seat up
        {


            bool result = dataHandler.occupy_seat(2, "", "");
            Dictionary<string, string> names = dataHandler.returnName(2);

            bool sameName;
            if (names["firstName"].ToString() == "" && names["lastName"].ToString() == "")
            {
                sameName = true;
            }
            else
            {
                sameName = false;
            }

            Assert.True(sameName && result);
        }
        [Fact]
        public void occupy_seat_Notworking()
        {


            bool result = dataHandler.occupy_seat(2, "", testlastname);
            Dictionary<string, string> names = dataHandler.returnName(2);


            Assert.False(result);
        }
        [Fact]
        public void occupy_seat_working()
        {
            bool result = dataHandler.occupy_seat(2, testfirstname, testlastname);
            Dictionary<string, string> names = dataHandler.returnName(2);

            bool sameName;
            if (names["firstName"].ToString() == testfirstname && names["lastName"].ToString() == testlastname)
            {
                sameName = true;
            }
            else
            {
                sameName = false;
            }

            Assert.True(sameName && result);
        }
        


        /*
         returnName 
         */

        [Fact]
        public void is_seat2_firstName()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(2);

            Assert.True(testfirstname == data["firstName"].ToString() && testlastname == data["lastName"].ToString());
        }
        [Fact]
        public void is_seat5_returnName()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(5);

            Assert.True(data["firstName"].ToString() == "tem" && data["lastName"].ToString() == "ulz");
        }
        [Fact]
        public void is_seat12_returnName()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(12);

            Assert.True(data.ContainsKey("error"));
        }


        /*
         isAvailable 
         */


        [Fact]
        public void seat2_unavaiable()
        {
            Assert.False(dataHandler.isAvailable(2));
        }
        [Fact]
        public void seat5_unavailable()
        {
            Assert.False(dataHandler.isAvailable(5));
        }
        [Fact]
        public void seat14_available()
        {
            Assert.True(dataHandler.isAvailable(14));
        }

        /*
         delete_user_seat
         */

        [Fact]
        public void delete_userSeat_works()//see if function that takes name and deletes the reserved seat is working
        {
            Assert.True(dataHandler.delete_user_seat("testname3", "testlastName3"));
        }
        [Fact]
        public void delete_userSeat_resturns_false()
        {
            Assert.False(dataHandler.delete_user_seat("fake", "fake"));
        }
        [Fact]
        public void delete_userSeatEmpty_resturns_false()
        {
            Assert.False(dataHandler.delete_user_seat("", ""));
        }

        /*
         returnSeat
         */

        [Fact]
        public void returnSeat_true()
        {
            Dictionary<string, string> result = dataHandler.returnSeat("tem", "ulz");
            Assert.True(result["seat"].ToString() == "5" && result["description"].ToString() == "");
        }
        [Fact]
        public void returnSeat_false()
        {
            Dictionary<string, string> result = dataHandler.returnSeat("", "");
            Assert.True(result.ContainsKey("error"));
        }


        /*
         update_seatUserNames 
         */

        [Fact]
        public void update_seatUserNames_working()
        {
            int seat_index = 10;
            bool result = dataHandler.update_seatUserNames("newF", "newL", "new", "new");
            Dictionary<string, string> temp = dataHandler.returnSeat("new", "new");


            Assert.True(result && (temp["seat"].ToString()) == "10");
        }
        [Fact]
        public void update_seatUserNames_Notworking()
        {
            Assert.False(dataHandler.update_seatUserNames("new", "new", "", ""));
        }
        [Fact]
        public void update_seatUserNames_Notworking1()
        {
            Assert.False(dataHandler.update_seatUserNames("not", "not", "bob", "bob"));
        }


        /*
         submit_review 
         */

        [Fact]
        public void submit_review_working()
        {
            Assert.True(dataHandler.submit_review("reviewed", "testfirst", "testlast", 10));
        }
        [Fact]
        public void submit_review_working1()
        {
            Assert.True(dataHandler.submit_review("reviewed", "testfirst", "testlast", 1));
        }
        [Fact]
        public void submit_review_Notworking()
        {
            Assert.False(dataHandler.submit_review("reviewed", "testfirst", "testlast", 19));
        }
        [Fact]
        public void submit_review_Notworking1()
        {
            Assert.False(dataHandler.submit_review("reviewed", "testfirst", "testlast", -5));
        }
        [Fact]
        public void submit_review_Notworking2()
        {
            Assert.False(dataHandler.submit_review("", "", "", 5));
        }


        /*
         deleteUser 
         */

        [Fact]
        public void deleteUser_working()
        {
            Assert.True(dataHandler.deleteUser("qwe"));
        }
        [Fact]
        public void deleteUser_Notworking1()
        {
            Assert.False(dataHandler.deleteUser(""));
        }
    }
}