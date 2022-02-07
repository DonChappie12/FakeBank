using System;

namespace FakeBank
{
    public abstract class Investment : Accounts
    {
        public enum InvestmentTypes {Individual, Corporate};
        public InvestmentTypes InvestmentType;

        public override void BalanceSheet()
        {
            Console.WriteLine(OwnerName + ": You now have $" + Balance + " in your " + InvestmentType + " account");
        }
    }
}