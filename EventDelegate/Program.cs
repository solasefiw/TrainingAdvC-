namespace BankAccountApp
{
    // Delegate for the insufficient funds event
    public delegate void InsufficientFundsHandler(object sender, InsufficientFundsEventArgs e);

    // Custom EventArgs to hold additional event data
    public class InsufficientFundsEventArgs : EventArgs
    {
        public double Balance { get; }
        public double Amount { get; }

        public InsufficientFundsEventArgs(double balance, double amount)
        {
            Balance = balance;
            Amount = amount;
        }
    }

    public class BankAccount
    {
        // Properties
        public int AccountNumber { get; }
        public double Balance { get; private set; }

        // Event for insufficient funds
        public event InsufficientFundsHandler InsufficientFunds;

        // Constructor
        public BankAccount(int accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        // Method to deposit money
        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount}, New Balance: {Balance}");
        }

        // Method to withdraw money
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                OnInsufficientFunds(new InsufficientFundsEventArgs(Balance, amount));
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount}, New Balance: {Balance}");
            }
        }

        // Method to raise the InsufficientFunds event
        protected virtual void OnInsufficientFunds(InsufficientFundsEventArgs e)
        {
            InsufficientFunds?.Invoke(this, e);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new bank account with an initial balance
            BankAccount account = new BankAccount(123456, 0.0);

            // Subscribe to the InsufficientFunds event
            account.InsufficientFunds += Account_InsufficientFunds;

            // User interaction loop
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            account.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            account.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case "3":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }
            }

            // Keep the console open
            Console.WriteLine("Thank you for using the Bank Account App. Press any key to exit.");
            Console.ReadKey();
        }

        // Event handler for insufficient funds
        private static void Account_InsufficientFunds(object sender, InsufficientFundsEventArgs e)
        {
            Console.WriteLine($"Insufficient funds! Attempted to withdraw: {e.Amount}, Current balance: {e.Balance}");
        }
    }
}
