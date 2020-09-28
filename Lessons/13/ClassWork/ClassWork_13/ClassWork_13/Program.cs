using System;

namespace ClassWork_13
{
    interface IFlyingObject
    {
        int MaxHeight { get;  set; }
        int CurrentHeight { get;  set; }
        void TakeUpper(int delta);
        void TakeLower(int delta);
    }

    interface IHelicopter
    {
        byte BladesCount { get; set; }
    }

    interface IPlane
    {
        byte EnginesCount { get; set; }
    }

    interface IPropertiesWriter
    {
        void WriteAllProperties();
    }

    abstract class AirTransport : IFlyingObject, IPropertiesWriter
    {
        public int MaxHeight { get; set; }

        public int CurrentHeight { get; set; }

        public AirTransport(int maxHeight, int currentHeight)
        {
            MaxHeight = maxHeight;
            CurrentHeight = currentHeight;
        }

        public void TakeUpper(int delta)
        {
            if (delta <= 0)
                throw new ArgumentOutOfRangeException();
            else if (CurrentHeight + delta > MaxHeight)
                CurrentHeight = MaxHeight;
            else
                CurrentHeight += delta;
        }

        public void TakeLower(int delta)
        {
            if (delta <= 0)
                throw new ArgumentOutOfRangeException();
            else if (CurrentHeight - delta > 0)
                CurrentHeight -= delta;
            else if (CurrentHeight - delta == 0)
                CurrentHeight = 0;
            else if (CurrentHeight - delta < 0)
                throw new InvalidOperationException();
        }

        public abstract void WriteAllProperties();

        public virtual void WriteAllProperties_2() =>
            Console.WriteLine($"CurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
    }

    class Helicopter : AirTransport, IHelicopter
    {
        public byte BladesCount { get; set; }

        public Helicopter(int maxHeight, byte bladesCount) :
            base(maxHeight, 0)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It`s a helicopter, welcome aboard!");
        }

        public override void WriteAllProperties() =>
            Console.WriteLine($"Properties for Helicopter:\nBladesCount: {BladesCount}\nCurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");

        public override void WriteAllProperties_2()
        {
            Console.WriteLine($"Properties for Helicopter:\nBladesCount: {BladesCount}");
            base.WriteAllProperties_2();
        }
    }

    class Plane : AirTransport, IPlane
    {
        public byte EnginesCount { get; set; }

        public Plane(int maxHeight, byte enginesCount) :
            base(maxHeight, 0)
        {
            EnginesCount = enginesCount;
            Console.WriteLine("It`s a plane, welcome aboard!");
        }

        public override void WriteAllProperties() =>
            Console.WriteLine($"Properties for Plane:\nEnginesCount: {EnginesCount}\nCurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");

        public override void WriteAllProperties_2()
        {
            Console.WriteLine($"Properties for Plane:\nBladesCount: {EnginesCount}");
            base.WriteAllProperties_2();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var helicopter = new Helicopter(2000, 5);
            helicopter.WriteAllProperties();

            var plane = new Plane(10000, 4);
            plane.WriteAllProperties();
        }
    }
}
