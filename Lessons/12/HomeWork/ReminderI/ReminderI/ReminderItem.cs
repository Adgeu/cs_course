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

        public virtual void WriteProperties() =>
            Console.WriteLine(this);

        public override string ToString() =>
            $"{GetType().Name}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}";
    }
    
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber) :
            base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override void WriteProperties() =>
            Console.WriteLine(this);

        public override string ToString() =>
            base.ToString() + $"\nPhoneNumber: {PhoneNumber}";
    }

    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }

        public string AccountName { get; set; }

        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName) :
            base(alarmDate, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override void WriteProperties() =>
            Console.WriteLine(this);

        public override string ToString() =>
            base.ToString() + $"\nChatName: {ChatName}\nAccountName: {AccountName}";
    }
}