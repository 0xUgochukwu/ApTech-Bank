using System;
namespace BankApp
{
    public class Transaction
    {

        public int Amount { get; set; }

        public string Type { get; set; }

        public Beneficiary beneficiary;

        public DateTime time;

        public Transaction(string type, int amount, DateTime time, Beneficiary beneficiary)
        {
            this.Type = type;
            this.beneficiary = beneficiary;
            this.Amount = amount;
            this.time = time;
        }
    }
}

