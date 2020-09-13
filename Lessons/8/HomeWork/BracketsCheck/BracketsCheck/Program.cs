using System;
using System.Collections.Generic;

namespace BracketsCheck
{
    class Program
    {
        static Dictionary<char,char> bracketsSamples = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']'
        };

        static List<string> examples = new List<string>
        {
             "()",
             "[]()",
             "[[]()]",
             "([([])])()[]",
             "(",
             "[][)",
             "[(])",
             "(()[]]"
        };

        static void Main(string[] args)
        {
            foreach (string example in examples)
                PrintResult(example, CheckBrackets(example));        
        }

        static bool CheckBrackets(string expression)
        {
            var bracketsStack = new Stack<char>();

            foreach (var symbol in expression)
            {
                if (bracketsSamples.ContainsKey(symbol))
                    bracketsStack.Push(symbol);
                else
                {
                    if (!symbol.Equals(bracketsSamples[bracketsStack.Pop()]))
                        return false;
                }
            }

            if (bracketsStack.Count > 0)
                return false;

            return true;    
        }

        static void PrintResult(string expression, bool correctness)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(expression);
            Console.ResetColor();
            Console.Write(" is ");
            Console.ForegroundColor = correctness ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(correctness.ToString().ToUpper());
            Console.ResetColor();
            Console.WriteLine(" expression!");
        }
    }
}
