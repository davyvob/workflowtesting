using System;

namespace Howest.Cia.Bank.Core
{
    public class Account
    {
        public decimal Balance { get; private set; }
        private const decimal MaximumAmount = 2000M;
        public const string AmountExceedsBalanceErrorMessage = "Saldo ontoereikend.";
        public const string AmountLessThanZeroErrorMessage = "Het ingevoerde bedrag kan niet kleiner dan 0 zijn.";
        public readonly string AmountExceedsMaximumAmountErrorMessage = $"Het ingevoerde bedrag kan niet hoger zijn dan {MaximumAmount}.";
        public Account()
        {
            Balance = 250;
        }

        public Account(decimal initialAmount)
        {
            Balance = initialAmount;
        }

        public decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(null, AmountLessThanZeroErrorMessage);
            }

            if (amount > MaximumAmount)
            {
                throw new ArgumentOutOfRangeException(null, AmountExceedsMaximumAmountErrorMessage);
            }

            Balance += amount;
            return Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(null, AmountLessThanZeroErrorMessage);
            }

            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(null, AmountExceedsBalanceErrorMessage);
            }

            Balance -= amount;
            return Balance ;
            //add commit 
            

           
        }
    }
}
