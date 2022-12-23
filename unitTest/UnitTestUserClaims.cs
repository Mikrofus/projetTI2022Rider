namespace unitTest;
using NUnit.Framework;
using Domain;

public class UnitTestUserClaims
{
    [Test]
    public void TestUserClaimsProperties()
    {
        // Arrange
        var userClaims = new UserClaims
        {
            Username = "john.doe",
            Role = "admin"
        };
        

        // Assert
        Assert.AreEqual("john.doe", userClaims.Username);
        Assert.AreEqual("admin", userClaims.Role);
    }
    
    [Test]
    public void TestUserClaims_EmptyUsername()
    {
        // Arrange
        var userClaims = new UserClaims
        {
            Username = "",
            Role = "admin"
        };

        // Act

        // Assert
        Assert.AreEqual("", userClaims.Username);
    }

}