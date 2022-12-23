namespace unitTest;
using NUnit.Framework;
using Domain;

public class UnitTestAuction
{
    [Test]
    public void TestAuctionProperties()
    {
        // Arrange
        var auction = new Auction
        {
            Id = 1,
            IdUser = 2,
            Title = "My Auction",
            Category = "Collectibles",
            Descri = "This is a description of my auction.",
            Img = new byte[] { 0x01, 0x02, 0x03 },
            Price = 50.0f,
            IdUserBid = 3,
            Timer = new DateTime(2022, 1, 1)
        };
        

        // Assert
        Assert.AreEqual(1, auction.Id);
        Assert.AreEqual(2, auction.IdUser);
        Assert.AreEqual("My Auction", auction.Title);
        Assert.AreEqual("Collectibles", auction.Category);
        Assert.AreEqual("This is a description of my auction.", auction.Descri);
        Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, auction.Img);
        Assert.AreEqual(50.0f, auction.Price);
        Assert.AreEqual(3, auction.IdUserBid);
        Assert.AreEqual(new DateTime(2022, 1, 1), auction.Timer);
    }
    
    [Test]
    public void TestHasManyWords_LongDescription()
    {
        // Arrange
        var auction = new Auction();
        auction.Descri = "This is a description that contains a large number of words. It has more than 10 words, and it is very long and detailed. It covers multiple topics and provides a lot of information.";

        // Act
        var hasManyWords = auction.HasManyWords();

        // Assert
        Assert.IsTrue(hasManyWords);
    }
    
    [Test]
    public void TestIsValidDateTime_ValidDateTime()
    {
        // Arrange
        var auction = new Auction()
        {
            Timer = DateTime.Now
        };

        // Act
        var isValid = auction.IsValidDateTime();

        // Assert
        Assert.IsTrue(isValid);
    }
    
    [Test]
    public void TestIsValidDateTime_InvalidDateTime()
    {
        // Arrange
        var auction = new Auction()
        {
            Timer = default(DateTime)
        };

        // Act
        var isValid = auction.IsValidDateTime();

        // Assert
        Assert.IsFalse(isValid);
    }
    
    [Test]
    public void TestIsValidDateTime_MaxDateTime()
    {
        // Arrange
        var auction = new Auction()
        {
            Timer = DateTime.MaxValue
        };

        // Act
        var isValid = auction.IsValidDateTime();

        // Assert
        Assert.IsTrue(isValid);
    }
    
    [Test]
    public void TestIsValidDateTime_DateTimeWithTime()
    {
        // Arrange
        var auction = new Auction()
        {
            Timer = new DateTime(2020, 01, 01, 12, 00, 00)
        };

        // Act
        var isValid = auction.IsValidDateTime();

        // Assert
        Assert.IsTrue(isValid);
    }
    
    [Test]
    public void TestIsValidPrice_ValidPrice()
    {
        // Arrange
        var auction = new Auction()
        {
            Price = 100.0f
        };

        // Act
        var isValid = auction.IsValidPrice();

        // Assert
        Assert.IsTrue(isValid);
    }
    
    [Test]
    public void TestIsValidPrice_PriceTooLow()
    {
        // Arrange
        var auction = new Auction()
        {
            Price = 0.0f
        };

        // Act
        var isValid = auction.IsValidPrice();

        // Assert
        Assert.IsFalse(isValid);
    }
    
    [Test]
    public void TestIsValidPrice_PriceTooHigh()
    {
        // Arrange
        var auction = new Auction()
        {
            Price = 100001.0f
        };

        // Act
        var isValid = auction.IsValidPrice();

        // Assert
        Assert.IsFalse(isValid);
    }
    
    [Test]
    public void TestIsValidTitle_ValidTitle()
    {
        // Arrange
        var auction = new Auction()
        {
            Title = "My Auction"
        };

        // Act
        var isValid = auction.IsValidTitle();

        // Assert
        Assert.IsTrue(isValid);
    }

    [Test]
    public void TestIsValidTitle_EmptyTitle()
    {
        // Arrange
        var auction = new Auction()
        {
            Title = string.Empty
        };

        // Act
        var isValid = auction.IsValidTitle();

        // Assert
        Assert.IsFalse(isValid);
    }

    [Test]
    public void TestIsValidTitle_NullTitle()
    {
        // Arrange
        var auction = new Auction()
        {
            Title = null
        };

        // Act
        var isValid = auction.IsValidTitle();

        // Assert
        Assert.IsFalse(isValid);
    }
    
    
}