using System;

namespace ClassWork_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new Account<int>(123, "Alex");
            a1.WriteProperties();

            var a2 = new Account<string>("456", "Mark");
            a2.WriteProperties();

            var a3 = new Account<Guid>(Guid.NewGuid(), "Todd");
            a3.WriteProperties();
        }
    }

    class Account<T>
    {
        public T Id { get; private set; }
        public string Name { get; private set; }

        public Account(T id, string name)
        {
            Id = id;
            Name = name;
        }

        public void WriteProperties() =>
            Console.WriteLine($"Id: {Id}\nName: {Name}");
    }
}
