using Domain.Dto.UserDTO;
using Infrastructure.Security;

namespace Application.UseCases.User;

public class UseCaseLogin
{
    private readonly ITokenService _tokenService;

    public UseCaseLogin(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public DtoOutputUser Execute(DtoLoginUser dto)
    {
        var dbUser = _tokenService.Authentification(dto);
        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}