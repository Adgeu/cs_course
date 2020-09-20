using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstDigit;
            double secondDigit;
            string mathOperator;

            double result = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в СуперКалькулятор 1.0!\n");
            Console.ResetColor();

            Console.Write("Введите первое число: ");
            firstDigit = float.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            secondDigit = float.Parse(Console.ReadLine());

            Console.Write("Укажите операцию, которую нужно произвести над числами (\"+\", \"-\", \"*\", \"/\", \"%\", \"^\"): ");
            mathOperator = Console.ReadLine();

            switch (mathOperator)
            {
                case "+":
                    result = firstDigit + secondDigit;
                    break;

                case "-":
                    result = firstDigit - secondDigit;
                    break;

                case "*":
                    result = firstDigit * secondDigit;
                    break;

                case "/":
                    result = firstDigit / secondDigit;
                    break;

                case "%":
                    result = firstDigit % secondDigit;
                    break;

                case "^":
                    result = Math.Pow(firstDigit, secondDigit);
                    break;
            }

            Console.WriteLine("\nРезультат: " + result);
        }
    }
}
