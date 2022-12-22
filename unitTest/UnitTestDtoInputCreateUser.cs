namespace unitTest;
using NUnit.Framework;
using Domain.Dto.UserDTO;


public class UnitTestDtoInputCreateUser
{
    [Test]
    public void TestDtoInputCreateUserProperties()
    {
        // Arrange
        var dto = new DtoInputCreateUser
        {
            Pseudo = "john.doe",
            Mail = "john@example.com",
            Pass = "P@ssw0rd!"
        };

        // Act

        // Assert
        Assert.AreEqual("john.doe", dto.Pseudo);
        Assert.AreEqual("john@example.com", dto.Mail);
        Assert.AreEqual("P@ssw0rd!", dto.Pass);
    }
}