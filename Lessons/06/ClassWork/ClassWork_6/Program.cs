using System;

namespace ClassWork_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Old();
        }

        static void Old()
        {
            #region foreach
            //Console.Write("Введите размер массива: ");
            //var array = new int[int.Parse(Console.ReadLine())];

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write($"Введите {i + 1}-й элемент массива: ");
            //    array[i] = int.Parse(Console.ReadLine());
            //}

            //Console.WriteLine("Результат:");
            //foreach (var num in array)
            //{
            //    Console.WriteLine(num);
            //}
            #endregion

            #region for
            //var marks = new int[][]
            //{
            //    new [] {2,3,3,2,3},
            //    new [] {2,4,5,3},
            //    null,
            //    new [] {5,5,5,5},
            //    new [] {4}
            //};

            //var allMarksSum = 0.0;
            //var marksCount = 0;

            //for (int i = 0; i < marks.Length; i++)
            //{
            //    if (marks[i] != null)
            //    {
            //        double sum = 0;
            //        for (int j = 0; j < marks[i].Length; j++)
            //        {
            //            sum += marks[i][j];
            //            marksCount++;
            //        }
            //        allMarksSum += sum;

            //        Console.WriteLine($"The average mark for day #{i} is {Math.Round(sum / marks[i].Length, 1)}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"The average mark for day #{i} is N/A");
            //    }
            //}

            //Console.WriteLine("The average mark for all the week is " + Math.Round(allMarksSum / marksCount, 1));
            #endregion

            #region while
            //var array = new int[] { 1, 2, 3 };

            //var sum = 0;
            //var counter = 0;
            //while (counter < array.Length)
            //{
            //    sum += array[counter++];
            //    Console.WriteLine("The sum is " + sum);
            //}
            #endregion

            #region continue
            //do
            //{
            //    Console.Write("Entered the string: ");

            //    string input = Console.ReadLine();

            //    if (input == "exit")
            //    {
            //        break;
            //    }
            //    else if (input.Length > 15)
            //    {
            //        Console.WriteLine("Too long string. Try another:");
            //        continue;
            //    }

            //    Console.WriteLine("Entered string length is " + input.Length);
            //}
            //while (true);
            #endregion

            #region break
            //do
            //{
            //    Console.Write("Введите слово: ");

            //    string input = Console.ReadLine();
            //    if (input.Length > 15 || input == "exit")
            //    {
            //        Console.WriteLine("Длина строки больше 15-ти символов, либо было введено слово \"exit\"!");
            //        break;
            //    }
            //}
            //while (true);
            #endregion

            #region do...while
            //do
            //{
            //    Console.Write("Введите слово \"exit\": ");
            //}
            //while (Console.ReadLine() != "exit");
            #endregion

        }
    }
}

