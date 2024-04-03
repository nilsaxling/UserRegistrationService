using System;
using System.Collections.Generic;
using System.Linq;

public class RegistrationService
{
    private List<User> Users { get; set; } = new List<User>();

    // Method to Add user with only a username
    public bool AddUser(string username)
    {
        // Validate the username format
        if (!IsUsernameValid(username))
        {
            Console.WriteLine("Invalid username. Username must be between 5 and 20 characters long and contain only alphanumeric characters.");
            return false;
        }

        // Check if the username is already taken
        if (IsUsernameTaken(username))
        {
            Console.WriteLine("Username already taken. Please choose a different username.");
            return false;
        }
        else
        {
            // Add user without password and email
            Users.Add(new User(username, "", ""));
            Console.WriteLine("User added successfully.");
            return true;
        }
    }


    // Method to Add user with username, password, and email validation
    public bool AddUser(string username, string password, string email)
    {
        // Validate username
        if (!IsUsernameValid(username))
        {
            Console.WriteLine("Invalid username. Username must be between 5 and 20 characters long and contain only alphanumeric characters.");
            return false;
        }

        // Validate the password
        if (!IsPasswordValid(password))
        {
            Console.WriteLine("Invalid password. Password must be at least 8 characters long and contain at least one special character.");
            return false;
        }

        // Validate email address
        if (!IsEmailValid(email))
        {
            Console.WriteLine("Invalid email address. Email");
            return false;
        }

        // Add user
        Users.Add(new User(username, password, email));
        Console.WriteLine("User added successfully.");
        return true;
    }

    // Check if the password meets the following criteria:
    public bool IsUsernameValid(string username)
    {
        return username.Length >= 5 && username.Length <= 20 && IsAlphanumeric(username);
    }

    // Check if the string contains only alphanumeric characters
    public bool IsAlphanumeric(string str)
    {
        return str.All(char.IsLetterOrDigit);
    }

    // Check if the password meets the following criteria:
    public bool IsPasswordValid(string password)
    {
        return password.Length >= 8 && password.Any(char.IsLetterOrDigit) && password.Any(c => !char.IsLetterOrDigit(c));
    }

    // Check if the email address contains the "@" symbol
    public bool IsEmailValid(string email)
    {
        // Check if the email address contains the "@" symbol
        if (email.Contains("@"))
        {
            // If the email address contains the "@" symbol, it is considered valid
            return true;
        }
        else
        {
            // Otherwise, it is considered invalid
            return false;
        }
    }

    // This method checks if the given username is already in use.
    public bool IsUsernameTaken(string username)
    {
        return Users.Any(u => u.Username == username);
    }

}




