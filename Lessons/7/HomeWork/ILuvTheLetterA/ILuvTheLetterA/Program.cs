using System;

namespace ILuvTheLetterA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку из нескольких слов:");
            var words = ReadString();

            var letterACount = 0;
            foreach (string word in words)
            {
                if (word.ToLower()[0].Equals('а'))
                    letterACount++;
            }

            Console.WriteLine($"Количество слов, начинающихся с буквы 'А': {letterACount}.\nНажмите любую клавишу для выхода...");
        }

        static string[] ReadString()
        {
            while (true)
            {               
                var words = Console.ReadLine()?.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (words != null && words.Length > 2)
                    if (!IsThereANumber(words))
                        return words;
                    else
                        Console.WriteLine("В строке не должно быть цифр. Попробуйте ещё раз:");
                else
                    Console.WriteLine("Слишком мало слов. Попробуйте ещё раз:");
            }
        }

        static bool IsThereANumber(string[] words)
        {
            foreach (char c in string.Join(null, words))
            {
                if (char.IsDigit(c))
                    return true;
            }

            return false;
        }
    }
}
