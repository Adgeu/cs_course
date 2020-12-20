using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Document
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Pages { get; private set; }
        public ICollection<DocumentStatus> DocumentStatuses { get; private set; }

        public Document()
        {
            DocumentStatuses = new List<DocumentStatus>();
        }

        public Document(string name, int pages) : this()
        {
            Name = name;
            Pages = pages;
        }
    }
}
