using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSON_WebToken_App.Models
{
    public class InputSanitizer
    {

            
        public static string SanitizeInput(string inputString)
        {
            string returnValue = string.Empty;

            returnValue = HttpContext.Current.Server.HtmlEncode(inputString);

            return returnValue;
        }



    }
}