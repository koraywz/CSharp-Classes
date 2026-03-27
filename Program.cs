using System;

namespace Classes
{
    /*
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Grade: {Grade}");
        }
    }

    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area() => Width * Height;

        public double Perimeter() => 2 * (Width + Height);
    }

    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;

        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return (double)a / b;
        }
    }
    */

    class BankAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; private set; }

        public BankAccount(string accNumber, double balance)
        {
            AccountNumber = accNumber;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"\nAccount Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance:C}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Student test
            Student s1 = new Student { Name = "Alice", Age = 20, Grade = 90 };
            Student s2 = new Student { Name = "Bob", Age = 22, Grade = 85 };
            Student s3 = new Student { Name = "Charlie", Age = 21, Grade = 92 };

            s1.PrintInfo();
            s2.PrintInfo();
            s3.PrintInfo();

            // Rectangle test
            Rectangle r1 = new Rectangle(8, 3);
            Console.WriteLine($"Area: {r1.Area()}");
            Console.WriteLine($"Perimeter: {r1.Perimeter()}");

            // Calculator test
            Console.WriteLine("Enter two numbers:");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            Calculator calc = new Calculator();
            Console.WriteLine($"Addition: {calc.Add(x, y)}");
            Console.WriteLine($"Subtraction: {calc.Subtract(x, y)}");
            Console.WriteLine($"Multiplication: {calc.Multiply(x, y)}");
            Console.WriteLine($"Division: {calc.Divide(x, y)}");
            */

            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();

            double balance = ReadDouble("Enter initial balance: ");
            BankAccount account = new BankAccount(accNumber, balance);

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Deposit");
                Console.WriteLine("2 - Withdraw");
                Console.WriteLine("3 - Show Balance");
                Console.WriteLine("0 - Exit");
                Console.Write("Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            double depositAmount = ReadDouble("Enter amount: ");
                            account.Deposit(depositAmount);
                            Console.WriteLine("Deposit successful.");
                            break;

                        case 2:
                            double withdrawAmount = ReadDouble("Enter amount: ");
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine("Withdrawal successful.");
                            break;

                        case 3:
                            account.PrintAccountInfo();
                            break;

                        case 0:
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine("Invalid number, try again.");
            }
        }
    }
}