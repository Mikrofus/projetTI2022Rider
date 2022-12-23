using Application.UseCases.Auction.Dto;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Auction;

public class UseCaseSetTopBidAuction
{
    public readonly IAuctionRepository _auctionRepository;

    public UseCaseSetTopBidAuction(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public DtoOutputAuction Execute(int id, decimal price, int idUserBid)
    {

        var dbAuction = _auctionRepository.SetTopBid(id, price, idUserBid);
        
        return Mapper.GetInstance().Map<DtoOutputAuction>(dbAuction);

    }
}