using System;

namespace PersonList
{
    class Person
    {
        public string PersonName { get; set; }
        public byte PersonAge { get; set; }

        public byte AgeIn4Years => 
            (byte)(PersonAge + 4);

        public string PersonInfo => 
            $"Name: {PersonName}, age in 4 years: {AgeIn4Years}";

        public Person(string personName, byte personAge)
        {
            PersonName = personName;
            PersonAge = personAge;
        }
    }
}
