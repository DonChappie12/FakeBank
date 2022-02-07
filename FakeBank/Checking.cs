namespace FakeBank
{
    public class Checking : Accounts
    {
        public Checking(string name = "Bill")
        {
            AccountType = 0;
            OwnerName = name;
        }
    }
}