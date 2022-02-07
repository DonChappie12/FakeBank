using System;
using Xunit;
using FakeBank;

namespace FakeBankTests
{
    public class UnitTest1
    {
        int depositedAmount = 200;
        bool result;
        int transferAmount = 50;
        int withdrawAmount = 100;
        Accounts davidsChecking = new Checking("David");
        Investment davidsIndividualAccount = new Individual("David");
        Investment davidsCorporateAccount = new Corporate("David");

        [Fact]
        public void SuccessfulDeposit()
        {
            result = davidsChecking.Deposit(depositedAmount, (int)davidsChecking.AccountType);
            Assert.Equal(result, true);
        }

        [Fact]
        public void UnsuccessfulDeposit()
        {
            result = davidsChecking.Deposit(-1, (int)davidsChecking.AccountType);
            Assert.Equal(result, false);
        }

        [Fact]
        public void SuccessfulWithDraw()
        {
            depositedAmount = 300;
            davidsChecking.Deposit(depositedAmount, (int)davidsChecking.AccountType);

            result = davidsChecking.Withdrawal(withdrawAmount);
            Assert.Equal(result, true);
        }

        [Fact]
        public void UnsuccessfulWithdraw()
        {
            withdrawAmount = 1000;
            result = davidsChecking.Withdrawal(withdrawAmount);
            Assert.Equal(result, false);
        }

        [Fact]
        public void WithDrawLimit()
        {
            depositedAmount = 700;
            withdrawAmount = 700;
            davidsIndividualAccount.Deposit(depositedAmount, (int)davidsIndividualAccount.InvestmentType);

            davidsIndividualAccount.Withdrawal(withdrawAmount);
            Assert.Equal(result, false);
        }

        [Fact]
        public void SuccessfulTransfer()
        {
            davidsChecking.SendTransfer(transferAmount, davidsIndividualAccount.OwnerName, davidsIndividualAccount.InvestmentType.ToString());
            result = davidsIndividualAccount.RecieveTransfer(transferAmount, davidsChecking.OwnerName, davidsChecking.AccountType.ToString());
            Assert.Equal(result, true);
        }

        [Fact]
        public void UnsuccessfulTransfer()
        {
            int negativeTransferAmount = -34;
            transferAmount = 300;
            davidsIndividualAccount.Deposit(depositedAmount, (int)davidsIndividualAccount.InvestmentType);
            davidsCorporateAccount.Deposit(depositedAmount, (int)davidsCorporateAccount.InvestmentType);

            result = davidsIndividualAccount.SendTransfer(transferAmount, davidsCorporateAccount.OwnerName, davidsCorporateAccount.InvestmentType.ToString());
            Assert.Equal(result, false);

            result = davidsCorporateAccount.RecieveTransfer(negativeTransferAmount, davidsIndividualAccount.OwnerName, davidsIndividualAccount.InvestmentType.ToString());
            Assert.Equal(result, false);
        }
    }
}
