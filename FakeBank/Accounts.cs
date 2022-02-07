using System;

namespace FakeBank
{
    public abstract class Accounts
    {
        public string OwnerName;
        public int Balance;
        public enum AccountTypes {Checking, Investment};
        public AccountTypes AccountType;

        public Accounts(int balance = 0)
        {
            Balance = balance;
        }

        public virtual bool Withdrawal(int withDrawalAmount)
        {
            if(withDrawalAmount < 0)
            {
                Console.WriteLine(OwnerName + ": You can not withdraw a negative amount");
                return false;
            }
            else if(withDrawalAmount > Balance)
            {
                Console.WriteLine(OwnerName + ": You can not withdraw more than you have");
                return false;

            }
            else
            {
                Balance -= withDrawalAmount;
                BalanceSheet();
                return true;
            }
        }

        public bool Deposit(int depositAmount, int accountType)
        {
            if(depositAmount < 0)
            {
                Console.Write(OwnerName + ": You can not deposite a negative amount");
                return false;
            }

            Balance += depositAmount;
            Console.WriteLine(OwnerName + ": You have deposited $" + depositAmount);
            BalanceSheet();
            return true;
        }

        public bool SendTransfer(int transferAmount, string moneyTo, string account)
        {
            if(transferAmount < 0)
            {
                Console.Write(OwnerName + ": You can't transfer a negative amount");
                return false;
            }
            else if(transferAmount > Balance)
            {
                Console.WriteLine(OwnerName + ": You cannot transfer more than you have");
                return false;
            }
            Console.WriteLine("Sending $" + transferAmount + " to " + moneyTo + "'s " + account + " account");
            Balance -= transferAmount;
            BalanceSheet();
            return true;
        }

        public bool RecieveTransfer(int transferAmount, string moneyFrom, string account)
        {
            if(transferAmount < 0)
            {
                Console.WriteLine("Rejecting transfer");
                return false;
            }
            else
            {
                Console.WriteLine(OwnerName + ": You're recieving $" + transferAmount + " from " + moneyFrom + "'s " + account + " account");
                Balance += transferAmount;
                BalanceSheet();
                return true;
            }
        }

        public virtual void BalanceSheet()
        {
            Console.WriteLine(OwnerName + ": You now have $" + Balance + " in your " + AccountType + " account");
        }
    }
}