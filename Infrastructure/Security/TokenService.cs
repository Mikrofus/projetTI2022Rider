using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Ef.DTOs;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Win32.SafeHandles;

namespace Infrastructure.Security;

public class TokenService : ITokenService
{
 
    private readonly ProjetTI2022ContextProvider _contextProvider;

    public TokenService(ProjetTI2022ContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public string BuildToken(string key, string issuer, DtoOutputUser user)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string key, string issuer, string audience, string token)
    {
        throw new NotImplementedException();
    }

    public DbUser Authentification(DtoLoginUser dto)
    {
        using var context = _contextProvider.NewContext();
       
        
        
        var user = context.Users.Where(u => u.Mail.ToUpper() == dto.Mail.ToUpper()).FirstOrDefault();

        if (BCrypt.Net.BCrypt.Verify(dto.Password, user.Pass))
        {
            return user;
        }
    
        return null;
    }
}