using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Ef.DbEntities;

public class DbAuctionPayment
{
    public int Id { get; set; }
    [ForeignKey("IdUser")]
    public int IdUser { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
}