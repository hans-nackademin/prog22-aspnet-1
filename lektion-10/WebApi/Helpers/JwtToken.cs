using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Helpers;

public class JwtToken
{
    public static string Generate(ClaimsIdentity claimsIdentity, DateTime expiresAt, string key)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),SecurityAlgorithms.HmacSha512Signature)
        };

        return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
    }
}
