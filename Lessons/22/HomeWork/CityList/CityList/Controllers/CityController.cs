using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityList.Controllers
{
	using Model;
	using ViewModels;

	[Route("/api/cities")]
	public class CityController : Controller
	{
		public Storage Storage =>
			Storage.Instance;

		[HttpGet]
		public IActionResult List()
		{
			return Ok(Storage.Cities);
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			var city = Storage
				.Cities
				.FirstOrDefault(_ => _.Id == id);
			if (city == null)
				return NotFound();

			return Ok(city);
		}

		[HttpPost]
		public IActionResult Create([FromBody] CityCreateViewModel info)
		{
			var city = new City(Guid.NewGuid(), info.Title, info.Description, info.Population);
			Storage.Cities.Add(city);

			return CreatedAtAction("Get", new { id = city.Id }, city);
		}

		[HttpPut("{id}")]
		public IActionResult Put(Guid id, [FromBody] CityUpdateViewModel info)
        {
			var city = Storage
				.Cities
				.FirstOrDefault(_ => _.Id == id);

			if (city == null)
				return NotFound();

			city.Update(info.Description, info.Population);

			return CreatedAtAction("Get", new { id = city.Id }, city);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var city = Storage
				.Cities
				.FirstOrDefault(_ => _.Id == id);

			if (city == null)
				return NotFound();

			Storage.Cities.Remove(city);

			return Ok();
		}
	}
}