using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{
    public class FixedAccount : BankAccount
    {
        public DateTime MaturityDate { get; set; }
        public int Years { get; set; }
        public double InterestRate { get; set; } // 0.001
        public override void Deposit(double amount)
        {
            if(Balance == 0)
            {
                Balance += amount;
            }
        }
        public override double Withdraw(double amount)
        {
            if(DateTime.Now > MaturityDate)
            {
                double interestAccumulated = 0;
                for (int i = 0; i < Years; i++)
                {
                    interestAccumulated += ((InterestRate / 100) * (Balance + interestAccumulated));
                }
                return Balance + interestAccumulated;
            }
            else
            {
                throw new Exception("Not allowed");
            }
        }
    }
}
