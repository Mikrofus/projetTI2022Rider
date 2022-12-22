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
}