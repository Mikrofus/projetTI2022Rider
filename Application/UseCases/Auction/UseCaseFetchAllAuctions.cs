using Application.UseCases.Auction.Dto;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Auction;

public class UseCaseFetchAllAuctions : IUseCaseQuery<IEnumerable<DtoOutputAuction>>
{
    private readonly IAuctionRepository _auctionRepository;

    public UseCaseFetchAllAuctions(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public IEnumerable<DtoOutputAuction> Exectue()
    {
        var auctions = _auctionRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputAuction>>(auctions);
    }
}