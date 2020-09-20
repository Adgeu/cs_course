using System;
using System.Collections.Generic;

namespace PersonList
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = ReadPersons(3);

            foreach (var person in personList)
                Console.WriteLine(person.PersonInfo);

            Console.WriteLine("Press any key to continue..");
        }

        static List<Person> ReadPersons(int count)
        {
            var personList = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                string name;
                byte age;

                // Name Input
                Console.WriteLine($"Enter the name of the {i + 1} person:");
                while (true)
                {
                    name = Console.ReadLine();

                    if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                        break;

                    Console.WriteLine("Input Error! Please, try again:");
                }

                // Age Input
                Console.WriteLine($"Enter the age of the {i + 1} person:");
                while (true)
                {
                    var result = byte.TryParse(Console.ReadLine(), out age);

                    if (result)
                        break;

                    Console.WriteLine("Input Error! Please, try again:");
                }

                personList.Add(new Person(name, age));
            }

            return personList;
        }
    }
}
