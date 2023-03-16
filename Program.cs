using System;
using System.Collections.Generic;
using System.Net.Mail;

public class MailPass
{
    public string email;
    public string password;
    public int wrongattempt = 0;
}

class Program
{
    private static bool IsValid(string email)
    {
        var valid = true;

        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            valid = false;
        }

        return valid;
    }

    private static bool IsPass(string password)
    {
        int cnt = 0;
        foreach (char c in password)
        {
            if (char.IsDigit(c) == true)
                cnt++;
        }
        if (cnt == 0 || password.Length < 10)
            return false;
        else return true;
    }

    private static void WaitInput()
    {
        Console.WriteLine("Press anything to continue");
        Console.ReadLine();
    }

    private static void IsAccountPassword(MailPass account, List<MailPass> blockedAccounts, List<MailPass> accounts) 
    {
        string password;
        Console.Write("Password: ");
        password = Console.ReadLine();
        if (password != account.password)
        {
            account.wrongattempt++;
            if (account.wrongattempt < 3)
            {
                Console.WriteLine("Wrong password !!! You have " + (3 - account.wrongattempt) + " attempts left");
                IsAccountPassword(account, blockedAccounts, accounts);
            }
            else
            {
                Console.WriteLine("Account blocked");
                blockedAccounts.Add(account);
                WaitInput();
            }
        }
        else 
        {
            Console.Clear();
            account.wrongattempt = 0;
            Console.Write("Hello ");
            foreach (char c in account.email) 
            {
                if (c == '@')
                    break;
                else Console.Write(c);
            }
            Console.WriteLine();
            WaitInput();
        }

    }

    private static void register(List<MailPass> accounts)
    {
        Console.Clear();
        MailPass mp = new MailPass();
        Console.WriteLine("Enter an email addres and a password that has at least 10 characters in length and contains at least 1 number");
        Console.Write("Email: ");
        mp.email = Console.ReadLine();
        while (IsValid(mp.email) == false)
        {
            Console.Clear();
            Console.WriteLine("Invalid email! Try again!");
            Console.Write("Email: ");
            mp.email = Console.ReadLine();
        }
        Console.Write("Pasword: ");
        mp.password = Console.ReadLine();
        while (IsPass(mp.password) == false)
        {
            Console.Clear();
            Console.WriteLine("The password must have at least 10 characters in length and contain at least 1 number! Try again!");
            Console.Write("Pasword: ");
            mp.password = Console.ReadLine();
        }
        accounts.Add(mp);
        Console.WriteLine("Account succesfully registered");
        WaitInput();
    }

    private static void ChangePass(MailPass account, List<MailPass> accounts) 
    {
        string oldpass, newpass;
        Console.WriteLine("Enter your old password");
        Console.Write("Old password: ");
        oldpass = Console.ReadLine();
        if (oldpass == account.password)
        {
            Console.WriteLine("Success! Enter your new password");
            Console.WriteLine("The password must have at least 10 characters in length and contain at least 1 number!");
            Console.Write("New password: ");
            newpass = Console.ReadLine();
            while (IsPass(newpass) == false)
            {
                Console.Clear();
                Console.WriteLine("The password must have at least 10 characters in length and contain at least 1 number! Try again!");
                Console.Write("New pasword: ");
                newpass = Console.ReadLine();
            }
            foreach (MailPass c in accounts)
            {
                if (c.email == account.email)
                    c.password = newpass;
            }
            Console.WriteLine("Password changed successfully !");
            WaitInput();
        }
        else 
        {
            Console.WriteLine("You don't know your old password! Please contact us.");
            WaitInput();
        }
    }

    private static void ExistingAccount(List<MailPass> accounts, List<MailPass> blockedAccounts,int option)
    {
        Console.Clear();
        string email;
        int cnt = 0;
        Console.WriteLine("Enter your email address");
        Console.Write("Email: ");
        email = Console.ReadLine();
        foreach (MailPass account in accounts) 
        {
            if (email == account.email) 
            {
                cnt = 1;
            }
        }
        foreach (MailPass blocked in blockedAccounts)
        {
            if (email == blocked.email)
            {
                Console.WriteLine("Account blocked");
                cnt = 2;
            }
        }
        switch (cnt)
        {
            case 0:
                Console.WriteLine("The account dosen't exist try again or register");
                WaitInput();
                break;
            case 2:
                Console.WriteLine("The account is blocked try again or register again");
                WaitInput();
                break;
            case 1:
                foreach (MailPass account in accounts) 
                {
                    if (email == account.email) 
                    {
                        if (option == 2)
                            IsAccountPassword(account, blockedAccounts, accounts);
                        else if (option == 3)
                            ChangePass(account, accounts);
                    }
                }
                break;
        }
    }

    static void Main()
    {
        List<MailPass> accounts = new List<MailPass>();
        List<MailPass> blockedAccounts = new List<MailPass>();
        MailPass mp = new MailPass();
        mp.email = "a@b.com";
        mp.password = "asdfghjkl1";
        accounts.Add(mp);
        int option;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("MENU \n Enter your option \n 1) Register \n 2) Login \n 3) Change password");
            option = Convert.ToInt16(Console.ReadLine());
            switch (option)
            {
                case 1:
                    register(accounts);
                    break;
                case 2:
                    ExistingAccount(accounts, blockedAccounts, option);
                    break;
                case 3:
                    ExistingAccount(accounts, blockedAccounts, option);
                    break;
                default: 
                    Console.WriteLine("The option does not exist");
                    WaitInput();
                    break;
            }
        }
    }
}
