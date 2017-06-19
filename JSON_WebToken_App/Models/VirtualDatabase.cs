using System.Collections.Generic;

namespace JSON_WebToken_App.Models
{
    /// <summary>
    /// This is being used as a "virtual" database
    /// for demonstration purposes. These methods represent the database calls
    /// that would normally be made.
    /// </summary>
    public class VirtualDatabase
    {
        public static Dictionary<string, string> QueryUsers()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>();

            returnDictionary.Add(@"ei\jwilson", "password");
            returnDictionary.Add(@"ei\jason", "password");

            return returnDictionary;
        }   
        
        public static List<User> QueryUserInfo()
        {
            List<User> returnUserList = new List<User>();

            User user1 = new User();
            user1.UserName = @"ei\jwilson";
            user1.Email = "jwilsonjx@outlook.com";
            user1.Role = "User";

            User user2 = new User();
            user2.UserName = @"ei\jason";
            user2.Email = "jwilsonjx@outlook.com";
            user2.Role = "User";

            returnUserList.Add(user1);
            returnUserList.Add(user2);

            return returnUserList;
        }

        public static string QueryPrivateKey()
        {
            return "thisisasuperlongkeystringwithsomerandomtextsadjaksdhjaskhd";
        }
    }
}