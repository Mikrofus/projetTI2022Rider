namespace unitTest;
using NUnit.Framework;
using Domain.Dto.UserDTO;

public class UnitTestDtoOutputUser
{
    [Test]
    public void TestDtoOutputUserProperties()
    {
        // Arrange
        var dto = new DtoOutputUser
        {
            Id = 1,
            Pseudo = "john.doe",
            Mail = "john@example.com",
            Pass = "P@ssw0rd!"
        };

        // Assert
        Assert.AreEqual(1, dto.Id);
        Assert.AreEqual("john.doe", dto.Pseudo);
        Assert.AreEqual("john@example.com", dto.Mail);
        Assert.AreEqual("P@ssw0rd!", dto.Pass);
    }
}