﻿using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef.DTOs;

namespace Infrastructure.Security;

public class TokenService : ITokenService
{
    public string BuildToken(string key, string issuer, DtoOutputUser user)
    {
        throw new NotImplementedException();
    }

    public bool ValidateToken(string key, string issuer, string audience, string token)
    {
        throw new NotImplementedException();
    }
}