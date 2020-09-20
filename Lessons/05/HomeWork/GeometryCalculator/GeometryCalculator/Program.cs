using System;

namespace GeometryCalculator
{
    enum Shape
    {
        Circle = 1,
        Triangle,
        Rectangle
    }

    class Program
    {
        static void Main(string[] args)
        {
            double S = 0, P = 0;

            Shape shape = ReadShape();

            switch (shape)
            {
                case Shape.Circle:
                    double diameter = ReadNumber("Введите диаметр круга: ");

                    S = 3.14 * Math.Pow(diameter / 2, 2);
                    P = 2 * 3.14 * diameter / 2;

                    break;

                case Shape.Triangle:
                    double length = ReadNumber("Введите длину стороны треугольника: ");

                    S = Math.Sqrt(3.0) * Math.Pow(length, 2) / 4;
                    P = length * 3;

                    break;

                case Shape.Rectangle:
                    double width = ReadNumber("Введите ширину прямоугольника: ");
                    double height = ReadNumber("Введите высоту прямоугольника: ");

                    S = width * height;
                    P = 2 * (width + height);

                    break;
            }

            Console.WriteLine("\nПлощадь поверхности: " + S);
            Console.WriteLine("Длина периметра: " + P);
        }

        /// <summary>
        /// Выбор пользователем геометрической фигуры
        /// </summary>
        /// <returns>Выбранная геометрическая фигура</returns>
        static Shape ReadShape()
        {
            while (true)
            {
                int number;

                Console.WriteLine("Введите тип фигуры (1 круг, 2 равносторонний треугольник, 3 прямоугольник):");

                bool result = int.TryParse(Console.ReadLine(), out number);
                if (result)
                {
                    if (number >= 1 && number <= 3)
                        return (Shape)number;
                    else
                        PrintError("Ошибка! Вне диапазона ввода!");
                }
                else
                    PrintError("Ошибка! Неправильный формат ввода!");
            }
        }

        /// <summary>
        /// Пользовательский ввод значений
        /// </summary>
        /// <param name="caption">Заголовок</param>
        /// <returns>Введённое значение</returns>
        static double ReadNumber(string caption)
        {
            while (true)
            {
                double number;

                Console.Write(caption);

                bool result = double.TryParse(Console.ReadLine(), out number);

                if (result)
                    return number;

                PrintError("Ошибка! Неправильный формат ввода!");
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
