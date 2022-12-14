using Application.UseCases.Utils;
using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.User;

public class UseCaseFetchAllUsers : IUseCaseQuery<IEnumerable<DtoOutputUser>>
{
    private readonly IUserRepository _userRepository;

    public UseCaseFetchAllUsers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    

    public IEnumerable<DtoOutputUser> Exectue()
    {
        var dbUsers = _userRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputUser>>(dbUsers);
    }
}