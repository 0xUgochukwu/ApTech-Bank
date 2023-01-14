using System;
namespace BankApp
{
    public class Card
    {
        public string cardName;
        public string CARDNO;
        public string PIN;
        public int CVV;
        public string acctno;
        public DateTime EXPIRYDATE;

        public Card(string cardName, DateTime date, string acctno,string pin)
        {
            this.PIN = pin;
            this.acctno = acctno;
            Random random = new Random();
            this.CARDNO = Convert.ToString(random.Next(100000000, 999999999));
            this.CVV = random.Next(100, 999);
            this.EXPIRYDATE = date.AddYears(2);
            this.cardName = cardName;
            

        }
        
    }
}

