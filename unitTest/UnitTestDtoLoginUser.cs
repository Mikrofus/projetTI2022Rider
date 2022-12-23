namespace unitTest;
using NUnit.Framework;
using Domain.Dto.UserDTO;

public class UnitTestDtoLoginUser
{
    [Test]
    public void TestDtoLoginUserProperties()
    {
        // Arrange
        var dto = new DtoLoginUser
        {
            Mail = "john@example.com",
            Password = "P@ssw0rd!"
        };

        // Act

        // Assert
        Assert.AreEqual("john@example.com", dto.Mail);
        Assert.AreEqual("P@ssw0rd!", dto.Password);
    }
}