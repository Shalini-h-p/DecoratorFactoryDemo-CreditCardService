
namespace DecoratorFactoryExample
{
    public class Factory
    {
         public static CreditCard CreateCreditCard(string type)
        {
            if (type.Contains("Visa")) return new PayOffLimit(new ResetLimit(new CreditCard(50000)));
            else
                if (type.Contains("Master Card")) return new CreditCard(70000);
            else
                if (type.Contains("American Express")) return new NoNegativeBalance(new PayOffLimit(new CreditCard(110000)));
            else
                return new ResetLimit(new PayOffLimit(new CreditCard(20000)));
        }
    }
}
