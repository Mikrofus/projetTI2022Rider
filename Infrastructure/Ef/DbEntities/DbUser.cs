namespace Infrastructure.Ef.DbEntities;

public class DbUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Mail { get; set; }
    public string Pass { get; set; }
}