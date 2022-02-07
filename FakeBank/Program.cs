using System;

namespace FakeBank
{
    class Program
    {
        static void Main(string[] args)
        {
            int transfer = 340;

            Accounts billCheckingAccount = new Checking();
            Accounts davidCheckingAccount = new Checking("David");
            Investment davidIndividualAccount = new Individual("David");
            Investment davidCorporateAccount = new Corporate("David");
            
            billCheckingAccount.BalanceSheet();
            Console.WriteLine("");
            davidCheckingAccount.Deposit(500, (int)davidCheckingAccount.AccountType);
            Console.WriteLine("");
            davidIndividualAccount.Deposit(200, (int)davidIndividualAccount.InvestmentType);
            Console.WriteLine("");
            davidCorporateAccount.Deposit(1500, (int)davidCorporateAccount.InvestmentType);
            Console.WriteLine("");

            davidCorporateAccount.SendTransfer(transfer, billCheckingAccount.OwnerName, billCheckingAccount.AccountType.ToString());
            Console.WriteLine("");
            billCheckingAccount.RecieveTransfer(transfer, davidCorporateAccount.OwnerName, davidCorporateAccount.InvestmentType.ToString());
            Console.WriteLine("");

            transfer = 137;
            davidCorporateAccount.SendTransfer(transfer, davidIndividualAccount.OwnerName, davidIndividualAccount.InvestmentType.ToString());
            Console.WriteLine("");
            davidIndividualAccount.RecieveTransfer(transfer, davidCorporateAccount.OwnerName, davidCorporateAccount.InvestmentType.ToString());
            Console.WriteLine("");

            billCheckingAccount.BalanceSheet();
            Console.WriteLine("");
            davidCheckingAccount.BalanceSheet();
            Console.WriteLine("");
            davidIndividualAccount.BalanceSheet();
            Console.WriteLine("");
            davidCorporateAccount.BalanceSheet();
        }
    }
}
