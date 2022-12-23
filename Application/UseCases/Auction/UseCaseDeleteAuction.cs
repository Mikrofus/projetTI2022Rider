using Application.UseCases.Auction.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.Auction;

public class UseCaseDeleteAuction
{
    private readonly IAuctionRepository _auctionRepository;

    public UseCaseDeleteAuction(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }
    
    
    public DtoOutputAuction Execute(int id)
    {
        var dbAuction = _auctionRepository.Delete(id);

        return Mapper.GetInstance().Map<DtoOutputAuction>(dbAuction);
    }

}