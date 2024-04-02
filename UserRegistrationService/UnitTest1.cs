using UserRegistrationServiceTest;

namespace UserRegistrationServiceTest
{
    [TestClass]
    public class UserTests
    {

        [TestMethod]
        public void AddUser_InvalidShortUsername()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string shortUsername = "abcd"; // too short
            string password = "password123";
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(shortUsername, password, email);

            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to short username.");
        }

        [TestMethod]
        public void AddUser_InvalidLongUsername()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string longUsername = "abcdefghijklmnopqrstu"; // too long
            string password = "password123";
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(longUsername, password, email);

            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to long username.");
        }

        [TestMethod]
        public void AddUser_InvalidNonAlphanumericCharacters()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string invalidCharactersUsername = "abc$123"; // non-alphanumeric characters


            // Act
            bool result = registrationService.IsAlphanumeric(invalidCharactersUsername);
            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to invalid characters in username.");
        }

        //[TestMethod]
        //public void AddUser_ValidUsername()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string validUsername = "validuserrrr"; // valid username
        //    string password = "password12345";
        //    string email = "mail@example.com";

        //    // Act
        //    bool result = registrationService.AddUser(validUsername, password, email);


        //    // Assert
        //    Assert.IsTrue(result, "Expected user registration to succeed with valid username.");
        //}
   
 

        [TestMethod]
        public void AddUser_InvalidPassword_TooShort_Failure()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string username = "testuser";
            string password = "pas"; // Lösenordet är för kort
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(username, password, email);

            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to invalid password length.");
        }


        //[TestMethod]
        //public void AddUser_ValidUser_Success()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string username = "NilsAxling";
        //    string password = "password1234";
        //    string email = "hallo@hotmail.com"; 

        //    // Act
        //    bool result = registrationService.AddUser(username, password, email);
        //    bool removeResult = registrationService.RemoveUser(username); // Ta bort användaren efter testet


        //    // Assert
        //    Assert.IsTrue(result, "Expected user registration to succeed.");
        //    Assert.IsTrue(registrationService.IsUsernameTaken(username), "Expected username to be taken after registration.");
        //    Assert.IsTrue(removeResult, "Failed to remove user.");

        //}

        //[TestMethod]
        //public void AddUser_ExistingUsername_Failure()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string existingUsername = "existinguser";
        //    string password = "password123";
        //    string email = "existing@example.com";
        //    registrationService.AddUser(existingUsername, password, email); 

        //    // Act
        //    bool result = registrationService.AddUser(existingUsername, "NewPassword123!", "new@example.com");

        //    // Assert
        //    Assert.IsFalse(result, "Expected user registration to fail due to existing username.");
        //}






        //[TestMethod]
        //public void AddUser_InvalidUsername_TooShort()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string username = "abc"; // Too short
        //    string password = "password123";
        //    string email = "test@example.com";

        //    // Act
        //    bool result = registrationService.AddUser(username, password, email);

        //    // Assert
        //    Assert.IsFalse(result);
        //}

        //[TestMethod]
        //public void AddUser_InvalidUsername_TooLong()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string username = "abcdefghijklmnopqrstu"; // Too long
        //    string password = "password123";
        //    string email = "test@example.com";

        //    // Act
        //    bool result = registrationService.AddUser(username, password, email);

        //    // Assert
        //    Assert.IsFalse(result);
        //}

        //[TestMethod]
        //public void AddUser_NonAplhanumeric()
        //{
        //    // Arrange
        //    RegistrationService registrationService = new RegistrationService();
        //    string username = "abc$123";
        //    string password = "password123";
        //    string email = "test@example.com";

        //    // Act
        //    bool result = registrationService.AddUser(username, password, email);

        //    // Assert
        //    Assert.IsFalse(result);

        //}
    }
}