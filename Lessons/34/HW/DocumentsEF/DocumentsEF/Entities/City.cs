using System.Collections.Generic;

namespace DocumentsEF.Entities
{
    public class City
    {
        public int Id { get; private set; }     
        public string Name { get; private set; }
        public ICollection<Address> Addresses { get; private set; }

        public City()
        {
            Addresses = new List<Address>();
        }

        public City(string name) : this()
        {
            Name = name;         
        }
    }
}
