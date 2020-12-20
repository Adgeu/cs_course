using System;

namespace DocumentsEF.Entities
{
    public class DocumentStatus
    {
        public int Id { get; private set; }
        public Document Document { get; private set; }
        public Employee Sender { get; private set; }
        public Address SenderAddress { get; private set; }
        public Employee Receiver { get; private set; }
        public Address ReceiverAddress { get; private set; }
        public Status Status { get; private set; }
        public DateTimeOffset DateTime { get; private set; }

        public DocumentStatus()
        {
        }

        public DocumentStatus(Document document, Employee sender, Address senderAddress, Employee receiver, Address receiverAddress, Status status)
            : this(document, sender, senderAddress, receiver, receiverAddress, status, DateTimeOffset.UtcNow)
        {
        }

        public DocumentStatus(Document document, 
                              Employee sender, 
                              Address senderAddress, 
                              Employee receiver, 
                              Address receiverAddress, 
                              Status status, 
                              DateTimeOffset dateTime)
        {
            Document = document;
            Sender = sender;
            SenderAddress = senderAddress;
            Receiver = receiver;
            ReceiverAddress = receiverAddress;
            Status = status;
            DateTime = dateTime;
        }

        public override string ToString() =>
            $"{Id} | " +
            $"{Document.Name} | " +
            $"{Document.Pages} | " +
            $"{Sender.FullName}, {Sender.Position} | " +
            $"{SenderAddress.City.Name}, {SenderAddress.Street}, {SenderAddress.House} | " +
            $"{Receiver.FullName}, {Receiver.Position} | " +
            $"{ReceiverAddress.City.Name}, {ReceiverAddress.Street}, {ReceiverAddress.House} | " +
            $"{Status} | " +
            $"{DateTime}";
    }
}
