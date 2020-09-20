using System;

namespace ClassWork_4
{
    class Program
    {
        [Flags]
        enum Colors
        {
            None = 0b0,
            Black = 0b1 << 1,
            Blue = 0b1 << 2,
            Cyan = 0b1 << 3,
            Grey = 0b1 << 4,
            Green = 0b1 << 5,
            Magenta = 0b1 << 6,
            Red = 0b1 << 7,
            White = 0b1 << 8,
            Yellow = 0b1 << 9,
        }
        static void Main(string[] args)
        {
            Colors favourites = Colors.None;
            Colors allColors = Colors.None;

            foreach (Colors color in Enum.GetValues(typeof(Colors)))
            {
                allColors |= color;
            }

            Console.WriteLine($"Enter your favourite colors ({allColors})\n");

            int count = 4;
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Add color ({count - i} remaining): ");
                favourites |= (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());
            }

            Console.WriteLine("\nFavourites colors:");
            Console.WriteLine(favourites);
            
            Console.WriteLine("\nOther colors:");
            Console.WriteLine(allColors ^ favourites);

            Console.ReadLine();
            
            //==============================================================================================================

            //Console.Write("Введите a: ");
            //var a = double.Parse(Console.ReadLine());
            //Console.Write("Введите h: ");
            //var h = double.Parse(Console.ReadLine());

            //var H = Math.Sqrt(Math.Pow(h, 2) - Math.Pow(a, 2) / 12d);
            //var SSide = 3d * a * h;
            //var SFull = 3d / 2d * a * (a * Math.Sqrt(3d) + 2d * h);
            //var V = Math.Pow(a, 2) / 2d * H * Math.Sqrt(3d);

            //Console.WriteLine($"H       = {H}\n" +
            //                  $"S(бок)  = {SSide}\n" +
            //                  $"S(полн) = {SFull}\n" +
            //                  $"V       = {V}");


        }

        
    }
}
