namespace DecoratorFactoryExample
{
   	public class CreditCard
	{
		private int CreditBalance;
		private int MaxCredit;

		public CreditCard(int credit)
		{
			CreditBalance = credit;
			MaxCredit = credit;
		} 

		virtual public string Payoff(int amount)
		{
			CreditBalance += amount;
			return $"The {amount} Amount is credited.";
		}

		virtual public string Debit(int amount)
		{
			CreditBalance -= amount;
			return $"The {amount} Amount is debited.";
		}

		virtual public int ReadBalance()
		{
			return CreditBalance;
		}

		virtual public int ReadMax()
		{
			return MaxCredit;
		}

		virtual public string ResetCard()
		{
			CreditBalance = MaxCredit;
			return $"The credit balance is reset.";
		}
	}
}
