﻿using JSON_WebToken_App.Filters;
using JSON_WebToken_App.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;


namespace JSON_WebToken_App.Controllers
{
    public class TokenController : ApiController
    {
        [BasicAuthentication]
        public string Get()
        {
            string user = HttpContext.Current.Request.LogonUserIdentity.Name;

            JwtToken tokenManager = new JwtToken();            
            string token = tokenManager.GenerateJwtToken(user);

            return token;
        }
    }
}
