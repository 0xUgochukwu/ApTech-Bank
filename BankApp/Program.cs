using System;

namespace BankApp
{
    class Program
    {
        public static string pin;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Aptech Bank, do you want to Create an Account? \n" +
                "1. Yes \n" +
                "2. No \n" +
                "------------------------");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BankAccount user = createAccount();
                    displayOptions(user);
                    break;

                case 2:
                    Console.WriteLine("Alright, the App will be closing soon... \n\n" +
                        "But in the meantime, " +
                        "is there any why reason you don't want to bank with us? \n\n" +
                        "[ If Yes, Type in your complaint else just click Enter ]");
                    Console.ReadLine();
                    Console.WriteLine("Thank you for your feedback, Aptech Bank hopes to bank with you next time \n" +
                        "Byeeee \n" +
                        "Closing Bank App.......");
                    Environment.Exit(0);
                    break;

            }

        }


        public static BankAccount createAccount()
        {
            Console.WriteLine("What is your first name? ");
            string name = Console.ReadLine();

            Console.WriteLine("What is your last name? ");
            string lastName = Console.ReadLine();

            Random getAcctNo = new Random();
            string acctNo = Convert.ToString(getAcctNo.Next(100000000, 999999999));

            Console.WriteLine("What pin would you like to use for your account");
            string pin = Console.ReadLine();

            BankAccount user = new BankAccount(name, lastName, acctNo, pin);
            Console.WriteLine("Your Bank Account has been Successfully Created");
            

            return user;
        }

        public static void displayOptions(BankAccount user)
        {
            int choice = 0;
            UI(user.name);
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            } catch
            {
                Console.WriteLine("You entered an invalid input");
                displayOptions(user);
            }
            

            switch (choice)
            {
                case 1:
                    user.deposit();
                    displayOptions(user);
                    break;
                case 2:
                    user.withdraw();
                    displayOptions(user);
                    break;
                case 3:
                    user.transfer();
                    displayOptions(user);
                    break;
                case 4:
                    user.invest();
                    displayOptions(user);
                    break;
                case 5:
                    user.displayCardDetails();
                    displayOptions(user);
                    break;
                case 6:
                    user.displayTransactions();
                    displayOptions(user);
                    break;
                case 7:
                    user.displayInvestments();
                    displayOptions(user);
                    break;
                case 8:
                    user.displayAccountDetails();
                    displayOptions(user);
                    break;
                case 9:
                    user.displayCardDetails();
                    displayOptions(user);
                    break;
                case 10:
                    Console.WriteLine("Closing Bank App ......");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("You entered a wrong Value, Try Again");
                    displayOptions(user);
                    break;




            }
        }
        public static void UI(string name)
        {
            Console.WriteLine($"What would you like to do {name}?");
            Console.WriteLine(" 1. Deposit \n " +
                "2. Withdraw \n " +
                "3. Transfer \n " +
                "4. Invest \n " +
                "5. Get Card Details \n " +
                "6. See Recent Transactions \n " +
                "7. See Recent Investments \n " +
                "8. See Account Details \n " +
                "9. See Card Details \n " +
                "10. Close App \n " +
                "-------------------------");
        }

        
    }
}

