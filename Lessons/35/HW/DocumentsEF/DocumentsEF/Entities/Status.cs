using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Status
    {
        public int Id { get; private set; }     
        public string Name { get; private set; }
        public ICollection<DocumentStatus> DocumentStatuses { get; private set; }

        public Status()
        {
            DocumentStatuses = new List<DocumentStatus>();
        }

        public Status(string name)
        {
            Name = name;           
        }
    }
}
