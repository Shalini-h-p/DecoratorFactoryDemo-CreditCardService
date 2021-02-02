
namespace DecoratorFactoryExample
{
    public class Decorator : CreditCard
    {
        protected CreditCard creditCard;
        public Decorator(CreditCard cc) : base(0)
        {
            creditCard = cc;
        }
    }

    public class NoNegativeBalance : Decorator
    {
        public NoNegativeBalance(CreditCard cc) : base(cc)
        {
        }

        override public int ReadMax()
        {
            return creditCard.ReadMax();
        }

        override public int ReadBalance() { 
            return creditCard.ReadBalance(); 
        }

        override public string Debit(int amount)
        {
            if (creditCard.ReadBalance() >= amount)
                return creditCard.Debit(amount);
            else
                return $"* The transaction " +
                    $"amount {amount} is greater " +
                    $"than the balance amount.";
        }

        override public string Payoff(int amount) { 
            return creditCard.Payoff(amount); 
        }

        override public string ResetCard()
        {
            return creditCard.ResetCard();
        }
    }

    public class PayOffLimit : Decorator
    {
        public PayOffLimit(CreditCard cc) : base(cc)
        {
        }

        override public int ReadMax()
        {
            return creditCard.ReadMax();
        }

        override public int ReadBalance()
        {
            return creditCard.ReadBalance();
        }

        override public string Debit(int amount)
        {
            return creditCard.Debit(amount);
        }

        override public string Payoff(int amount)
        {
            if (creditCard.ReadMax() >= creditCard.ReadBalance() + amount)
                return creditCard.Payoff(amount);
            else
            return $"* The transaction amount " +
                    $"{amount} should be less or equal than debit.";

        }

        override public string ResetCard()
        {
            return creditCard.ResetCard();
        }
    }

    public class ResetLimit : Decorator
    {
        public ResetLimit(CreditCard cc) : base(cc)
        {
        }

        override public int ReadMax()
        {
            return creditCard.ReadMax();
        }

        override public int ReadBalance()
        {
            return creditCard.ReadBalance();
        }

        override public string Debit(int amount)
        {
            return creditCard.Debit(amount);
        }

        override public string Payoff(int amount)
        {
            return creditCard.Payoff(amount);
        }

        override public string ResetCard()
        {
            if (creditCard.ReadBalance() <= 0)
                return $"* There is negative " +
                    $"balance of {creditCard.ReadBalance()} in this account.";
            else
                return creditCard.ResetCard();
        }
    }
}
