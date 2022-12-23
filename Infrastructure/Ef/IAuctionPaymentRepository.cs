using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IAuctionPaymentRepository
{
    IEnumerable<DbAuctionPayment> FetchAll(int id);
}