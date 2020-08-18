using System;
using System.Threading;

namespace WelcomeScreen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome!\nPlease, enter your name: ");

            string sName = Console.ReadLine();

            Console.WriteLine("Wait a few seconds...\n");

            Thread.Sleep(5000);

            Console.WriteLine($"Hello, {sName}!\nWait a few more seconds...\n");

            Thread.Sleep(5000);

            Console.WriteLine("Oh... Damn it all! I`m tired, I`m muhozhuk!\nGoodbye!\n\nPress any key to close the program...");

            Console.ReadLine();
        }
    }
}
