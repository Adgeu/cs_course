using System;

namespace ClassWork_13
{
    abstract class AirTransport
    {
        public int MaxHeight { get; private set; }

        public int CurrentHeight { get; private set; }

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

        public virtual void WriteAllProperties()=>
            Console.WriteLine($"CurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
    }

    class Helicopter : AirTransport
    {
        public byte BladesCount { get; private set; }

        public Helicopter(int maxHeight, byte bladesCount) :
            base(maxHeight, 0)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It`s a helicopter, welcome aboard!");
        }

        public override void WriteAllProperties()
        {
            Console.WriteLine($"Properties for Helicopter:\nBladesCount: {BladesCount}");
            base.WriteAllProperties();
        }
    }

    class Plane : AirTransport
    {
        public byte EnginesCount { get; private set; }

        public Plane(int maxHeight, byte enginesCount) :
            base(maxHeight, 0)
        {
            EnginesCount = enginesCount;
            Console.WriteLine("It`s a plane, welcome aboard!");
        }

        public override void WriteAllProperties()
        {
            Console.WriteLine($"Properties for Plane:\nBladesCount: {EnginesCount}");
            base.WriteAllProperties();
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
