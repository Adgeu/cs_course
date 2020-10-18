using System;
using NUnit.Framework;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.Memory.Tests
{
	public class ReminderStorageTests
	{
		[Test]
		public void Get_GivenNotExistingId_ShouldRaiseException()
		{
			var storage = new ReminderStorage();
			var itemId = Guid.NewGuid();

			var exception = Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.Get(itemId)
			);
			Assert.AreEqual(itemId, exception.Id);
		}

		[Test]
		public void Get_GivenExistingItem_ShouldReturnIt()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var item = ReminderItem(itemId);
			var storage = new ReminderStorage(item);

			// Act
			var result = storage.Get(itemId);

			// Assert
			Assert.AreEqual(itemId, result.Id);
		}

		[Test]
		public void Add_AddNewItem_ShouldAddNewItem()
        {
			var itemId = Guid.NewGuid();
			var storage = new ReminderStorage();

			storage.Add(ReminderItem(itemId));
			var result = storage.Get(itemId);

			Assert.AreEqual(itemId, result.Id);
		}

		[Test]
		public void Update_UpdateExistingItem_ShouldUpdateItem()
		{
			var itemId = Guid.NewGuid();
			var item = ReminderItem(itemId);
			var storage = new ReminderStorage(item);

			item.Message = "UpdatedMessage";
			storage.Update(item);

			Assert.AreEqual("UpdatedMessage", storage.Get(itemId).Message);
		}

		[Test]
		public void Update_UpdateNotExistingItem_ShouldRaiseException()
		{		
			var storage = new ReminderStorage(ReminderItem(Guid.NewGuid()));
			var itemId = Guid.NewGuid();			

			var exception = Assert.Catch<ReminderItemNotFoundException>(() =>
				storage.Update(ReminderItem(itemId))
			);
			Assert.AreEqual(itemId, exception.Id);
		}

		public ReminderItem ReminderItem(Guid id)
		{
			return new ReminderItem(id, 
				ReminderItemStatus.Created,
				DateTimeOffset.UtcNow,
				"Message",
				"ContactId");
		}
		
	}
}