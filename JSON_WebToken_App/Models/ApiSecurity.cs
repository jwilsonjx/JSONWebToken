using System.Collections.Generic;
using System.Web;

namespace JSON_WebToken_App.Models
{
    public class ApiSecurity
    {
        public static bool VaidateUser(string username, string password)
        {
            bool validated = false;

            //Santize user input
            username = InputSanitizer.SanitizeInput(username);
            password = InputSanitizer.SanitizeInput(password);

            Dictionary<string, string> userDatabase = VirtualDatabase.QueryUsers();

            if (userDatabase.ContainsKey(username) && userDatabase[username].Equals(password))
            {
                validated = true;
            }

            return validated;
        }
    }
}