using System.Diagnostics;

namespace DRY
{
    public class Account
    {
        public decimal Cash { get; private set; }

        public delegate void AccountHandler(object sender, AccountEventArgs eventArgs);

        public event AccountHandler Notify;
        
        public Account(decimal cash)
        {
            Cash = cash;
        }

        public void Pull(decimal value)
        {
            if (Cash >= value)
            {
                Cash -= value;
                Notify?.Invoke(this, new AccountEventArgs($"Снятие наличных: -{value} руб.", Cash));
            }
            else
            {
                Notify?.Invoke(this, new AccountEventArgs($"Недостаточно средств на счёте", Cash));
            }
        }

        public void Push(decimal value)
        {
            Cash += value;
            Notify?.Invoke(this, new AccountEventArgs($"Пополнение счёта: +{value} руб.", Cash));
            
        }
    }
}