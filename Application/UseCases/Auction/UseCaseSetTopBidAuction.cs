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

    public bool Execute(DbAuction auction)
    {

        return _auctionRepository.SetTopBid(auction);

    }
}