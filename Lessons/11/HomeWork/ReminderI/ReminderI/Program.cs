using System;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminder1 = new ReminderItem(DateTimeOffset.Parse("22.09.2020 8:00"), "ПОДЪЁМ!");
            Console.WriteLine(reminder1.WriteProperties());

            Console.WriteLine();

            var reminder2 = new ReminderItem(DateTimeOffset.Parse("29.09.2020 00:00"), "Не забыть, что нужно лечь спать");
            Console.WriteLine(reminder2.WriteProperties());
        }
    }
}
