using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;

namespace Infrastructure.Ef;

public class UserRepository : IUserRepository
{
    private readonly ProjetTI2022ContextProvider _contextProvider;

    public UserRepository(ProjetTI2022ContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public DbUser FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var user = context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null) throw new KeyNotFoundException($"L'utilisateur n'a pas été trouvé");

        return user;
    }

    public DbUser Create(string nom, string prenom)
    {
        using var context = _contextProvider.NewContext();
        var user = new DbUser{Nom = nom, Prenom = prenom};
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}