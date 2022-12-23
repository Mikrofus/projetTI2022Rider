using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Auction.Dto;

public class DtoInputUpdateAuction
{
    [Required] public int Id { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] public int IdUserBid { get; set; }
}