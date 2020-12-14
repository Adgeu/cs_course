using System;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class FindReminderViewModel
	{
		public ReminderItemStatus Status { get; set; }
		public DateTimeOffset DateTime { get; set; }
	}
}