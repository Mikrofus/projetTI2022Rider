using Application.UseCases.AuctionPayment.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.AuctionPayment;

public class UseCaseCreateAuctionPayment
{
    private readonly IAuctionPaymentRepository _auctionPaymentRepository;

    public UseCaseCreateAuctionPayment(IAuctionPaymentRepository auctionPaymentRepository)
    {
        _auctionPaymentRepository = auctionPaymentRepository;
    }
    
    public DtoOutPutAuctionPayment Execute(DtoInputCreateAuctionPayment input)
    {
        var dbAuctionPayment = _auctionPaymentRepository.Create(input.IdUser, input.Title, input.Price);

        return Mapper.GetInstance().Map<DtoOutPutAuctionPayment>(dbAuctionPayment);
    }
}