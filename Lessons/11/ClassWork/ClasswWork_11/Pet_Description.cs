using System;

namespace ClasswWork_11
{
    partial class Pet
    {
        public string Description =>
            $"Name: {Name}, Kind: {Kind}, Sex: {Sex}, Age: {Age()}";

        public string ShortDescription =>
            $"Name: {Name}, Age: {Age()}";

        public void WriteProperties(bool showFullDescription = false) =>
            Console.WriteLine(showFullDescription ? Description : ShortDescription);
    }
}
