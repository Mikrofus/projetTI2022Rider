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

    public byte[] TransfoImage(string PathFile)
    {
        
        using (FileStream stream = new FileStream(PathFile, FileMode.Open))
        {
            byte[] image = new byte[stream.Length];
            stream.Read(image, 0, (int)stream.Length);
            return image;
        }
    }

    public DbAuction Create(int id_user, string title, string category, string descri, byte[] pathImage, decimal price,
        int id_user_bid, DateTime timer)
    {
        using var context = _contextProvider.NewContext();
        
        if (price > 0 && timer > DateTime.Now)
        {
            var auction = new DbAuction
            {
                IdUser = id_user, Title = title, Category = category, Descri = descri, Img = pathImage, Price = price,
                IdUserBid = id_user_bid, Timer = timer
            };
            context.Auctions.Add(auction);
            context.SaveChanges();
            return auction;
        }


        return null;

    }

    public DbAuction SetTopBid(int id, decimal price, int idUserBid)
    {
        using var context = _contextProvider.NewContext();

        var entity = context.Auctions.FirstOrDefault(a => a.Id == id);

        if (entity == null)
            return null;

        if (price > entity.Price)
        {
            entity.Price = price;
            entity.IdUserBid = idUserBid;
        }
        

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