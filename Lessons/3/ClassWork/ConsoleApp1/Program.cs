using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = new string[5];

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Console.ReadLine();
            }

            Console.WriteLine("===========================");

            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine(values[i]);
            }
          
        }
    }
}
