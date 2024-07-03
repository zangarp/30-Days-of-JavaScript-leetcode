using FinOpsAPI.Helpers;
using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace FinOpsAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> Login(Auth authModel)
        {
            try
            {
                using (var connection = new OracleConnection(DBHelper.GetConnectionString(authModel)))
                {
                    await connection.OpenAsync();
                    var tokenString = GenerateJWT(authModel);
                    return tokenString;
                }
            }
            catch (Exception e)
            {
                if (e.Message.StartsWith("ORA-01017")) return string.Empty;
                throw;
            }
        }

        private string GenerateJWT(Auth authModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, authModel.Login!),
                new Claim("ConnectionString", DBHelper.GetConnectionString(authModel)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration.GetValue<string>("Jwt:Issuer"),
              _configuration.GetValue<string>("Jwt:Issuer"),
              claims,
              expires: DateTime.Now.AddHours(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
