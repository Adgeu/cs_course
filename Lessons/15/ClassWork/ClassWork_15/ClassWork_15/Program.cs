using System;

namespace ClassWork_15
{
    class Program
    {
        static void Main(string[] args)
        {  
            var circle = new Circle(10.0);          
            
            Console.WriteLine(circle.Calculate(Length));
            Console.WriteLine(circle.Calculate(Area));
        }

        static double Length(double radius) =>
            2 * Math.PI * radius;

        static double Area(double radius) =>
            Math.PI * Math.Pow(radius, 2);
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
