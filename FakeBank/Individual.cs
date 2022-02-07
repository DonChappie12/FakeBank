using System;

namespace FakeBank
{
    public class Individual : Investment
    {
        public Individual(string name = "Bill")
        {
            InvestmentType = (int)InvestmentTypes.Individual;
            OwnerName = name;
        }
        public override bool Withdrawal(int withDrawalAmount)
        {
            if(withDrawalAmount < 0)
            {
                Console.WriteLine("You can not withdraw a negative amount");
                return false;
            }
            else if(withDrawalAmount > 500)
            {
                Console.WriteLine("You can not withdraw more than $500 in this account");
                return false;
            }
            else
            {
                Balance -= withDrawalAmount;
                return true;
            }
        }
    }
}