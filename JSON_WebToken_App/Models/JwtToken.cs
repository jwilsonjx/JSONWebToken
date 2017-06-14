﻿using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JSON_WebToken_App.Models
{
    public class JwtToken
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtToken()
        {
            this._jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateJwtToken(string userName)
        {
            Dictionary<string, string> payloadContents = GeneratePayload(userName);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(VirtualDatabase.QueryPrivateKey()));
            var signingCredentials = new SigningCredentials(securityKey, "HS256");
            var payloadClaims = payloadContents.Select(c => new Claim(c.Key, c.Value));
            var payload = new JwtPayload(payloadClaims);
            var header = new JwtHeader(signingCredentials);
            var securityToken = new JwtSecurityToken(header, payload);          

            return this._jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public string GenerateJwtCompareToken(string jsonWebtoken)
        {
            string returnKey = string.Empty;
    
            
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(jsonWebtoken);
            JwtPayload payload = new JwtPayload();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(VirtualDatabase.QueryPrivateKey()));
            var signingCredentials = new SigningCredentials(securityKey, "HS256"); //Could also be done asymmetric with RS256
            payload = token.Payload;
            var header = new JwtHeader(signingCredentials);
            var securityToken = new JwtSecurityToken(header, payload);

            return this._jwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public Dictionary<string, string> GeneratePayload(string userName)
        {
            Dictionary<string, string> returnPayload = new Dictionary<string, string>();

            List<User> UserRights = VirtualDatabase.QueryUserRights();

            foreach (User user in UserRights)
            {
                if(user.UserName == userName.ToLower())
                {
                    returnPayload.Add("sub", user.Email);
                    returnPayload.Add("name", user.UserName);
                    returnPayload.Add("role", user.Role);
                }
            }

            return returnPayload;
        }

    }
}