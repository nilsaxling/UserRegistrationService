using System;
using System.Collections.Generic;
using System.Linq;

public class RegistrationService
{
    private List<User> users = new List<User>(); // List to store users

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

        // Add user to the list of users
        users.Add(new User(username, "", ""));
        Console.WriteLine("User added successfully.");
        return true;
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
            Console.WriteLine("Invalid email address.");
            return false;
        }

        // Check if the username is already taken
        if (IsUsernameTaken(username))
        {
            Console.WriteLine("Username already taken. Please choose a different username.");
            return false;
        }

        // Add user to the list of users
        users.Add(new User(username, password, email));
        Console.WriteLine("User added successfully.");
        return true;
    }

    // Method to check if the username is valid
    public bool IsUsernameValid(string username)
    {
        return username.Length >= 5 && username.Length <= 20 && IsAlphanumeric(username);
    }

    // Method to check if the string contains only alphanumeric characters
    public bool IsAlphanumeric(string str)
    {
        return str.All(char.IsLetterOrDigit);
    }

    // Method to check if the password is valid
    public bool IsPasswordValid(string password)
    {
        return password.Length >= 8 && password.Any(char.IsLetterOrDigit) && password.Any(c => !char.IsLetterOrDigit(c));
    }

    // Method to check if the email address is valid
    public bool IsEmailValid(string email)
    {
        // Perform email validation logic here
        // For simplicity, let's assume any string containing "@" is considered valid
        return email.Contains("@");
    }

    // Method to check if the username is already taken
    public bool IsUsernameTaken(string username)
    {
        return users.Any(u => u.Username == username);
    }
}
