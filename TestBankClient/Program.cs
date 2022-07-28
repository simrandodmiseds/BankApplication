using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBank;

namespace TestBankClient
{
    class Program
    {
        public static void upBalance(double Ac_Balance)
        {
            Console.WriteLine("Your current balance is "+Ac_Balance);
        }
        static void Main(string[] args)
        {
            String name;
            double amount;
            int opt,accno;
            int i = 0;
            Account acc =null;
            ArrayList aclist = new ArrayList();
            IEnumerator e;
            Account.MyDelegate del = new Account.MyDelegate(upBalance);

            do
            {
                Console.WriteLine("Enter your options\n1. Open Account\n2. Deposit\n3. Withdraw\n4. Check Balance\n5. Close Account\n6. Exit\nEnter Your Option:");
                 opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        
                        Console.WriteLine("Which account you want to open?\n1. Savings\n2. Current\n3. Fixed Deposit\nEnter your option:");
                        int openopt = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name of account holder:");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter amount for opening account:");
                        amount = Convert.ToDouble(Console.ReadLine());

                        if (openopt == 1)
                            acc = new Savings();
                        else if (openopt == 2)
                            acc = new Current();
                        else if (openopt == 3)
                            acc = new FixedDeposit();
                        
                        Console.WriteLine("Account created. Your account number is:" + acc.openaccnt(amount, name));
                        aclist.Add(acc);
                        i++;
                        break;

                    case 2:
                        Console.WriteLine("Enter account number:");
                        accno = Convert.ToInt32(Console.ReadLine());
                        e = aclist.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == accno)
                            { 
                                Console.WriteLine("Enter amount for deposit:");
                                amount = Convert.ToDouble(Console.ReadLine());
                                if (temp.deposit(amount,del) == true)
                                {
                                    Console.WriteLine("Amount deposited successfully");
                                    break;
                                }
                                else
                                    Console.WriteLine("Amount can't be deposited");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter account number:");
                        accno = Convert.ToInt32(Console.ReadLine());
                        e = aclist.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == accno)
                            {
                                Console.WriteLine("Enter amount to withdraw:");
                                amount = Convert.ToDouble(Console.ReadLine());
                                if (temp.withdraw(amount,del) == true)
                                {
                                    Console.WriteLine("Collect your amount");
                                    break;
                                }
                                else
                                    Console.WriteLine("Minimum balance is not sufficient");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter account number:");
                        accno = Convert.ToInt32(Console.ReadLine());
                        e = aclist.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == accno)
                            {
                                Console.WriteLine(temp.CHECKBALANCE);
                                break;
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter account number:");
                        accno = Convert.ToInt32(Console.ReadLine());
                        e = aclist.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == accno)
                            {
                                Console.WriteLine("Account closed successfully");
                                aclist.Remove(e.Current);
                                break;
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter options between 1 to 5");
                        break;
                }
            } while (opt<=6);
        }
    }
}
