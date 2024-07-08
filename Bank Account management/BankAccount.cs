using System;
using System.Collections.Generic;

namespace Bank_Account_management
{
    public class BankAccount
    {
        List<AccountActivity> activityList=new List<AccountActivity>();
        public string OwnerName { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string ownerName, string number)
        {
            OwnerName = ownerName;
            Number = number;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"You entered: {amount}. Now your current balance is: {Balance}");
            }
            else
            {
                Console.WriteLine("Sorry, but you entered a negative amount.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please, enter the amount of money correctly.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("The amount of money is greater than your current balance, you can't withdraw.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"You withdrew: {amount}. Now your current balance is: {Balance}");
            }
        }
        public List<AccountActivity>GetActivities()
        {
            return activityList;
        }
        public void RecordActivity(string description, bool isSuccess)
        {
            var activity = new AccountActivity
            {
                ID = Guid.NewGuid(),
                Time = DateTime.Now,
                Description = description,
                IsSuccessful = isSuccess
            };
            activityList.Add(activity);
        }
    }
}