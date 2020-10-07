using System;

namespace Calculator.Operation
{
    public static class CircleOperation
    {
        public static double Length(double radius) =>
            2 * Math.PI * radius;

        public static double Area(double radius) =>
            Math.PI * Math.Pow(radius, 2);
    }

    public static class SquareOperation
    {
        public static double Perimeter(double length) =>
             4 * length;

        public static double Area(double length) =>
            length * length;
    }
}
