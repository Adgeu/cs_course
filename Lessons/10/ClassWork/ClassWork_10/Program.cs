using System;

namespace ClassWork_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet();
            pet.Name = "Rex";
            pet.Kind = AnimalType.Dog;
            pet.Sex = 'm';
            pet.Age = 2;

            var pet2 = new Pet()
            {
                Name = "Barsik",
                Kind = AnimalType.Cat,
                Sex = 'm',
                Age = 3
            };

            Console.WriteLine(pet.Description);
            Console.WriteLine(pet2.Description);
        }   
    }
}