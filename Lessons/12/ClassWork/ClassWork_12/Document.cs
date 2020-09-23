using System;

namespace ClassWork_12
{
    class BaseDocument
    {
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public virtual string Description =>
            $"Title: {Title}\nNumber: {Number}\nIssueDate: {IssueDate}";

        public BaseDocument(string title, string number, DateTimeOffset issueDate)
        {
            Title = title;
            Number = number;
            IssueDate = issueDate;
        }

        public void WriteToConsole() =>
            Console.WriteLine(Description);
    }

    class Passport : BaseDocument
    { 
        public string Country{ get; set; }
        public string PersonName { get; set; }
        public override string Description =>
            $"Title: {Title}\nNumber: {Number}\nIssueDate: {IssueDate}\nCountry: {Country}\nPersonName: {PersonName}";

        public Passport(string number, DateTimeOffset issueDate, string country, string personName) :
            base("Passport", number, issueDate)
        {
            Country = country;
            PersonName = personName;
        }

        public void ChangeIssueDate(DateTimeOffset newIssueDate) =>
            IssueDate = newIssueDate;
    }
}
