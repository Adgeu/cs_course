using System;

namespace Calculator.Figure
{
    public sealed class Circle
    {
        private double _radius;

        public Circle(double radius) =>
            _radius = radius;

        public double Calculate(Func<double, double> operation) =>
            operation(_radius);
    }

    public sealed class Square
    {
        private double _lenght;

        public Square(double lenght) =>
            _lenght = lenght;

        public double Calculate(Func<double, double> operation) =>
            operation(_lenght);
    }
}
