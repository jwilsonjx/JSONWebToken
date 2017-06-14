using System.Collections.Generic;

namespace JSON_WebToken_App.Models
{
    /// <summary>
    /// This is being used as a "virtual" database
    /// for demonstration purposes. These methods represent database calls
    /// that would be made.
    /// </summary>
    public class VirtualDatabase
    {
        public static Dictionary<string, string> QueryUsers()
        {
            Dictionary<string, string> returnDictionary = new Dictionary<string, string>();

            returnDictionary.Add("jason", "password");
            returnDictionary.Add("jwilson", "password");

            return returnDictionary;
        }

        public static string QueryPrivateKey()
        {
            return "thisisasuperlongkeystringwithsomerandomtextsadjaksdhjaskhd";
        }
    }
}