using System.ComponentModel;

namespace DRY
{
    public class AccountEventArgs
    {
        public string Message { get; }
        public decimal Cash { get; }

        public AccountEventArgs(string message, decimal cash)
        {
            Message = message;
            Cash = cash;
        }
    }
}