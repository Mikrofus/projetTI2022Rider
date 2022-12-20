using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IAuctionRepository
{

    IEnumerable<DbAuction> FetchAll();

    DbAuction FetchById(int id);

    DbAuction Create(int id_user, string title, string category, string descri, string img, decimal price, int id_user_bid, DateTime timer);

    DbAuction SetTopBid(DbAuction auction);

    DbAuction Delete(int id);

}