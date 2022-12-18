﻿

using Infrastructure.Ef.DTOs;

namespace Infrastructure.Security;

public interface ITokenService
{
    string BuildToken(string key, string issuer, DtoOutputUser user);
    bool ValidateToken(string key, string issuer, string audience, string token);
}