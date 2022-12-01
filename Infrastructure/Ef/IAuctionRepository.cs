using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IAuctionRepository
{
    DbAuction FetchById(int id);

    DbAuction Create(int id_user, string title, string category, string descri, string img, decimal price, DateTime timer);
    
}