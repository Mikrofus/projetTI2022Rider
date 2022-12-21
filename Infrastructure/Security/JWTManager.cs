using Domain;

namespace Infrastructure.Security;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class JWTManager
{
    private readonly string _secret;
    private readonly TimeSpan _tokenLifetime;

    public JWTManager(string secret, TimeSpan tokenLifetime)
    {
        _secret = secret;
        _tokenLifetime = tokenLifetime;
    }

    public string GenerateToken(UserClaims claims, string secret, TimeSpan tokenLifetime)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, claims.Username),
                new Claim(ClaimTypes.Role, claims.Role)
            }),
            Expires = DateTime.UtcNow.Add(tokenLifetime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
