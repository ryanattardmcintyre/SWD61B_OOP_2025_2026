using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{
    //inheriting from the abstract class BankAccount
    public class CurrentAccount : BankAccount
    {
        //You can top up more properties or methods in here as well
        public string ChequeBookNumber { get; set; }
        public BankAccount FallbackAccount { get; set; }
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        public override double Withdraw(double amount) //amount = withdrawalAmount
        {
            //Balance = 1000;
            //Withdrawal amount = 1001;
            //Fallback account = 1000;
            if(amount > Balance)
            {
                double remainder = amount - Balance; //1001-1000 = 1
                if(FallbackAccount.Balance > remainder) //true
                {
                    FallbackAccount.Withdraw(remainder); //999
                    Balance = 0;
                }
            }
            else
            {
                Balance -= amount;
            }
            
            return Balance;
        }
    }
}
