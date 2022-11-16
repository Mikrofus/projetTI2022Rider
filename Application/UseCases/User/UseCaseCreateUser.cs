using Application.UseCases.User.Dto;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Application.UseCases.User;

public class UseCaseCreateUser : IUseCaseWriter<DtoOutputUser, DtoInputCreateUser>
{
    private readonly IUserRepository _userRepository;

    public UseCaseCreateUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public DtoOutputUser Execute(DtoInputCreateUser input)
    {
        var dbUser = _userRepository.Create(input.Pseudo, input.Mail, input.Pass);
        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}