using System;

namespace Reminder.Storage
{
	/// <summary>
	///   Represents one reminder
	/// </summary>
	public class ReminderItem
	{
		/// <summary>
		///   Unique identifier
		/// </summary>
		public Guid Id { get; }

		/// <summary>
		///   Date and time to sent in UTC format
		/// </summary>
		public DateTimeOffset DateTime { get; private set; }

		/// <summary>
		///   The status from <see cref="ReminderItemStatus"/>
		/// </summary>
		public ReminderItemStatus Status { get; private set; }

		public string Message { get; private set; }
		public string ContactId { get; private set; }

		public ReminderItem(
			Guid id,
			ReminderItemStatus status,
			DateTimeOffset datetime,
			string message,
			string contactId)
		{
			Id = id;
			Status = status;
			DateTime = datetime;
			Message = message;
			ContactId = contactId;
		}

		public void MarkSent() =>
			MoveToState(ReminderItemStatus.Ready, ReminderItemStatus.Sent);

		public void MarkFailed() =>
			MoveToState(ReminderItemStatus.Ready, ReminderItemStatus.Failed);

		public void MarkReady() =>
			MoveToState(ReminderItemStatus.Created, ReminderItemStatus.Ready);

		public override string ToString() =>
			$"Reminder (id: {Id}, status: {Status}) at {DateTime:O} to {ContactId}";

		private void MoveToState(ReminderItemStatus allowedStatus, ReminderItemStatus targetStatus)
		{
			if (Status != allowedStatus)
			{
				throw new InvalidOperationException(
					$"Reminder should be in {allowedStatus} status");
			}

			Status = targetStatus;
		}
	}
}