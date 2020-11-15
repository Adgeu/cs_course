using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IMovable car = (IMovable)(new Car());

            car.GetModels().ForEach(model => Console.WriteLine(model));
        }

        public interface IMovable
        {
            void Move();

            List<string> GetModels();
        }

        class Car : IMovable
        {
            List<string> models = new List<string>
            {
                "1",
                "2",
                "3"
            };

            public List<string> GetModels()
            {
                return models;
            }

            public void Move()
            {
                Console.WriteLine("Move!");
            }
        }
    }
}
