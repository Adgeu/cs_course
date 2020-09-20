using System;

namespace EnterTheNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[3];
            int[] ages = new int[names.Length];

            // Fill the names from user input
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write("Enter the name: ");
                names[i] = Console.ReadLine();              
            }

            Console.Write("\n"); // Make a space between entering the name and the age

            // Fill the ages from user input
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($"Enther the age for {names[i]}: ");
                ages[i] = int.Parse(Console.ReadLine());
            }

            // Separator
            Console.WriteLine("\n===========================================\n");

            // Write all person info in console
            for (int i = 0; i < names.Length; i++)
            {
                Print(names[i], ages[i] + 4);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Print name and age in the specified format
        /// </summary>
        /// <param name="name">Person name</param>
        /// <param name="age">Person age</param>
        static void Print(string name, int age)
        {
            Console.Write("Name: ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(name);
            Console.ResetColor();

            Console.Write(", age in 4 years: ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(age);
            Console.ResetColor();
        }
    }
}
