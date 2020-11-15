using System;
using System.Collections.Generic;
using System.Linq;

namespace CityStorage
{

    public class Storage : IStorage
    {
        public static Storage Instance { get; } =
            new Storage();

        private List<City> _cities;

        private Storage()
        {
            _cities = new List<City>
            {
                new City(Guid.NewGuid(), "Moscow", "The capital of Russia", 16_000_000),
                new City(Guid.NewGuid(), "Tokio", "The capital of Japan", 15_000_000),
                new City(Guid.NewGuid(), "Omsk", "Dont try to leave the Omsk", 5_000_000),
                new City(Guid.NewGuid(), "Berlin", "The capital of Germany", 16_000_000),
                new City(Guid.NewGuid(), "Paris", "The capital of France", 16_000_000),
                new City(Guid.NewGuid(), "Paris", "The capital of France", 16_000_000),
                new City(Guid.NewGuid(), "Paris", "The capital of France", 16_000_000),
            };
        }

        public void Add(string title, string description, int population, out City city, out ResultStorageOperation result)
        {
            city = null;
            if (IsUnique(title))
            {
                city = new City(GetUniqueId(), title.Trim().Capitalize(), description.Trim().Capitalize(), population);
                _cities.Add(city);
                result = ResultStorageOperation.SuccessResult();
            }
            else
                result = ResultStorageOperation.NotSuccessResult("Title", $"Duplicate value: {title}");
        }

        public void Update(Guid id, string description, int population, out City city, out ResultStorageOperation result)
        {
            city = _cities.FirstOrDefault(_ => _.Id == id);

            if (city == null)
            {
                result = ResultStorageOperation.NotSuccessResult("Id", $"Requested city with not existing id {id}");
                return;
            }

            city.Update(description.Trim().Capitalize(), population);
            result = ResultStorageOperation.SuccessResult();
        }

        public void Delete(Guid id, out ResultStorageOperation result)
        {
            var city = _cities.FirstOrDefault(_ => _.Id == id);

            if (city == null)
            {
                result = ResultStorageOperation.NotSuccessResult("Id", $"Requested city with not existing id {id}");
                return;
            }

            _cities.Remove(city);
            result = ResultStorageOperation.SuccessResult();
        }

        public City[] GetAll()
        {
            return _cities.ToArray();
        }

        public City GetOne(Guid id, out ResultStorageOperation result)
        {
            var city = _cities.FirstOrDefault(_ => _.Id == id);

            if (city == null)
            {
                result = ResultStorageOperation.NotSuccessResult("Id", $"Requested city with not existing id {id}");
                return null;
            }

            result = ResultStorageOperation.SuccessResult();
            return city;
        }

        private bool IsUnique(string title)
        {
            var dublicate = _cities.FirstOrDefault(_ => _.Title == title);

            if (dublicate != null)
                return false;

            return true;
        }

        private Guid GetUniqueId()
        {
            var id = Guid.NewGuid();
            while (_cities.FirstOrDefault(_ => _.Id == id) != null)
                id = Guid.NewGuid();

            return id;
        }
    }
}