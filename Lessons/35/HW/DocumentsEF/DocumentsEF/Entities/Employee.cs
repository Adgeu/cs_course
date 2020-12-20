using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Position Position { get; private set; }
        public ICollection<DocumentStatus> SenderDocuments { get; private set; }
        public ICollection<DocumentStatus> ReceiverDocuments { get; private set; }

        public Employee()
        {
            SenderDocuments = new List<DocumentStatus>();
            ReceiverDocuments = new List<DocumentStatus>();
        }

        public Employee(string firstName, string lastName, Position position) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;           
        }
    }
}
