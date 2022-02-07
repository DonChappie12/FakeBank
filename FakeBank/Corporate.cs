namespace FakeBank
{
    public class Corporate : Investment
    {
        public Corporate(string name = "Bill")
        {
            InvestmentType = InvestmentTypes.Corporate;
            OwnerName = name;
        }
    }
}