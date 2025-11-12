using ControlDesk.Application.DTOs;
using ControlDesk.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlDesk.Infrastructure.Repositories
{
    public class AuthRepository(IOptions<TokenDto>? securityKey) : IAuthService
    {
        private readonly IOptions<TokenDto>? _securityKey = securityKey;

        /// <summary>
        /// Repositorio para generar token
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="username"></param>
        /// <param name="validTime"></param>
        /// <returns></returns>
        public string GenerateToken(DateTime currentDate, string username, TimeSpan validTime)
        {
            string? valueKey = _securityKey?.Value.SigningKey;
            var fechaExpiracion = currentDate.Add(validTime);
            var claims = new Claim[]
            {
            new (JwtRegisteredClaimNames.Sub,username),
            new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Iat,
                new DateTimeOffset(currentDate).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64
            ),
            new ("roles","Support"),
            new ("roles","Administrator"),
            };

            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(valueKey)),
                    SecurityAlgorithms.HmacSha256Signature
            );

            var jwt = new JwtSecurityToken(
                issuer: "Peticionario",
                audience: "Public",
                claims: claims,
                notBefore: currentDate,
                expires: fechaExpiracion,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
