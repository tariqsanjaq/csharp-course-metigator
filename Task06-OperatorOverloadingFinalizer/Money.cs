using System;
using System.Collections.Generic;
using System.Text;

namespace Task06_OperatorOverloadingFinalizer
{
    public class Money
    {
        private decimal _amount;
        private string _currency;

        public decimal Amount { get => _amount;
            private set
            {
                _amount = value;
            }
        }
        public string Currency { get => _currency; private set => _currency = value; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public Money() : this(0, "JD")
        {

        }

        public static Money operator +(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);

            decimal sum = a.Amount + b.Amount;
            return new Money(sum, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            CheckCurrency(a.Currency,b.Currency );
            decimal sum = a.Amount - b.Amount;
            return new Money(sum, a.Currency);
        }

        public static bool operator ==(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            return  a.Amount == b.Amount;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }
        public static bool operator >(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            return a.Amount > b.Amount;
        }
        public static bool operator <(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            return a.Amount < b.Amount;
        }
        private static void CheckCurrency(string aCurrency, string bCurrency)
        {
            if (aCurrency != bCurrency)
            {
                Console.WriteLine("Cannot add Money with different currencies.");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Amount, Currency).GetHashCode();
        }

        ~Money()
        {
            Console.WriteLine($"Money object ({Amount} {Currency}) finalized.");
        }
    }
}
