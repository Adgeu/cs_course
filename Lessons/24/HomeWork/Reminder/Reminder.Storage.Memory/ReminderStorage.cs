using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage.Memory
{
	using Exceptions;

	public class ReminderStorage : IReminderStorage
	{
		private readonly Dictionary<Guid, ReminderItem> _items;

		public ReminderStorage()
		{
			_items = new Dictionary<Guid, ReminderItem>();
		}

		public ReminderStorage(params ReminderItem[] items)
		{
			_items = items.ToDictionary(item => item.Id);
		}

		public void Add(ReminderItem item)
		{
			if (_items.ContainsKey(item.Id))
			{
				throw new ReminderItemAlreadyExistsException(item.Id);
			}

			_items[item.Id] = item;
		}

		public void Update(ReminderItem item)
		{
			if (!_items.ContainsKey(item.Id))
			{
				throw new ReminderItemNotFoundException(item.Id);
			}

			_items[item.Id] = item;
		}

		public ReminderItem Get(Guid id)
		{
			if (!_items.TryGetValue(id, out var item))
			{
				throw new ReminderItemNotFoundException(id);
			}

			return item;
		}

		public ReminderItem[] Find(ReminderItemFilter filter)
		{
			var query = _items.Values.AsEnumerable();

			if (filter.Status.HasValue)
			{
				query = query.Where(item => item.Status == filter.Status.Value);
			}

			if (filter.DateTime.HasValue)
			{
				query = query.Where(item => item.DateTime <= filter.DateTime.Value);
			}

			return query.OrderByDescending(item => item.DateTime).ToArray();
		}
	}
}