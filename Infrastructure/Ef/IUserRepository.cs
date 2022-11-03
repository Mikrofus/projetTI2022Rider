using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IUserRepository
{
    DbUser FetchById(int id);

    DbUser Create(string nom, string prenom);
}