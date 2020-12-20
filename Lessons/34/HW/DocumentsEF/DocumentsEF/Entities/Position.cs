using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Employee> Employees { get; private set; }

        public Position()
        {
            Employees = new List<Employee>();
        }

        public Position(string name) : this()
        {
            Name = name;          
        }
    }
}
