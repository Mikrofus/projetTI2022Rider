using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class AuctionRepository : IAuctionRepository
{
    private readonly ProjetTI2022ContextProvider _contextProvider;

    public AuctionRepository(ProjetTI2022ContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }


    public IEnumerable<DbAuction> FetchAll()
    {
        var context = _contextProvider.NewContext();
        return context.Auctions.ToList();
    }

    public DbAuction FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var auction = context.Auctions.FirstOrDefault(u => u.Id == id);

        if (auction == null) throw new KeyNotFoundException($"L'enchère n'a pas été trouvée");

        return auction;
    }

    public DbAuction Create(int id_user, string title, string category, string descri, string img, decimal price, int id_user_bid, DateTime timer)
    {
        using var context = _contextProvider.NewContext();
        var auction = new DbAuction
            {IdUser = id_user, Title = title, Category = category, Descri = descri, Img = img, Price = price, IdUserBid = id_user_bid,Timer = timer };
        
        context.Auctions.Add(auction);
        context.SaveChanges();
        return auction;
    }

    public DbAuction SetTopBid(int id, decimal price, int idUserBid)
    {
        using var context = _contextProvider.NewContext();
        
        var entity = context.Auctions.FirstOrDefault(a => a.Id == id);

        if (entity == null)
            return null;

        entity.Price = price;
        entity.IdUserBid = 1;

        context.SaveChanges();

        return entity;

    }

    public DbAuction Delete(int id)
    {
        using var context = _contextProvider.NewContext();

        var auction = FetchById(id);

        try
        {
            context.Remove(auction);
            context.SaveChanges();
            return auction;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return null;
        }
    }


}