using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Extensions;

public static class Jwt
{
    private const string KEY = "1234567891234567890qwertyuiopasdfghjklzxcvbnm";

    private static readonly byte[] SecurityToken = Encoding.ASCII.GetBytes(KEY);

    public static string CreateToken(IDictionary<string, string> keyValues, DateTime expires)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var claims = keyValues.Select(c => new Claim(c.Key, c.Value));

        var token = jwtHandler.CreateToken(new()
        {
            Subject = new(claims),
            Expires = expires,
            SigningCredentials = new(new SymmetricSecurityKey(SecurityToken), SecurityAlgorithms.HmacSha256Signature)
        });
        return jwtHandler.WriteToken(token);
    }
}