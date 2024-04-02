using UserRegistrationServiceTest;

namespace UserRegistrationServiceTest
{
    [TestClass]
    public class UserTests
    {

        [TestMethod]
        public void AddUser_InvalidShortUsername_FailsRegistration()
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
        public void AddUser_InvalidUsernameTooManyLetters_FailsRegistration()
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
        public void AddUser_InvalidAlphanumericCharactersCanNotBeIncluded_FailsRegistration()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string invalidCharactersUsername = "abc$123"; // non-alphanumeric characters


            // Act
            bool result = registrationService.IsAlphanumeric(invalidCharactersUsername);
            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to invalid characters in username.");
        }


        [TestMethod]
        public void AddUser_ValidUsernameWithRightAmountOfLetters_SuccessfulRegistration()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string validUsername = "validuser"; // valid username

            // Act
            bool result = registrationService.AddUser(validUsername);

            // Assert
            Assert.IsTrue(result, "Expected user registration to succeed with valid username.");
        }



        [TestMethod]
        public void AddUser_ValidPassword_SuccessfulRegistration()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string username = "validuser";
            string validPassword = "password123!"; // valid password
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(username, validPassword, email);

            // Assert
            Assert.IsTrue(result, "Expected user registration to succeed with valid password.");
        }

        [TestMethod]
        public void AddUser_InvalidPassword_TooShort_FailsRegistration()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string username = "testuser";
            string invalidPassword = "pas"; // Password is too short
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(username, invalidPassword, email);

            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to invalid password length.");
        }

        [TestMethod]
        public void AddUser_InvalidPassword_NoSpecialCharacter_FailsRegistration()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string username = "testuser";
            string invalidPassword = "password123"; // Password does not contain any special character
            string email = "test@example.com";

            // Act
            bool result = registrationService.AddUser(username, invalidPassword, email);

            // Assert
            Assert.IsFalse(result, "Expected user registration to fail due to missing special character in password.");
        }
        [TestMethod]
        public void AddUser_ValidEmailFormatWithAtSymbol_PassesValidation()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string validEmail = "test@example.com";

            // Act: Försök validera en giltig e-postadress
            bool result = registrationService.IsEmailValid(validEmail);

            // Assert: Förvänta dig att e-postadressen valideras som giltig
            Assert.IsTrue(result, "Expected email validation to pass for valid format.");
        }

        [TestMethod]
        public void AddUser_InvalidEmailFormatWithoutAtSymbol_FailsValidation()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string invalidEmail = "test.example.com";

            // Act: Försök validera en ogiltig e-postadress
            bool result = registrationService.IsEmailValid(invalidEmail);

            // Assert: Förvänta dig att e-postadressen valideras som ogiltig
            Assert.IsFalse(result, "Expected email validation to fail for invalid format.");
        }

    }
}