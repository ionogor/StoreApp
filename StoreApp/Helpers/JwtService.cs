﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StoreApp.Helpers
{
    public class JwtService
    {
        // read from appsettings file
        string securityKey = "this is my custom Secret key for authentication";
        public string GenerateToken(int id)
        {
            var symmetricSecurityKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            // credentials !!!
            var credintials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(credintials);

            var payload = new JwtPayload(id.ToString(),null,null,null,DateTime.Today.AddDays(1));

            var securityToken = new JwtSecurityToken(header,payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var token = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(securityKey);

            token.ValidateToken(jwt, new TokenValidationParameters 
            { 
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey=true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken securityToken);

            return (JwtSecurityToken)securityToken;
        }
    }
}
