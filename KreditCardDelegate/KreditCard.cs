using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditCardDelegate
{
    public delegate void KrCd(string value);
    class KreditCard
    {
        public event KrCd Stuck;
        public string numcrd;
        public string FIO;
        public int LimitM;
        public int SumM;
        public string pin;
        public KreditCard(){
            numcrd = "None";
            FIO = "None";
            LimitM = 1000;
            SumM = 0;
            pin = "None";
        }
        public KreditCard(string numcrd, string FIO, int LimitM, int SumM, string pin)
        {
            this.numcrd = numcrd;
            this.FIO = FIO;
            this.LimitM = LimitM;
            this.SumM = SumM;
            this.pin = pin;
        }
    }
    class MAIN : KreditCard
    {
        static void main()
        {

        }
    }
    class Input : KreditCard
    {
        public void InpInf()
        {
            Console.Write("\nВведите имя:");
            FIO = Console.ReadLine();
            Console.Write("\nВведите номер карты:");
            numcrd = Console.ReadLine();
            while (true)
            {
                Console.Write("\nСоздайте PIN(4 цифры):");
                pin = Console.ReadLine();
                if (pin.Length == 4 && int.TryParse(pin, out int result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nЧисло не является четырехзначным.");
                }
            }
        }
    }
    class inpMoney: KreditCard
    {
        public void ReplenishAccount(int value)
        {
            SumM += value;
        }
    }
    class PIN : KreditCard {
        public void EditPin(string value)
        {
            pin = value;
        }
    }
    class banka: KreditCard
    {
        public void SpendCreditMoney(int value)
        {
            if (LimitM >= value) LimitM -= value;
            else throw new ArgumentException("LimitM <= value");
        }
    }
    class credmon : KreditCard
    {
        public void SpendMoney(int value)
        {
            if (SumM >= value) SumM -= value;
            else throw new ArgumentException("SumM <= value");
        }
    }
    
}
