using System;
using Calculator.Figure;
using Calculator.Operation;

namespace ClassWork_16
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(10.0);

            Console.WriteLine(circle.Calculate(CircleOperation.Length));
            Console.WriteLine(circle.Calculate(CircleOperation.Area));

            var square = new Square(6.0);

            Console.WriteLine(square.Calculate(SquareOperation.Perimeter));
            Console.WriteLine(square.Calculate(SquareOperation.Area));
        }
    }

    
}
