﻿using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public interface IAuctionRepository
{

    IEnumerable<DbAuction> FetchAll();

    DbAuction FetchById(int id);

    DbAuction Create(int id_user, string title, string category, string descri, string pathImg, decimal price, int id_user_bid, DateTime timer);

    DbAuction SetTopBid(int id, decimal price, int idUserBid);

    DbAuction Delete(int id);

}