using System;
using System.Collections.Generic;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminderItems = new List<ReminderItem>
            {
                new ReminderItem(DateTimeOffset.Now.AddDays(1), "Практиковаться в программировании"),
                new PhoneReminderItem(DateTimeOffset.Now.AddDays(2), "Практиковаться в сновидении", "777-77-77"),
                new ChatReminderItem(DateTimeOffset.Now.AddDays(3), "Практиковаться в практиковании", "Иванов Иван Иванович", "nagibator666")
            };

            foreach (var reminder in reminderItems)
                Console.WriteLine(reminder.WriteProperties() + "\n"); 
        }
    }
}
