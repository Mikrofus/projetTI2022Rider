using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IAuctionPaymentRepository
{
    IEnumerable<DbAuctionPayment> FetchAll(int id);

    DbAuctionPayment FetchById(int id);
    
    DbAuctionPayment Create(int id_user, string title, decimal price);

    DbAuctionPayment Delete(int id);
}