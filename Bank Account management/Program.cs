using Bank_Account_management;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
        bool exit = false;
        while (!exit)
        {
            MainMenu();
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateAccount(accounts);
                    break;
                case 2:
                    DepositMoney(accounts);
                    break;
                case 3:
                    WithdrawMoney(accounts);
                    break;
                case 4:
                    ShowBalance(accounts);
                    break;
                case 5:
                    ShowAccountActivity(accounts);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Sorry, but you entered an incorrect choice.");
                    break;
            }
        }
    }

    static void MainMenu()
    {
        Console.WriteLine("Welcome to the main menu:");
        Console.WriteLine("1. Create an account");
        Console.WriteLine("2. Deposit money");
        Console.WriteLine("3. Withdraw money");
        Console.WriteLine("4. Show balance");
        Console.WriteLine("5.Show Account activity:");
        Console.WriteLine("6. Exit");
        Console.WriteLine("Select your choice:");
    }

    public static void CreateAccount(Dictionary<string, BankAccount> accounts)
    {
        Console.WriteLine("Enter your account number:");
        string number = Console.ReadLine();
        if (accounts.ContainsKey(number))
        {
            Console.WriteLine("Account with this number already exists.");
            return;
        }
        Console.WriteLine("Enter account's owner name:");
        string ownerName = Console.ReadLine();
        BankAccount account = new BankAccount(ownerName, number);
        accounts[number] = account;
        Console.WriteLine("Your account was created successfully.");
    }

    public static void DepositMoney(Dictionary<string, BankAccount> accounts)
    {
        Console.WriteLine("Enter your account number:");
        string number = Console.ReadLine();
        if (accounts.ContainsKey(number))
        {
            BankAccount account = accounts[number];
            Console.Write("Please, enter the amount of money to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Sorry, but you entered an incorrect amount.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public static void WithdrawMoney(Dictionary<string, BankAccount> accounts)
    {
        Console.WriteLine("Please, enter your account number:");
        string number = Console.ReadLine();
        if (accounts.ContainsKey(number))
        {
            BankAccount account = accounts[number];
            Console.WriteLine("Please, enter the amount of money to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Sorry, but you entered an incorrect amount of money.");
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    public static void ShowBalance(Dictionary<string, BankAccount> accounts)
    {
        Console.WriteLine("Enter your account number:");
        string number = Console.ReadLine();
        if (accounts.ContainsKey(number))
        {
            BankAccount account = accounts[number];
            Console.WriteLine($"Your current balance is: {account.Balance}");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
    public static void ShowAccountActivity(Dictionary<string, BankAccount> accounts)
    {
        Console.WriteLine("Enter your account number:");
        string number = Console.ReadLine();
        if (accounts.ContainsKey(number))
        {
            BankAccount account = accounts[number];
            List<AccountActivity> activities = account.GetActivities();

            Console.WriteLine($"Account Activity: {account.Number}");
            foreach (var activity in activities)
            {
                Console.WriteLine($"ID: {activity.ID}, Time: {activity.Time}, Description: {activity.Description}, Successful: {activity.IsSuccessful}");
            }

        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }



}