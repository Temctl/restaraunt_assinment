using biyDaalt;
using System.Diagnostics;

namespace biyDaalt_test
{
    public class biyDaalt_test
    {
        [Fact]
        public void is_seat6_babafirstName()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(6);

            Assert.Equal("baba", data["firstName"].ToString());
        }

        [Fact]
        public void is_seat6_babalastName()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(6);

            Assert.Equal("bebe", data["lastname"].ToString());
        }


        [Fact]
        public void is_seat6_returnError()
        {
            Dictionary<string, string> data = biyDaalt.dataHandler.returnName(5);

            Assert.True(data["firstName"].ToString() == "" && data["lastName"].ToString() == "");
        }

        [Fact]
        public void is_seat6_avaiable()
        {
            Assert.True(biyDaalt.dataHandler.isAvailable(6));
        }

        [Fact]
        public void is_seat5_unavailable()
        {
            Assert.False(biyDaalt.dataHandler.isAvailable(5));
        }

        [Fact]
        public void delete_userSeat_works()//see if function that takes name and deletes the reserved seat is working
        {
            Assert.True(biyDaalt.dataHandler.delete_user_seat("baba", "bebe"));
        }

        [Fact]
        public void delete_userSeat_resturns_false()
        {
            Assert.True(biyDaalt.dataHandler.delete_user_seat("fake", "fake"));
        }

        [Fact]
        public void occupy_seat_working()
        {
            string testfirstname = "testname";
            string testlastname = "testlastName";

            bool result = dataHandler.occupy_seat(1, testfirstname, testlastname);
            Dictionary<string, string> names = dataHandler.returnName(1);

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

        [Fact]
        public void submit_review_working()
        {
            bool result = dataHandler.submit_review("reviewed", "testfirst", "testlast", 4);

            Assert.True(result);
        }
    }
}