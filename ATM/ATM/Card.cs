using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Card
    {
		public Card(string firstName, string lastName, string cardNum, string pin)
		{
			FirstName = firstName;
			LastName = lastName;	
			CardNum = cardNum;
			PIN = pin;
		}

		private string FirstName;


		private string LastName;


		private string CardNum;


		private string PIN;


		private decimal CurrBalance = 0;


        private bool Blocked;

		public string GetFirstName()
		{      
			return FirstName;
		}

        public string GetLastName()
        {
            return LastName;
        }

		public string GetCardNum()
		{
			return CardNum;
		}

		public string GetPIN()
		{
			return PIN;
		}

        public decimal GetCurrBalance()
        {
            return CurrBalance;
        }

		public void SetCurrBalance(decimal amount)
		{
			CurrBalance = amount;
		}

        public void BlockCard()
		{
			Blocked = true;
		}

		public bool isBlocked()
		{
			return Blocked;
		}
    }
}
