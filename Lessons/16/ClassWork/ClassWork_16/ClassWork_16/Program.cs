using System;

namespace ClassWork_16
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(10.0);

            Console.WriteLine(circle.Calculate(radius => 2 * Math.PI * radius));
            Console.WriteLine(circle.Calculate(radius => Math.PI * Math.Pow(radius, 2)));
            Console.WriteLine(circle.Calculate(radius => 2 * radius));
        }
    }

    public sealed class Circle
    {
        private double _radius;

        public Circle(double radius) =>
            _radius = radius;

        public double Calculate(Func<double, double> operation) =>
            operation(_radius);
    }
}
