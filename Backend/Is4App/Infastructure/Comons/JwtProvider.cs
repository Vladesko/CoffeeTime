using App.Interfaces;
using DomainApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infastructure.Comons.Exceptions
{
    public class JwtProvider : IJwtProvider
    {
        private string secretKey;
        public JwtProvider()
        {
            string secretKey = string.Empty;

            using (var sr = new StreamReader("D:\\Passwords\\SecretKey.txt", Encoding.UTF8, false))
            {
                secretKey = sr.ReadToEnd();
            }
            this.secretKey = secretKey;
        }
        public string CreateToken(User user)
        {
            var signInCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), 
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(signingCredentials: signInCredentials,
                                             expires: DateTime.UtcNow.AddHours(3),
                                             claims: GetClaims(user));


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> GetClaims(User user) => 
            new List<Claim>() 
            {
                new Claim("UserName", user.UserName),
                new Claim("UserId", user.Id.ToString()),
            };



    }
}
