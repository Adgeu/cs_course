using System;

namespace ClassWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRetry = true;
            while (isRetry)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    var first = int.Parse(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    var second = int.Parse(Console.ReadLine());

                    Console.WriteLine("Сумма:        " + (first + second));
                    Console.WriteLine("Разность:     " + (first - second));
                    Console.WriteLine("Произведение: " + (first * second));
                    Console.WriteLine("Частное:      " + (first / second));

                    isRetry = false;
                }
                catch (FormatException)
                {
                    PrintError("Неправильный формат, попробуйте ещё раз!");                   
                }    
                catch (DivideByZeroException)
                {
                    PrintError("Деление на ноль, попробуйте ещё раз!");
                }
            }

            Console.WriteLine("Конец!");
        }

        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        //static void OldF()
        //{
            //==================================================================================================

            //Console.Write("Введите число меньше 200: ");
            //var number = int.Parse(Console.ReadLine());

            //if (number >= 200)
            //    throw new Exception("Число больше 200");

            //Console.WriteLine("Вы ввели " + number);

            //==================================================================================================

            //int age = int.Parse(Console.ReadLine());

            //var quotient = age % 10;
            //var divident = age / 10;

            //if (age > 100)
            //    Console.WriteLine("Error");
            //else if (quotient == 1 && age != 11)
            //    Console.WriteLine(age + " год");
            //else if (quotient <= 4 && divident != 1)
            //    Console.WriteLine(age + " года");
            //else
            //    Console.WriteLine(age + " лет");
        //}
    }
}
