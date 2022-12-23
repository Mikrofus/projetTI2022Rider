using Application.UseCases.AuctionPayment.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.AuctionPayment;

public class UseCaseDeleteAuctionPayment
{
    private readonly IAuctionPaymentRepository _auctionPaymentRepository;

    public UseCaseDeleteAuctionPayment(IAuctionPaymentRepository auctionPaymentRepository)
    {
        _auctionPaymentRepository = auctionPaymentRepository;
    }


    public DtoOutPutAuctionPayment Execute(int id)
    {
        var dbAuctionPayment =  _auctionPaymentRepository.Delete(id);
        
        return Mapper.GetInstance().Map<DtoOutPutAuctionPayment>(dbAuctionPayment);
    }
}