namespace Domain;

public class Auction
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Descri { get; set; }
    public byte[] Img { get; set; }
    public float Price { get; set; }
    public int IdUserBid { get; set; }
    public DateTime Timer { get; set; } 
    
    public bool HasManyWords()
    {
        // Split the description into words using the Split method
        var words = Descri.Split(' ');

        // Count the number of words using the Length property of the resulting array
        var wordCount = words.Length;

        // Return true if the number of words is greater than or equal to the desired minimum
        return wordCount >= 10;
    }

    public bool IsValidDateTime()
    {
        // Check if the date time is not equal to the default value of DateTime 
        return Timer != default(DateTime);
    }
    
    public bool IsValidPrice()
    {
        return Price >= 1 && Price <= 100000;
    }
    
    public bool IsValidTitle()
    {
        return !string.IsNullOrEmpty(Title);
    }

    
}