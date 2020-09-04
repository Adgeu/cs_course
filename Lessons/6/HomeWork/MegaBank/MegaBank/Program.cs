using System;

namespace MegaBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentAmount = ReadNumber("Введите сумму первоначального взноса в рублях: ", true);
            var percent = ReadNumber("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0.01): ");
            var desiredAmount = ReadNumber("Введите желаемую сумму накопления в рублях: ", true);

            var requiredDays = 0;
            for (; currentAmount < desiredAmount; requiredDays++)
            {
                currentAmount += currentAmount * percent;
            }

            Console.WriteLine($"\nНеобходимое количество дней для накопления желаемой суммы: {requiredDays}.\nНажмите любую клавишу для выхода…");
        }

        /// <summary>
        /// Пользовательский ввод числа
        /// </summary>
        /// <param name="caption">Заголовок</param>
        /// <param name="isRubles">Является ли введённое значение числом в рублях (дробная часть будет являться ошибкой)</param>
        /// <returns>Введённое число</returns>
        static double ReadNumber(string caption, bool isRubles = false)
        {
            while (true)
            {
                var number = 0.0;

                Console.Write(caption);

                bool result = double.TryParse(Console.ReadLine(), out number);
                if (!result || (isRubles && number % 1 != 0) || number < 0)
                {
                    PrintError("Ошибка! Неправильный формат ввода!");
                    continue;
                }

                return number;
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
