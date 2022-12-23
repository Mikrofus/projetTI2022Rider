using Application.UseCases.AuctionPayment.Dto;
using Infrastructure.Ef;

namespace Application.UseCases.AuctionPayment;

public class UseCaseFetchAllAuctionPayment
{
    private readonly IAuctionPaymentRepository _auctionPaymentRepository;

    public UseCaseFetchAllAuctionPayment(IAuctionPaymentRepository auctionPaymentRepository)
    {
        _auctionPaymentRepository = auctionPaymentRepository;
    }

    public IEnumerable<DtoOutPutAuctionPayment> Execute(int id)
    {
        var dbAuctionPayment = _auctionPaymentRepository.FetchAll(id);

        return Mapper.GetInstance().Map<IEnumerable<DtoOutPutAuctionPayment>>(dbAuctionPayment);
    }
}