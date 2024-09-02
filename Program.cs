using System;

class Program
{
    static void Main()
    {
        // Create a new bank account
        BankAccount myAccount = new BankAccount("123456789", "John Doe", 500.00m);

        // Display initial balance
        myAccount.DisplayBalance();

        // Perform some transactions
        Console.WriteLine("\nPerforming Transactions...\n");

        myAccount.Deposit(200.00m);
        myAccount.Withdraw(100.00m);
        myAccount.Withdraw(700.00m); // This should fail due to insufficient funds

        // Display final balance and transaction history
        myAccount.DisplayBalance();
        myAccount.DisplayTransactionHistory();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
