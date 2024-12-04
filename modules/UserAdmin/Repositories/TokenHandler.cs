
using UserAdmin.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Database.Models.UserAdmin;

namespace UserAdmin.Repositories
{
    public class TokenHandler : ITokenHandler
    {

        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> CreateTokenAsync(mast_userm user)
        {
            // Create Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.user_code!));
            claims.Add(new Claim(ClaimTypes.Surname, user.user_name!));
            claims.Add(new Claim(ClaimTypes.Email, user.user_email!));

            // Loop into roles of users
            /*
            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });
            */

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                //expires: DateTime.Now.AddHours(12),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                ); ;

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
