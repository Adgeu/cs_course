using System;

namespace ClassWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = ReadNumber("Введите первое число: ");
            double second = ReadNumber("Введите второе число: ", true);

            Console.WriteLine("Сумма:        " + (first + second));
            Console.WriteLine("Разность:     " + (first - second));
            Console.WriteLine("Произведение: " + (first * second));
            Console.WriteLine("Частное:      " + (first / second));

            Console.WriteLine("Конец!");
        }

        /// <summary>
        /// Пользовательский ввод числа
        /// </summary>
        /// <param name="caption">Заголовок</param>
        /// <param name="isSecond">Является ли число вторым?</param>
        /// <returns>Введённое число</returns>
        static double ReadNumber(string caption, bool isSecond = false)
        {
            while (true)
            {
                double number;

                Console.Write(caption);
                bool result = double.TryParse(Console.ReadLine(), out number);

                if (result)
                {
                    if (isSecond && number == 0)
                        PrintError("Деление на ноль!");
                    else
                        return number;
                }
                else
                    PrintError("Неправильный формат!");
                
            }
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
