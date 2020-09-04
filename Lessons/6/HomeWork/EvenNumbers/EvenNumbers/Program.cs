using System;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = ReadNumber();

            var evenCount = 0;
            var dividend = number;
            while (dividend > 0)
            {
                if (dividend % 10 % 2 == 0)
                    evenCount++;
                                 
                dividend /= 10;            
            }

            Console.WriteLine($"В числе {number} содержится следующее количество четных цифр: {evenCount}.\nНажмите любую клавишу для выхода... ");
        }

        /// <summary>
        /// Пользовательский ввод числа
        /// </summary>
        /// <returns>Введённое число</returns>
        static int ReadNumber()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите положительное натуральное число не более 2 миллиардов: ");
                    var number = int.Parse(Console.ReadLine());

                    if (number > 0)
                        return number;

                    PrintError($"Введено неверное значение! Попробуйте ещё раз:");
                }
                catch (Exception e)
                {
                    PrintError($"Ошибка {e.GetType()}! Попробуйте ещё раз:");
                }
            }
        }

        /// <summary>
        /// Вывод ошибки в консоль
        /// </summary>
        /// <param name="message">Описание ошибки</param>
        static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
