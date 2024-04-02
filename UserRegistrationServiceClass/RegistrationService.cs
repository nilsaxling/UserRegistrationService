﻿using System;
using System.Collections.Generic;
using System.Linq;

public class RegistrationService
{
    private List<User> Users { get; set; } = new List<User>();

    // Metod för att lägga till användare med enbart användarnamn
    public bool AddUser(string username)
    {
        // Validera användarnamn
        if (!IsUsernameValid(username))
        {
            Console.WriteLine("Invalid username. Username must be between 5 and 20 characters long and contain only alphanumeric characters.");
            return false;
        }

        // Lägg till användare utan lösenord och e-postadress
        Users.Add(new User(username, "", ""));
        Console.WriteLine("User added successfully.");
        return true;
    }

    // Metod för att lägga till användare med användarnamn, lösenord och e-postadress
    public bool AddUser(string username, string password, string email)
    {
        // Validera användarnamn
        if (!IsUsernameValid(username))
        {
            Console.WriteLine("Invalid username. Username must be between 5 and 20 characters long and contain only alphanumeric characters.");
            return false;
        }

        // Validera lösenord
        if (!IsPasswordValid(password))
        {
            Console.WriteLine("Invalid password. Password must be at least 8 characters long and contain at least one special character.");
            return false;
        }

        //// Validera e-postadress
        //if (!IsEmailValid(email))
        //{
        //    Console.WriteLine("Invalid email address.");
        //    return false;
        //}

        // Lägg till användare
        Users.Add(new User(username, password, email));
        Console.WriteLine("User added successfully.");
        return true;
    }

    public bool IsUsernameValid(string username)
    {
        return username.Length >= 5 && username.Length <= 20 && IsAlphanumeric(username);
    }
    public bool IsAlphanumeric(string str)
    {
        return str.All(char.IsLetterOrDigit);
    }


    public bool IsPasswordValid(string password)
    {
        return password.Length >= 8 && password.Any(char.IsLetterOrDigit) && password.Any(c => !char.IsLetterOrDigit(c));
    }
    public bool IsEmailValid(string email)
    {
        // Kontrollera om e-postadressen innehåller "@"-tecknet
        if (email.Contains("@"))
        {
            // Om e-postadressen innehåller "@"-tecknet, anses den vara giltig
            return true;
        }
        else
        {
            // Annars anses den vara ogiltig
            return false;
        }
    }
}


    

