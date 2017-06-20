using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Models;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Security.Claims;

namespace Tests
{
    [TestClass]
    public class Tests
    {

        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public Tests()
        {
            this._jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        [TestMethod]
        public void ApiSecurityTest()
        {
            bool validated = ApiSecurity.VaidateUser("ei\\jwilson", "p@55w0rd");
            Assert.IsTrue(validated);
        }

        [TestMethod]
        public void CreateJWT()
        {
            JwtToken jwtToken = new JwtToken();

            Dictionary<string, string> payloadContents = jwtToken.GeneratePayload("ei\\jwilson");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(VirtualDatabase.QueryPrivateKey()));
            var signingCredentials = new SigningCredentials(securityKey, "HS256"); //HMAC-SHA256 - Could also be done asymmetric with RS256
            var payloadClaims = payloadContents.Select(c => new Claim(c.Key, c.Value));
            var payload = new JwtPayload(payloadClaims);
            var header = new JwtHeader(signingCredentials);
            var securityToken = new JwtSecurityToken(header, payload);

            string createdToken = this._jwtSecurityTokenHandler.WriteToken(securityToken);

            int countedDots =  createdToken.Count(x => x == '.');

            Assert.AreEqual(countedDots, 2);
        }
    }

}
