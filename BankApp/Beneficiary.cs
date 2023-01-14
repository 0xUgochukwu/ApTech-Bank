using System;
namespace BankApp
{
    public class Beneficiary
    {
        // public string Name { get; set; }
        public string name { get; set; }
        public string AccountNumber { get; set; }
        public Beneficiary(string name, string accountNumber)
        {

            this.name = name;
            this.AccountNumber = accountNumber;
        }
    }
}

