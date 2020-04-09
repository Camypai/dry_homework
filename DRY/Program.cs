using System;

namespace DRY
{
    internal class Program
    {
        private static decimal _cash = 0;

        static void Main(string[] args)
        {
            var exitKey = string.Empty;
            
            var account = new Account(0);
            account.Notify += ShowMessage;
            
            Console.WriteLine("Вы создали счёт.");
            do
            {
                Console.WriteLine($"У Вас на счету {_cash} руб.\n" +
                                  "Вы хотите:\n" +
                                  "1. Положить наличные на счёт\n" +
                                  "2. Снять наличные со счёта");
                Console.WriteLine();
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Какую сумму вы хотите положить на счёт?");
                    var value = decimal.Parse(Console.ReadLine());
                    account.Push(value);
                }

                if (choice == "2")
                {
                    Console.WriteLine("Какую сумму вы хотите снять со счёта?");
                    var value = decimal.Parse(Console.ReadLine());
                    account.Pull(value);
                }

                Console.WriteLine("Чтобы завершить операции со счётом введите \"q\"");
                exitKey = Console.ReadLine();
            } while (exitKey.ToLower() != "q");
        }

        private static void ShowMessage(object sender, AccountEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Message);
            Console.WriteLine($"Сумма на вашем счёте: {eventArgs.Cash}");
        }
    }
}