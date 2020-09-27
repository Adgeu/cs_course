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

        public virtual string WriteProperties() =>
            $"{this.GetType().Name}\nAlarmDate: {AlarmDate}\nAlarmMessage: {AlarmMessage}\nTimeToAlarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}";

    }
    
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber) :
            base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override string WriteProperties() =>
            base.WriteProperties() + $"\nPhoneNumber: {PhoneNumber}";

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

        public override string WriteProperties() =>
            base.WriteProperties() + $"\nChatName: {ChatName}\nAccountName: {AccountName}";
    }
}