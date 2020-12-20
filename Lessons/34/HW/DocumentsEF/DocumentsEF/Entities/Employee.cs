using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Employee
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public Position Position { get; private set; }
        public ICollection<DocumentStatus> SenderDocuments { get; private set; }
        public ICollection<DocumentStatus> ReceiverDocuments { get; private set; }

        public Employee()
        {
            SenderDocuments = new List<DocumentStatus>();
            ReceiverDocuments = new List<DocumentStatus>();
        }

        public Employee(string fullName, Position position) : this()
        {
            FullName = fullName;
            Position = position;           
        }
    }
}
