using Infrastructure.Ef.DTOs;

namespace Infrastructure.Security;

public interface ITokenService
{
    string BuildToken(string key, string issuer, UserDTO user);
    bool ValidateToken(string key, string issuer, string audience, string token);
}