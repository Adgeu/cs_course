using System;

namespace Reminder.Storage
{
	public interface IReminderStorage
	{
		void Add(ReminderItem item);

		void Update(ReminderItem item);

		ReminderItem Get(Guid id);

		ReminderItem[] Find(ReminderItemFilter filter);
	}
}