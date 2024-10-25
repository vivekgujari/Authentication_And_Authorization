using Authentication_And_Authorization.Context;
using Authentication_And_Authorization.Models;
using Authentication_And_Authorization.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication_And_Authorization.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(JwtContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public User? AddUser(User user)
        {
            try
            {
                var entity = _context.User.Add(user);
                _context.SaveChanges();
                return entity.Entity;
            }
            catch { }
            return null;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.UserName != null && loginRequest.Password != null)
            {
                var user = _context.User.SingleOrDefault(u => u.Email == loginRequest.UserName && u.Password == loginRequest.Password);
                if (user != null)
                {
                    var claim = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.FirstName),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claim,
                            expires: DateTime.UtcNow.AddMinutes(15),
                            signingCredentials: signIn
                        );
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
