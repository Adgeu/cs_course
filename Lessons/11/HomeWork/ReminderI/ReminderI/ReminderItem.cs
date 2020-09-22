using System;

namespace Reminder
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }

        public string AlarmMessage { get; set; }

        public TimeSpan TimeToAlarm =>
            DateTimeOffset.Now - AlarmDate;

        public bool IsOutdated =>
            TimeToAlarm >= TimeSpan.Zero;

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public string WriteProperties() =>
            $"AlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}";

    }
}