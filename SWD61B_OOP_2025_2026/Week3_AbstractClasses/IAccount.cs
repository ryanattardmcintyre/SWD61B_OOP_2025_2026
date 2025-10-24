using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_AbstractClasses
{

    //What to declare in an interface
    //Why keeping only generic method signatures


    //Answer: (at this stage) while creating an interface
    //        you have to have the mindset to cater for all the possibilities
    //        that are related to Accounts being a savings account, fixed account
    //        virtual account
    //        I don't want to declare something which then limits the creation
    //        of inherited classes
    public interface IAccount
    {
        double Balance { get; set; }
        string Owner { get; set; }
        void Deposit(double amount);
        double Withdraw(double amount);
        
    }
}
