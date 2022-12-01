using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Auction.Dto;

public class DtoInputCreateAuction
{
    [Required] public int IdUser { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Category { get; set; }
    [Required] public string Descri { get; set; }
    [Required] public string Img { get; set; }
    [Required] public decimal Price { get; set; }
    [Required] public DateTime Timer { get; set; } 
}