using Application.UseCases.AuctionPayment.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.AuctionPayment;

public class UseCaseFetchByIdAuctionPayment
{
    private readonly IAuctionPaymentRepository _auctionPaymentRepository;

    public UseCaseFetchByIdAuctionPayment(IAuctionPaymentRepository auctionPaymentRepository)
    {
        _auctionPaymentRepository = auctionPaymentRepository;
    }
    
    
    public DtoOutPutAuctionPayment Execute(int id)
    {
        var dbAuctionPayment = _auctionPaymentRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutPutAuctionPayment>(dbAuctionPayment);
    }
}