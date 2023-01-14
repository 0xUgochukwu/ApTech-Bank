using System;
using System.Collections.Generic;

namespace BankApp
{
    public class BankAccount
    {

        public string name;
        public string lastName;
        public string fullName;
        public string acctNo;
        public string pin;
        public int balance = 0;
        public Card card;
        public List<Transaction> transactions = new List<Transaction>();
        public List<Investment> investments = new List<Investment>();


        public BankAccount(string name, string lastName, string acctNo, string pin)
        {
            this.name = name;
            this.lastName = lastName;
            this.fullName = name + " " + lastName;
            this.acctNo = acctNo;
            this.pin = pin;
            this.card = new Card(fullName, DateTime.Now, acctNo, pin);
        }

        

        public void deposit()
        {
            Console.WriteLine("How much do you want to Deposit");
            int amount = Convert.ToInt32(Console.ReadLine());
            balance += amount;
            transactions.Add(new Transaction("Deposit", +amount, DateTime.Now, new Beneficiary(this.fullName, this.acctNo)));
            Console.WriteLine($"You have successfully deposited ₦{amount} into your account \nYou have ₦{balance} left");
            Console.WriteLine("=====================================");
            return;
            
        }

        public void withdraw()
        {
            Console.WriteLine("How much do you want to Withdraw?");
            int amount = Convert.ToInt32(Console.ReadLine());
            
            if (balance < amount)
            {
         
                Console.WriteLine($"You want to reap where you did not sow \nYou can't withdraw that much");
                Console.WriteLine("=====================================");
                return;
            }
            else {

                Console.WriteLine("What is your pin");
                string pin = Console.ReadLine();

                if (pin == this.pin)
                {

                    balance -= amount;
                    Console.WriteLine($"You have successfully withdrawn ₦{amount} from your account \nYou have ₦{balance} left");
                    transactions.Add(new Transaction("Withdrawal", -amount, DateTime.Now, new Beneficiary(this.fullName, this.acctNo)));
                    Console.WriteLine("=====================================");
                    return;

                }
                else
                {
                    Console.WriteLine("You entered the wrong PIN");
                    Console.WriteLine("=====================================");
                    return;
                }
                
            }
        }

        public void transfer()
        {
            Console.WriteLine("How much do you want to Transfer?");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (balance > amount)
            {
                Console.WriteLine("Enter Beneficiary's Account Number: ");
                string acctNo = Console.ReadLine();

                Console.WriteLine("Enter Beneficiary's Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("What is your pin");
                string pin = Console.ReadLine();

                if (pin == this.pin)
                {

                    balance -= amount;
                    transactions.Add(new Transaction("Transfer", -amount, DateTime.Now, new Beneficiary(name, acctNo)));
                    Console.WriteLine($"You have successfully Transferred ₦{amount} from your account to {name} \n You have ₦{this.balance} left");
                    Console.WriteLine("=====================================");
                    return;

                }
                else
                {
                    Console.WriteLine("You entered the wrong PIN");
                    Console.WriteLine("=====================================");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Your Balance is too low to make this Transfer");
                Console.WriteLine("=====================================");
                return;
            }
            
            

        }

        public void invest()
        {
            Console.WriteLine("How much do you wish to invest? ");
            double amount = Convert.ToInt32(Console.ReadLine());

            if (balance > amount)
            {
                Console.WriteLine("What do you want to name your investment? ");
                string name = Console.ReadLine();


                Console.WriteLine("What is the Interest rate on your Investment?");
                double interestRate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("What is your pin");
                string pin = Console.ReadLine();


                if (pin == this.pin)
                {

                    investments.Add(new Investment(name, amount, interestRate));
                    balance -= Convert.ToInt32(amount);
                    transactions.Add(new Transaction("Investment", -(int)amount, DateTime.Now, new Beneficiary(this.fullName, this.acctNo)));
                    Console.WriteLine($"You have successfully Invested ₦{amount} in {name} \n" +
                        $"You will earn {interestRate}% on your capital per month \n " +
                        $"You have ₦{this.balance} left");
                    Console.WriteLine("=====================================");
                    return;


                }
                else
                {
                    Console.WriteLine("You entered the wrong PIN");
                    Console.WriteLine("=====================================");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Your Balance is too small to make this Investment");
                Console.WriteLine("=====================================");
                return;
            }

            
        }

        public void displayCardDetails()
        {
            Console.WriteLine("Enter your pin");
            string pin = Console.ReadLine();


            if (pin == this.pin)
            {
                Console.WriteLine("Here are your Card Details \n" +
                "++++++++++++++++++++++++++++++++++++++++++++++++++");

                Console.WriteLine($"Name on your Card: {this.card.cardName},\n" +
                $"Card Number: {this.card.CARDNO}\n" +
                $"Card PIN: {this.card.PIN}\n" +
                $"Expiry Date: {this.card.EXPIRYDATE.ToString("MM/yy")}\n" +
                $"CSV: {this.card.CVV}");
                Console.WriteLine("=====================================");
                return;

            }
            else
            {
                Console.WriteLine("You entered the wrong PIN");
                Console.WriteLine("=====================================");
                return;
            }
            

        }

        public void displayAccountDetails()
        {
            Console.WriteLine("Here are your Account Details \n" +
                "++++++++++++++++++++++++++++++++++++++++++++++++++");

            Console.WriteLine($"Your Account Details are \n Account Name: {this.fullName} \n " +
                $"Account Number: {this.acctNo} \n " +
                $"Account Balance: ₦{this.balance}");
            Console.WriteLine("=====================================");
            return;
        }

        public void displayTransactions()
        {
            // loops through all transactions and prints them

            Console.WriteLine("Here is a list of your recent Transactions \n" +
                "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine($"Type of Transaction: {transactions[i].Type} || " +
                    $"Amount: ₦{transactions[i].Amount} || " +
                    $"Transaction Beneficiary: {transactions[i].beneficiary.name} || " +
                    $"Time Of Transaction: {transactions[i].time.ToString()}");
                Console.WriteLine("----------------------------------------------------------");
            }

            Console.WriteLine("=====================================");
            return;
        }

        public void displayInvestments()
        {
            // loop through all investments and display

            Console.WriteLine("Here is a list of your recent Investments \n" +
                "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            double totalInvestments = 0;

           for (int x = 0; x < investments.Count; x++)
            {
                
                investments[x].Capital += (investments[x].Capital * investments[x].InterestRate);
                totalInvestments += investments[x].Capital;
                Console.WriteLine($"Name of the investment : {investments[x].Name} || " +
                    $"Current Capital of the investment: ₦{investments[x].Capital} || " +
                    $"Interest Rate of the investment: {investments[x].InterestRate * 100}%");
                Console.WriteLine("----------------------------------------------------------");
                
            }



            Console.WriteLine($"You have a total of ₦{totalInvestments} in your investments");

            Console.WriteLine("=====================================");
            return;
        }
        

    }
}

