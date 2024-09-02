using System;
using System.Collections.Generic;

public class BankAccount
{
    public string AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    public decimal Balance { get; private set; }
    private List<Transaction> Transactions { get; set; }

    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
        Transactions = new List<Transaction>();
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }
        Balance += amount;
        Transactions.Add(new Transaction("Deposit", amount, DateTime.Now));
        Console.WriteLine($"Deposited: {amount:C}. New balance: {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }
        Balance -= amount;
        Transactions.Add(new Transaction("Withdraw", amount, DateTime.Now));
        Console.WriteLine($"Withdrew: {amount:C}. New balance: {Balance:C}");
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: {Balance:C}");
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine($"{transaction.Date}: {transaction.Type} of {transaction.Amount:C}");
        }
    }
}

public class Transaction
{
    public string Type { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }

    public Transaction(string type, decimal amount, DateTime date)
    {
        Type = type;
        Amount = amount;
        Date = date;
    }
}
