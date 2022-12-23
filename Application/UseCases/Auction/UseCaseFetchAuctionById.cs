using Application.UseCases.Auction.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.Auction;

public class UseCaseFetchAuctionById
{
    private readonly IAuctionRepository _auctionRepository;


    public UseCaseFetchAuctionById(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public DtoOutputAuction Execute(int id)
    {
        var dbAuction = _auctionRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputAuction>(dbAuction);
    }
}