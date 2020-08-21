using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator2App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выводим стартовый экран
            UpdateScreen();

            // Объявляем переменную резултата
            double result = 0;

            // Программа работает, пока не будет нажат Esc
            while (true)
            {
                // Получаем выражение, записанное пользователем
                string inputExpression = Console.ReadLine();
             
                if (inputExpression == string.Empty)
                {
                    // Если выражение пустое, очищаем поле ввода и оставляем старый резултат
                    UpdateScreen(result);
                }
                else if (inputExpression == "C")
                {
                    // Если введён C (лат.), обнуляем результат и очищаем поле ввода
                    UpdateScreen();
                }
                else if (inputExpression == "E")
                {
                    // Если введён E (лат.), выходим из цикла while
                    break;
                }
                else
                {
                    // Записываем в массив все числа из выражения
                    double[] digits = ConvertArrStringToDouble(inputExpression.Split(new char[] { '+', '-', '*', '/', '%', '^' }));
                    // Записываем в массив все математические знаки из выражения
                    char[] mathOperations = GetMathOperations(inputExpression);

                    // Записываем в выражение первое число
                    result = digits[0];

                    for (int i = 0; i < mathOperations.Length; i++)
                    {
                        // Производим математические действия
                        switch (mathOperations[i])
                        {
                            case '+':

                                result += digits[i + 1];
                                break;

                            case '-':
                                result -= digits[i + 1];
                                break;

                            case '*':
                                result *= digits[i + 1];
                                break;

                            case '/':
                                result /= digits[i + 1];
                                break;

                            case '%':
                                result %= digits[i + 1];
                                break;

                            case '^':
                                result = Math.Pow(result, digits[i + 1]);
                                break;
                        }
                    }

                    // Обновляем экран с полученным результатом
                    UpdateScreen(result);
                }
            }
        }

        /// <summary>
        /// Обновление консоли
        /// </summary>
        /// <param name="result">Результат вычислений</param>
        static void UpdateScreen(double result = 0)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в СуперКалькулятор 2.0!\n");
            Console.ResetColor();

            Console.WriteLine(result);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---------------------------------------\n");
            Console.ResetColor();
        }

        
        /// <summary>
        /// Конвертирует string[] в double[]
        /// </summary>
        /// <param name="array">Конвертируемый массив</param>
        /// <returns>Результат</returns>
        static double[] ConvertArrStringToDouble(string[] array)
        {
            double[] result = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
                result[i] = double.Parse(array[i]);

            return result;
        }

        /// <summary>
        /// Записывает математичексие операции из введённого выражения в массив
        /// </summary>
        /// <param name="expression">Введённое пользователем выражение</param>
        /// <returns>Массив математических операций</returns>
        static char[] GetMathOperations(string expression)
        {
            List<char> result = new List<char>();
            char[] operations = new char[6] { '+', '-', '*', '/', '%', '^' };

            foreach (char symbol in expression)
                if (operations.Contains(symbol))
                    result.Add(symbol);

            return result.ToArray();
        }
    }
}
