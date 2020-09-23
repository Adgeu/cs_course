using System;

namespace ClassWork_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var docs = new BaseDocument[]
            {
                new BaseDocument("Document", "123", DateTimeOffset.Parse("01.01.2020")),
                new Passport("456", DateTimeOffset.Parse("01.01.2019"), "Rus", "Some Name"),
                new Passport("789", DateTimeOffset.Parse("01.07.2015"), "Rus", "Some Other Name")
            };

            foreach (var doc in docs)
            {
                if (doc is Passport passport)
                    passport.ChangeIssueDate(DateTimeOffset.UtcNow);

                doc.WriteToConsole();
                Console.WriteLine();
            }
        }
    }
}
