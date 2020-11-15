using System;
using Microsoft.AspNetCore.Mvc;

namespace CityList.Controllers
{
    using CityStorage;
    using Microsoft.Extensions.Logging;
    using ViewModels;

	[Route("/api/cities")]
	public class CityController : Controller
	{
		public IStorage Storage { get; }
		public ILogger<CityController> Logger { get; }

		public CityController(IStorage storage, ILogger<CityController> logger)
		{
			Storage = storage;
			Logger = logger;
		}

		[HttpGet]
		public IActionResult List(int page, int perPage)
		{
			if (page <= 0)
				return Ok(Storage.GetAll());

			if (perPage <= 0)
				perPage = 1;

			return Ok(new Page(page, perPage, Storage.GetAll()));
		}



		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			var city = Storage.GetOne(id, out var result);

			if (!result)
            {
				Logger.LogWarning(result.Message);
				return NotFound();
			}			

			return Ok(city);
		}

		[HttpPost]
		public IActionResult Create([FromBody] CityCreateViewModel info)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			Storage.Add(
					info.Title,
					info.Description,
					info.Population,
					out var city,
					out var result);

			if (!result)
				ModelState.AddModelError(result.MessageTitle, result.Message);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return CreatedAtAction("Get", new { id = city.Id }, city);
		}

		[HttpPut("{id}")]
		public IActionResult Update(Guid id, [FromBody] CityUpdateViewModel info)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			Storage.Update(
					id, 
					info.Description, 
					info.Population, 
					out var city, 
					out var result);

			if (!result)
				ModelState.AddModelError(result.MessageTitle, result.Message);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			city.Update(info.Description, info.Population);

			return CreatedAtAction("Get", new { id = city.Id }, city);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			Storage.Delete(id, out var result);

			if (!result)
				ModelState.AddModelError(result.MessageTitle, result.Message);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return NoContent();
		}
	}
}