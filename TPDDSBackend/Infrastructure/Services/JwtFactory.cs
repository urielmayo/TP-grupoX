using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Services
{
    public class JwtFactory : IJwtFactory
    {
        private readonly UserManager<Collaborator> _userManager;
        private readonly IConfiguration _configuration;
        private const int JwtExpirationTimeInMinutes = 120;

        public JwtFactory(UserManager<Collaborator> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateEncodedToken(Collaborator user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName)
        };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(JwtExpirationTimeInMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public (string Id, string UserName) GetClaims(string token)
        {
            try
            {
                if (token.StartsWith("Bearer "))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                var claims = jwtToken.Claims;

                var id = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
                var userName = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value;
                return (id, userName);

            }
            catch (Exception ex)
            {
                throw new ApiCustomException(ex.Message, HttpStatusCode.Forbidden);
            }
        }
    }
}
