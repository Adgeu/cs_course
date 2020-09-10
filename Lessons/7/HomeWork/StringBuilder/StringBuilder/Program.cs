using System;
using System.Text;

namespace StringBuilderPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "    lorem    ipsum    dolor          sit    amet    ";

            var sb = new StringBuilder(text);

            var wordToUpperCase = 2;
            var isWord = false;
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsWhiteSpace(sb[i]))
                {
                    if (!(i > 0 && char.IsLetter(sb[i - 1]) && i < sb.Length - 1 && char.IsLetter(sb[i + 1])))
                    {
                        sb.Remove(i, 1);
                        i--;
                    }

                    isWord = false;
                }
                else
                {
                    if (!isWord)
                    {
                        wordToUpperCase--;
                        isWord = true;
                    }                        

                    if (isWord && wordToUpperCase == 0)
                        sb[i] = char.ToUpper(sb[i]);
                }
            }

            Console.WriteLine(sb.ToString());

            // ====================================================================================================================

            sb = new StringBuilder(text);

            byte changeCount = 0;
            while (changeCount < (char.IsWhiteSpace(sb[sb.Length-1]) ? 3 : 2))
            {
                char currentChar = sb[sb.Length - 1];
                sb.Remove(sb.Length - 1, 1);

                if (char.IsWhiteSpace(currentChar) != char.IsWhiteSpace(sb[sb.Length - 1]))
                    changeCount++;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
