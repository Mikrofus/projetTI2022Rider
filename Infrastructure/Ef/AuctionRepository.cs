using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;

namespace Infrastructure.Ef;

public class AuctionRepository : IAuctionRepository
{
    private readonly ProjetTI2022ContextProvider _contextProvider;

    public AuctionRepository(ProjetTI2022ContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public DbAuction FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var auction = context.Auctions.FirstOrDefault(u => u.Id == id);

        if (auction == null) throw new KeyNotFoundException($"L'enchère n'a pas été trouvée");

        return auction;
    }

    public DbAuction Create(int id_user, string title, string category, string descri, string img, float price, DateTime timer)
    {
        using var context = _contextProvider.NewContext();
        var auction = new DbAuction
            {IdUser = id_user, Title = title, Category = category, Descri = descri, Img = img, Price = price, Timer = timer };
        
        context.Auctions.Add(auction);
        context.SaveChanges();
        return auction;
    }
}