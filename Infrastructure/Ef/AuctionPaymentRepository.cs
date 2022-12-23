using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;

namespace Infrastructure.Ef;

public class AuctionPaymentRepository : IAuctionPaymentRepository
{
    private readonly ProjetTI2022ContextProvider _contextProvider;

    public AuctionPaymentRepository(ProjetTI2022ContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public IEnumerable<DbAuctionPayment> FetchAll(int id)
    {
        var context = _contextProvider.NewContext();
        
        return context.AuctionPayments.Where(u => u.IdUser == id).ToList();
        

    }

    public DbAuctionPayment Create(int id_user, string title, decimal price)
    {
        using var context = _contextProvider.NewContext();
        
   
        var auction = new DbAuctionPayment
        {
            IdUser = id_user, Title = title, Price = price
        };

        context.AuctionPayments.Add(auction);
        context.SaveChanges();
        return auction;
    }
    
    public DbAuctionPayment FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var auctionPayment = context.AuctionPayments.FirstOrDefault(u => u.Id == id);

        if (auctionPayment == null) throw new KeyNotFoundException($"L'enchère n'a pas été trouvée");

        return auctionPayment;
    }
}