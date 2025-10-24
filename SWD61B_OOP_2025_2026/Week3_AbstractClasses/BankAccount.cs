using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{
    public abstract class BankAccount : IAccount
    {
        //we are actually IMPLEMENTING the properties
        public double Balance { get; set; }
        public string Owner { get; set; }

        public string IBAN { get; set; }

        public abstract void Deposit(double amount);

        public abstract double Withdraw(double amount);
        
    }
}
