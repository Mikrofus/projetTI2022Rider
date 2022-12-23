namespace Application.UseCases.AuctionPayment.Dto;

public class DtoOutPutAuctionPayment
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
}