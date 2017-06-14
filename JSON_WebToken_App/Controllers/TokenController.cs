using JSON_WebToken_App.Filters;
using JSON_WebToken_App.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace JSON_WebToken_App.Controllers
{
    public class TokenController : ApiController
    {
        [BasicAuthentication]
        public string Get()
        {
            JwtToken tokenManager = new JwtToken();
            string token = string.Empty;

            Dictionary<string, string> payloadContents = new Dictionary<string, string>();

            payloadContents.Add("sub", "jwilsonjx@outlook.com"); 
            payloadContents.Add("name", "Jason Wilson");
            payloadContents.Add("role", "user");

            token = tokenManager.GenerateJwtToken(payloadContents);


            return token;
        }
    }
}
