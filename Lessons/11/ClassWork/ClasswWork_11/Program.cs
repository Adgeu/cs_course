using System;

namespace ClasswWork_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet("Cat", "Barsik", 'M', DateTimeOffset.Parse("01/05/2019"));

            pet.WriteProperties(true);
            pet.WriteProperties();
        }

        
    }

}
