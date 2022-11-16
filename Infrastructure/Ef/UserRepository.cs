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

    public DbUser Create(string pseudo, string mail, string pass)
    {
        using var context = _contextProvider.NewContext();
        var user = new DbUser{Pseudo = pseudo, Mail = mail, Pass = pass};
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}