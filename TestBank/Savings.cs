using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class Savings:Account
    {
        public override int openaccnt(double min_Balance, string name)
        {
            if (min_Balance >= 1000)
            {
                ctr++;
                acno = ctr;
                Ac_Balance = min_Balance;
                AcHolder_name = name;
                return acno;
            }
            else
                return 0;
        }
        public override bool withdraw(double amount,MyDelegate del)
        {
            if ((Ac_Balance-amount)>1000)
            {
                Ac_Balance -= amount;
                del(Ac_Balance);
                return true;
            }
            else
                return false;
        }
    }
}
