using System;

namespace SumDiffMult
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstDigit;
            double secondDigit;

            Console.Write("Введите первое число: ");
            firstDigit = double.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            secondDigit = double.Parse(Console.ReadLine());

            Console.WriteLine($"\nСумма: {firstDigit + secondDigit}" +
                              $"\nРазница: {firstDigit - secondDigit}" +
                              $"\nПроизведение: {firstDigit * secondDigit}");
        }
    }
}
