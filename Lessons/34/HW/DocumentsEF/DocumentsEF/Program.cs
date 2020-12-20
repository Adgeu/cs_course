using System;
using DocumentsEF.Entities;

namespace DocumentsEF
{
    class Program
    {
        static void Main(string[] args)
        {
            EnsureDatabaseCreated();
            InsertData();
            ReadData();
        }

        private static void ReadData()
        {
            using var context = new DocumentsContext();
            foreach (var item in context.DocumentStatuses)
                Console.WriteLine(item);
        }

        private static void InsertData()
        {
            using var context = new DocumentsContext();

            var doc1 = new Document("Программа курса", 364);
            var doc2 = new Document("Рецензия", 7);
            context.Documents.AddRange(new[] { doc1, doc2});

            var city1 = new City("Москва");
            var city2 = new City("Санкт-Петербург");
            var city3 = new City("Самара");
            context.Cities.AddRange(new[] { city1, city2, city3});

            var position1 = new Position("Преподаватель курса");
            var position2 = new Position("Рецензент");
            context.Positions.AddRange(new[] { position1, position2 });

            var status1 = new Status("Ожидает отправки");
            var status2 = new Status("Отправлен");
            var status3 = new Status("Получен");
            context.Statuses.AddRange(new[] { status1, status2, status3});

            var address1 = new Address(city1, "Большая Садовая", "10");
            var address2 = new Address(city2, "Сенная", "30");
            var address3 = new Address(city2, "Мира", "13");
            context.Addresses.AddRange(new[] { address1, address2, address3});

            var employee1 = new Employee("Фёдоров Фёдор Фёдорович", position1);
            var employee2 = new Employee("Иванов Иван Иванович", position2);
            context.Employees.AddRange(new[] { employee1, employee2});

            context.DocumentStatuses.Add(new DocumentStatus(
                doc1,
                employee1,
                address1,
                employee2,
                address2,
                status1,
                DateTimeOffset.Parse("2019-05-25 11:55:00 +00:03")
            ));
            context.DocumentStatuses.Add(new DocumentStatus(
                doc1,
                employee1,
                address1,
                employee2,
                address2,
                status2,
                DateTimeOffset.Parse("2019-05-25 14:00:00 +00:03")
            ));
            context.DocumentStatuses.Add(new DocumentStatus(
                doc1,
                employee1,
                address1,
                employee2,
                address2,
                status3,
                DateTimeOffset.Parse("2019-05-26 8:00:00 +00:03")
            ));
            context.DocumentStatuses.Add(new DocumentStatus(
                doc2,
                employee2,
                address2,
                employee1,
                address1,
                status1,
                DateTimeOffset.Parse("2019-05-28 21:00:00 +00:03")
            ));
            context.DocumentStatuses.Add(new DocumentStatus(
                doc2,
                employee2,
                address2,
                employee1,
                address1,
                status2,
                DateTimeOffset.Parse("2019-05-29 10:15:00 +00:03")
            ));
            context.DocumentStatuses.Add(new DocumentStatus(
                doc2,
                employee2,
                address2,
                employee1,
                address1,
                status3,
                DateTimeOffset.Parse("2019-05-30 15:30:00 +00:03")
            ));

            context.SaveChanges();
        }

        private static void EnsureDatabaseCreated()
        {
            using var context = new DocumentsContext();
            context.Database.EnsureCreated();
        }
    }
}
