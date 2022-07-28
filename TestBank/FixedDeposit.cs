using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class FixedDeposit:Account
    {
        DateTime openDate,matdate;
        int term=Convert.ToInt32(Console.ReadLine());
        public override int openaccnt(double min_Balance, string name)
        {
            if (min_Balance >= 500)
            {
                ctr++;
                acno = ctr;
                Ac_Balance = min_Balance;
                AcHolder_name = name;
                openDate = DateTime.Now; //now is static property in datetime class
                matdate=openDate.AddYears(term);
                return acno;
            }
            else
                return 0;
        }
        public override bool withdraw(double amount,MyDelegate del)
        {
            
            if (matdate>=openDate) // can also use Datetime.compare(Datetime.now,matdate)>0)
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
