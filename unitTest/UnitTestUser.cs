namespace unitTest;
using NUnit.Framework;
using Domain;

public class UnitTestUser
{
     [Test]
     public void TestUserProperties()
     {
         // Arrange
         var user = new User
          {
              Id = 1,
              Pseudo = "JohnDoe",
              Mail = "john@example.com",
              Pass = "password123"
          };
  
    
          // Assert
          Assert.AreEqual(1, user.Id);
          Assert.AreEqual("JohnDoe", user.Pseudo);
          Assert.AreEqual("john@example.com", user.Mail);
          Assert.AreEqual("password123", user.Pass);
     }
      
      [Test]
      public void TestUserEquals_DifferentData()
      {
          // Arrange
          var user1 = new User
          {
              Id = 1,
              Pseudo = "JohnDoe",
              Mail = "john@example.com",
              Pass = "password123"
          };
          var user2 = new User
          {
              Id = 2,
              Pseudo = "JaneDoe",
              Mail = "jane@example.com",
              Pass = "password456"
          };
      
          // Act
          bool areEqual = user1.Equals(user2);
      
          // Assert
          Assert.IsFalse(areEqual);
      }
      
       [Test]
        public void TestIsPseudovalid_Valid()
        {
            // Arrange
            var user = new User
            {
                 Pseudo = "JohnDoe"
             };
      
             // Act
             bool result = user.isPseudovalid();
      
             // Assert
             Assert.IsTrue(result);
        }
        
        [Test]
        public void TestIsPseudovalid_TooShort()
        {
            // Arrange
            var user = new User
            {
                Pseudo = "Jo"
            };
        
             // Act
             bool result = user.isPseudovalid();
        
             // Assert
             Assert.IsFalse(result);
        }
        
        [Test]
         public void TestIsPseudovalid_TooLong()
         {
             // Arrange
             var user = new User
              {
                   Pseudo = new string('a', 26)
              };
        
              // Act
              bool result = user.isPseudovalid();
        
              // Assert
              Assert.IsFalse(result);
         }
         
         [Test]
         public void TestIsEmailValid_Valid()
         {
              // Arrange
              var user = new User
              {
                Mail = "john@example.com"
              };
         
              // Act
              bool result = user.IsEmailValid();
         
              // Assert
              Assert.IsTrue(result);
         }
         
         [Test]
         public void TestIsEmailValid_Invalid()
         {
             // Arrange
             var user = new User
             {
                 Mail = "john@"
             };
         
             // Act
             bool result = user.IsEmailValid();
         
             // Assert
             Assert.IsFalse(result);
         }
       
         
          [Test]
          public void TestIsPasswordGood_Bad()
          {
                // Arrange
                var user = new User
                {
                     Pass = "password"
                };
             
                // Act
                bool result = user.IsPasswordGood();
         
                // Assert
                Assert.IsFalse(result);
          }  
          
}