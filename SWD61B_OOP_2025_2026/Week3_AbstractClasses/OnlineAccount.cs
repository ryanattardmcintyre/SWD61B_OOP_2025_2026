using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{
    public abstract class OnlineAccount : IAccount
    {
        public double Balance { get; set; }
        public string Owner { get; set; }
        public string Email { get; set; }
        public abstract void Deposit(double amount);
        public abstract double Withdraw(double amount);

        //An implemented method cannot use the keyword abstract
        //Its either abstract OR implemented
        public void Backup(string filePath)
        {
            System.IO.File.AppendAllText(filePath, $"{DateTime.Now.ToString()} : {Balance}");
        }
    }
}
