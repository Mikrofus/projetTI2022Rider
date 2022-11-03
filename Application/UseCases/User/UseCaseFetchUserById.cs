using Application.UseCases.User.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.User;

public class UseCaseFetchUserById
{
    private readonly IUserRepository _userRepository;

    public UseCaseFetchUserById(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public DtoOutputUser Execute(int id)
    {
        var dbUser = _userRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}