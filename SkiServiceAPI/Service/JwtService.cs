﻿using Microsoft.IdentityModel.Tokens;
using SkiServiceAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkiServiceAPI.Service
{
    public class JwtService : IJwtService
    {
        private readonly RegistrationContext _dbContext;
        //Injecting IConfiguration into this class in order to read Token Key from the configuration file
        private readonly SymmetricSecurityKey _key;
        public JwtService(IConfiguration config, RegistrationContext dbContext)
        {
            _dbContext = dbContext;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        public string CreateToken(string username)
        {

            //Creating Claims. You can add more information in these claims. For example email id.
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, username)
                };

            //Creating credentials. Specifying which type of Security Algorithm we are using
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Creating Token description
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Finally returning the created token
            return tokenHandler.WriteToken(token);

        }

        public List<User> Login()
        {

            List<User> users = new List<User>();
            users = _dbContext.Users.ToList();
            return users;

        }
    }
}
