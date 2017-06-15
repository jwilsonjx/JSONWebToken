using JSON_WebToken_App.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using log4net;
using System.Linq;

namespace JSON_WebToken_App.Filters
{
    public class JwtAuthentication : AuthorizationFilterAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                IEnumerable<string> tokens = actionContext.Request.Headers.GetValues("token");

                if (!ValidateToken(((string[])tokens)[0]))
                {
                    // return unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);

                // return unauthorized error 
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }

        private static bool ValidateToken(string jsonWebToken)
        {
            bool validated = false;

            try
            {
                JwtSecurityToken token, compareToken;               
                JwtToken jwtToken = new JwtToken();

                string compareTokenString = string.Empty;
                compareTokenString = jwtToken.GenerateJwtCompareToken(jsonWebToken);

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                token = handler.ReadJwtToken(jsonWebToken);
                compareToken = handler.ReadJwtToken(compareTokenString);

                // Signatures match
                if (token.RawData == compareToken.RawData)
                {
                    //Verify expiration time
                    var tempExpiration = token.Claims.First(claim => claim.Type == "exp").Value;
                    long exp = Convert.ToInt64(tempExpiration);
                    var now = JwtToken.ConvertToUnixTime(DateTime.Now);

                    if(exp > now)
                    {
                        validated = true;
                    }                    
                }
                else
                {
                    log.Warn("Invalid Token Attempted:" + jsonWebToken);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
     
            return validated;
        }
    }
}