using System;

namespace Reminder.Storage
{
	public class ReminderItemFilter
	{
		public DateTimeOffset? DateTime { get; }

		public ReminderItemStatus? Status { get; }

		public bool HasFilter =>
			DateTime.HasValue || Status.HasValue;

		private ReminderItemFilter(DateTimeOffset? dateTime, ReminderItemStatus? status)
		{
			DateTime = dateTime;
			Status = status;
		}

		public static ReminderItemFilter ByDateAndStatus(DateTimeOffset dateTime, ReminderItemStatus status) =>
			new ReminderItemFilter(dateTime, status);

		public static ReminderItemFilter ByStatus(ReminderItemStatus status) =>
			ByDateAndStatus(default, status);

		public static ReminderItemFilter CreatedAt(DateTimeOffset dateTime) =>
			ByDateAndStatus(dateTime, ReminderItemStatus.Created);

		public static ReminderItemFilter CreatedAtNow() =>
			ByDateAndStatus(DateTimeOffset.UtcNow, ReminderItemStatus.Created);
	}
}