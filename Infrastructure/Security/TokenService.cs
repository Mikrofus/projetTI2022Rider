using Infrastructure.Ef.DTOs;

namespace Infrastructure.Security;

public class TokenService : ITokenService
{
    public string BuildToken(string key, string issuer, UserDTO user)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string key, string issuer, string audience, string token)
    {
        throw new NotImplementedException();
    }
}