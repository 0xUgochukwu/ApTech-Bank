using System;
namespace BankApp
{
    public class Investment
    {
        // Properties
        
        public string Name;
        public double Capital;
        public double InterestRate;

        // Constructor
        public Investment(string name, double capital, double interestRate)
        {
            Name = name;
            Capital = capital;
            InterestRate = interestRate / 100 ;
            
        }
    }
}
