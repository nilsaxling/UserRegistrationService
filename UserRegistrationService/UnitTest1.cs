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
            if (result)
            {
                Assert.Fail("Expected user registration to fail due to invalid characters in username.");
            }
            else
            {
                Console.WriteLine("Invalid username. Username can only contain alphanumeric characters.");
            }
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

            // Act: Attempt to validate a valid email address
            bool result = registrationService.IsEmailValid(validEmail);

            // Assert: Expect the email address to be validated as valid
            Assert.IsTrue(result, "Expected email validation to pass for valid format.");
        }

        [TestMethod]
        public void AddUser_InvalidEmailFormatWithoutAtSymbol_FailsValidation()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string invalidEmail = "test.example.com";

            // Act: Attempt to validate an invalid email address
            bool result = registrationService.IsEmailValid(invalidEmail);
            

            if (result)
            {
                Assert.Fail("Expected email validation to fail for invalid format.");
            }
            else
            {
                Console.WriteLine("Invalid email. Email must contain the '@' symbol.");
            }
            // Assert: Expect the email address to fail validation for invalid format
            Assert.IsFalse(result, "Expected email validation to fail for invalid format.");
            
        }
        [TestMethod]
        public void AddUser_UniqueUsername_NewUsername_PassesValidation()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();
            string newUsername = "newuser"; // Username that doesn't already exist

            // Act
            bool result = registrationService.AddUser(newUsername);

            // Assert
            Assert.IsTrue(result, "Expected user registration to pass for a unique username.");

            // Check that the user has actually been added to the list
            Assert.IsTrue(registrationService.IsUsernameTaken(newUsername), "Expected the new username to be added to the list.");
        }


        [TestMethod]
        public void AddUser_UniqueUsername_ExistingUsername_FailsValidation()
        {
            // Arrange
            RegistrationService registrationService = new RegistrationService();

            var username1 = new User("Nilsaxling", "korvkiosk!", "nils@gmail.com"); // Skapar en användare med specifika uppgifter.
            var username2 = new User("Nilsaxling", "korvkiosk!", "nils@gmail.com"); // Skapar en annan användare med samma uppgifter.

            // Act
            bool firstAttemptResult = registrationService.AddUser(username1.Username); // Försök lägga till den första användaren
            bool secondAttemptResult = registrationService.AddUser(username2.Username); // Försök lägga till samma användare igen

            // Assert
            Assert.IsTrue(firstAttemptResult, "Första försöket att lägga till användaren ska lyckas.");
            Assert.IsFalse(secondAttemptResult, "Andra försöket att lägga till användaren med befintligt användarnamn ska misslyckas.");
        }


    }

}
