using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbUser
{
    public int Id { get; set; }
    [Required]
    public string Pseudo { get; set; }
    [Required]
    public string Mail { get; set; }
    [Required]
    public string Pass { get; set; }
}