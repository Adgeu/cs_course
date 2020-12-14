using System;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Reminder.Storage.Exceptions;
using Reminder.Tests;
using Reminder.WebApi;

namespace Reminder.Storage.WebApi.Tests
{
	public class ReminderStorageTests
	{
		private WebApplicationFactory<Startup> Factory =>
			new WebApplicationFactory<Startup>();

		[Test]
		public void Get_WhenReminderNotExists_ShouldRaiseException()
		{
			var storage = new ReminderStorage(Factory.CreateClient());

			Assert.Throws<ReminderItemNotFoundException>(
				() => storage.Get(Guid.NewGuid())
			);
		}

		[Test]
		public void Create_WithCorrectData_ShouldReturnById()
		{
			var id = Guid.NewGuid();
			var storage = new ReminderStorage(Factory.CreateClient());

			storage.Add(Create.Reminder.WithId(id));
			var item = storage.Get(id);

			Assert.IsNotNull(item);
			Assert.AreEqual(id, item.Id);
		}
	}
}