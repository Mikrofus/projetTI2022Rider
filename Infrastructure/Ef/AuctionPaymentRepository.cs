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
}