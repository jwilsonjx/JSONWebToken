using System.Collections.Generic;
using System.Web;

namespace Tests.Models
{
    public class ApiSecurity
    {
        public static bool VaidateUser(string username, string password)
        {
            bool validated = false;

            Dictionary<string, string> userDatabase = VirtualDatabase.QueryUsers();

            if (userDatabase.ContainsKey(username) && userDatabase[username].Equals(password))
            {
                validated = true;
            }

            return validated;
        }
    }
}