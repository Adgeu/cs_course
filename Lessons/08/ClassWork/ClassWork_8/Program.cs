using System;
using System.Collections.Generic;

namespace ClassWork_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var dishes = new Stack<string>();

            var isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("Введите одну из команд (wash, dry, exit):");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "wash":
                        dishes.Push("тарелка");
                        Console.WriteLine($"Кол-во тарелок на вытирание: {dishes.Count}\n");

                        break;
                    case "dry":
                        if (dishes.Count > 0) 
                        {
                            dishes.Pop();
                            Console.WriteLine($"Кол-во тарелок на вытирание: {dishes.Count}\n");
                        }
                        else
                            Console.WriteLine("Стопка тарелок пуста!\n");

                        break;
                    case "exit":
                        isContinue = false;
                        Console.WriteLine($"Выход!\nКол-во тарелок на вытирание: {dishes.Count}");

                        break;
                    default:
                        Console.WriteLine("Введена неверная команда!\n");

                        break;
                }
            }
        }

        static void Old()
        {
            #region Stack
            //var dishes = new Stack<string>();

            //var isContinue = true;
            //while (isContinue)
            //{
            //    Console.WriteLine("Введите одну из команд (wash, dry, exit):");
            //    var input = Console.ReadLine();

            //    switch (input)
            //    {
            //        case "wash":
            //            dishes.Push("тарелка");
            //            Console.WriteLine($"Кол-во тарелок на вытирание: {dishes.Count}\n");

            //            break;
            //        case "dry":
            //            if (dishes.Count > 0)
            //            {
            //                dishes.Pop();
            //                Console.WriteLine($"Кол-во тарелок на вытирание: {dishes.Count}\n");
            //            }
            //            else
            //                Console.WriteLine("Стопка тарелок пуста!\n");

            //            break;
            //        case "exit":
            //            isContinue = false;
            //            Console.WriteLine($"Выход!\nКол-во тарелок на вытирание: {dishes.Count}");

            //            break;
            //        default:
            //            Console.WriteLine("Введена неверная команда!\n");

            //            break;
            //    }
            //}
            #endregion

            #region Queue
            //var queue = new Queue<double>();

            //while (true)
            //{
            //    Console.WriteLine("Введите число, либо одну из команд (\"run\", \"exit\": ");

            //    var input = Console.ReadLine();
            //    var result = double.TryParse(input, out var number);

            //    if (result)
            //        queue.Enqueue(number);
            //    else
            //    {
            //        if (input.Equals("run", StringComparison.OrdinalIgnoreCase))
            //        {
            //            while (queue.Count > 0)
            //                Console.WriteLine(Math.Sqrt(queue.Dequeue()));
            //        }
            //        else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            //        {
            //            Console.WriteLine($"Задач осталось: {queue.Count}");
            //            break;
            //        }
            //        else
            //            Console.WriteLine("Неправильный ввод!");
            //    }
            //}
            #endregion

            #region Dictionary
            //var countries = new Dictionary<string, string>
            //{
            //    ["Россия"] = "Москва",
            //    ["Великобритания"] = "Лондон",
            //    ["США"] = "Вашингтон"
            //};

            //var random = new Random();
            //while (true)
            //{
            //    var country = "";
            //    var target = random.Next(countries.Count);
            //    var currentPosition = 0;
            //    foreach (var item in countries.Keys)
            //    {
            //        country = item;

            //        if (target == ++currentPosition)
            //            break;
            //    }

            //    Console.Write($"Столица {country}: ");

            //    var input = Console.ReadLine();

            //    if (countries[country].Equals(input, StringComparison.InvariantCultureIgnoreCase))
            //        Console.WriteLine("Правильно!");
            //    else
            //    {
            //        Console.WriteLine("Неправильно!");
            //        break;
            //    }
            //}
            #endregion

            #region List
            //var list = ReadNumbers();

            //var sum = 0.0;
            //foreach (double num in list)
            //    sum += num;

            //Console.WriteLine($"Сумма = {sum}");
            //Console.WriteLine($"Среднее арифметическое = {sum / list.Count}");

            //===static List<double> ReadNumbers()===
            //var list = new List<double>();
            //while (true)
            //{
            //    Console.WriteLine("Введите число:");
            //    var number = 0.0;
            //    var input = Console.ReadLine();
            //    var result = double.TryParse(input, out number);

            //    if (result)
            //        list.Add(number);
            //    else
            //    {
            //        if (input.Equals("stop"))
            //            return list;
            //        else
            //            Console.WriteLine("Вы ввели нечисловое значение!");
            //    }
            //}
            #endregion
        }
    }
}
