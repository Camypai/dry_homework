using System;

namespace DRY
{
    internal class Program
    {
        private static decimal _cash = 0;

        static void Main(string[] args)
        {
            var exitKey = string.Empty;
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
                    PushCash(value);
                    Console.WriteLine($"Пополнение счёта: +{value} руб.");
                    Console.WriteLine($"Текущее состояние счёта: {_cash} руб.");
                }

                if (choice == "2")
                {
                    Console.WriteLine("Какую сумму вы хотите снять со счёта?");
                    var value = decimal.Parse(Console.ReadLine());
                    PullCash(value);
                    Console.WriteLine($"Снятие наличных: -{value} руб.");
                    Console.WriteLine($"Текущее состояние счёта: {_cash} руб.");
                }

                Console.WriteLine("Чтобы завершить операции со счётом введите \"q\"");
                exitKey = Console.ReadLine();
            } while (exitKey.ToLower() != "q");
        }

        static void PullCash(decimal value)
        {
            _cash -= value;
        }

        static void PushCash(decimal value)
        {
            _cash += value;
        }
    }
}