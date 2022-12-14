using Application.UseCases.Auction.Dto;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Auction;

public class UseCaseCreateAuction : IUseCaseWriter<DtoOutputAuction, DtoInputCreateAuction>
{
    private readonly IAuctionRepository _auctionRepository;

    public UseCaseCreateAuction(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }


    public DtoOutputAuction Execute(DtoInputCreateAuction input)
    {
        var dbAuction = _auctionRepository.Create(input.IdUser, input.Title, input.Category, input.Descri, input.Img,
            input.Price,input.IdUserBid, input.Timer);

        return Mapper.GetInstance().Map<DtoOutputAuction>(dbAuction);
    }
}