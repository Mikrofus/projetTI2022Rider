using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.AuctionPayment.Dto;

public class DtoInputCreateAuctionPayment
{
    [Required] public int IdUser { get; set; }
    [Required] public string Title { get; set; }
    [Required] public decimal Price { get; set; }
}