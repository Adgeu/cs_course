using System;
using System.Collections.Generic;

namespace CityStorage
{
    public interface IStorage
    {
        /// <summary>
        /// Add city to the list
        /// </summary>
        /// <param name="title">The title of the city</param>
        /// <param name="description">The description of the city</param>
        /// <param name="population">The population of the city</param>
        /// <param name="city">Added city</param>
        /// <param name="result">Success of the operation</param>
		public void Add(string title, string description, int population, out City city, out ResultStorageOperation result);

        /// <summary>
        /// Update existing city
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <param name="description">New description</param>
        /// <param name="population">New population</param>
        /// <param name="city">Updated city</param>
        /// <param name="result">Success of the operation</param>
		public void Update(Guid id, string description, int population, out City city, out ResultStorageOperation result);

        /// <summary>
        /// Delete city from list
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <param name="result">Success of the operation</param>
		public void Delete(Guid id, out ResultStorageOperation result);

        /// <summary>
        /// Get all cities in the list
        /// </summary>
        /// <returns></returns>
		public City[] GetAll();

        /// <summary>
        /// Get city by ID
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <param name="result">Success of the operation</param>
        /// <returns></returns>
		public City GetOne(Guid id, out ResultStorageOperation result);
    }
}