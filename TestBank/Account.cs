using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public abstract class Account
    {
        protected int acno;
        protected string AcHolder_name;
        protected double Ac_Balance=0;
        public static int ctr=0;

        public delegate void MyDelegate(double Ac_Balance);

        public abstract int openaccnt(double amount, string Ac_Holdername);
        public virtual bool deposit(double amount,MyDelegate del)
        {
            if (amount > 0)
            {
                Ac_Balance += amount;
                del(Ac_Balance);
                return true;
            }
            else
                return false;
        }
        public abstract bool withdraw(double amount, MyDelegate del);
        public double CHECKBALANCE
        {
            get
            {
                return Ac_Balance;
            }

        }
        public int ACNO
        {
            get
            {
                return acno;
            }
        }
        public string closeAccount()
        {
            return "Account closed successfully";
        }
    }
}
