using System;
using System.Collections.Generic;
using System.Text;

namespace Task06_OperatorOverloadingFinalizer
{
    public class Money
    {
        private decimal _amount;
        private string _currency;

        // Amount and Currency are read-only from outside the class —
        // they can only be set once, inside the constructor.
        public decimal Amount
        {
            get => _amount;
            private set { _amount = value; }
        }

        public string Currency
        {
            get => _currency;
            private set { _currency = value; }
        }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // Default constructor: 0 JD
        public Money() : this(0, "JD")
        {
        }

        // Adds two Money values together, as long as currencies match.
        public static Money operator +(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            decimal sum = a.Amount + b.Amount;
            return new Money(sum, a.Currency);
        }

        // Subtracts b's amount from a's, as long as currencies match.
        public static Money operator -(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            decimal difference = a.Amount - b.Amount;
            return new Money(difference, a.Currency);
        }

        // Two Money values are equal if they have the same amount
        // (currencies must match to compare at all).
        public static bool operator ==(Money a, Money b)
        {
            CheckCurrency(a.Currency, b.Currency);
            return a.Amount == b.Amount;
        }

        // Reuses == and inverts the result — avoids repeating logic.
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

        // Guards against operating on two different currencies
        // (e.g. adding USD to JD). Throws instead of silently continuing,
        // so an invalid operation actually stops rather than producing
        // a misleading result.
        private static void CheckCurrency(string aCurrency, string bCurrency)
        {
            if (aCurrency != bCurrency)
            {
                throw new InvalidOperationException("Cannot add Money with different currencies.");
            }
        }

        // Required whenever == is overloaded — lets Money work correctly
        // with things like collections and LINQ's Equals()-based methods.
        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return this == other;
            }
            return false;
        }

        // Required alongside Equals — combines Amount and Currency into
        // one hash so Money behaves correctly in hash-based collections
        // like Dictionary or HashSet.
        public override int GetHashCode()
        {
            return (Amount, Currency).GetHashCode();
        }

        // Finalizer: called automatically by the garbage collector at some
        // point after this object becomes unreachable. Can't be called
        // directly — only triggered indirectly via GC.Collect().
        ~Money()
        {
            Console.WriteLine($"Money object ({Amount} {Currency}) finalized.");
        }
    }
}