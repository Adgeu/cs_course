using System;
using System.Text;

namespace ClassWork_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new StringBuilder("    lorem    ipsum     dolor         sit     amet   ");
        }

        static void Old()
        {
            #region Modify
            //var text = "    lorem    ipsum     dolor         sit     amet   ";

            //var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //words[1] = words[1].ToUpper();

            //Console.WriteLine(string.Join(' ', words));
            //Console.WriteLine(text.Substring(0, text.TrimEnd().LastIndexOf(' ')).TrimEnd());
            #endregion

            #region Formating Strings
            //Console.WriteLine("Enter two real numbers:");
            //var first = double.Parse(Console.ReadLine());
            //var second = double.Parse(Console.ReadLine());

            //Console.WriteLine(first + " * " + second + " = " + first * second);
            //Console.WriteLine(string.Format("{0} + {1} = {2}", first, second, first + second));
            //Console.WriteLine($"{first} - {second} = {first - second:0.##}");
            #endregion
        }
    }
}
