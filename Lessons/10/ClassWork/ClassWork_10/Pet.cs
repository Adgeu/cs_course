using System;

namespace ClassWork_10
{
    enum AnimalType
    {
        Mouse,
        Cat,
        Dog
    }

    class Pet
    {
        private string name;
        private char sex;

        public AnimalType Kind { get; set; }

        public uint Age { get; set; }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name must not be NULL or EMPTY!");

                name = value;
            }
        }

        public char Sex
        {
            get => sex;
            set
            {
                if (!value.Equals('m') && !value.Equals('m'))
                    throw new ArgumentException("Sex must be 'm' or 'f'");

                sex = value;
            }
        }     
        
        public string Description => 
            $"{Name} ({Sex}) is the {Kind.ToString()}, {Age} years old.";
    }
}