using System;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите непустую строку:");
            var txt = ReadString().ToLower();

            for (int i = txt.Length - 1; i >= 0; i--)
            {
                Console.Write(txt[i]);
            }
        }

        static string ReadString()
        {
            while (true)
            {
                var txt = Console.ReadLine();

                if (!string.IsNullOrEmpty(txt))
                    if (!IsThereANumber(txt))
                        return txt;
                    else
                        Console.WriteLine("В строке не должно быть цифр. Попробуйте ещё раз:");
                else
                    Console.WriteLine("Вы ввели пустую строку. Попробуйте ещё раз:");
            }
        }

        static bool IsThereANumber(string words)
        {
            foreach (char c in words)
            {
                if (char.IsDigit(c))
                    return true;
            }

            return false;
        }
    }
}
