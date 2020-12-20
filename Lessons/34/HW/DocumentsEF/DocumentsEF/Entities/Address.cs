using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class Address
    {
        public int Id { get; private set; }        
        public City City { get; private set; }
        public string Street { get; private set; }
        public string House { get; private set; }
        public ICollection<DocumentStatus> SenderDocumentStatuses { get; private set; }
        public ICollection<DocumentStatus> ReceiverDocumentStatuses { get; private set; }

        public Address()
        {
            SenderDocumentStatuses = new List<DocumentStatus>();
            ReceiverDocumentStatuses = new List<DocumentStatus>();
        }

        public Address(City city, string street, string house) : this()
        {
            City = city;
            Street = street;
            House = house;          
        }
    }
}
