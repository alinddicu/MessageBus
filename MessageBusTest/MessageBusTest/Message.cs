namespace MessageBusTest
{
    using System;

    public class Message
    {
        private readonly Guid _id;

        private readonly Speaker _sender;

        private readonly DateTime _timeStamp;

        private readonly MessageBus _messageBus;

        public Message(Speaker sender, MessageBus messageBus)
        {
            _id = Guid.NewGuid();
            _sender = sender;
            _timeStamp = DateTime.Now;
            _messageBus = messageBus;
        }

        public MessageContent Content { get; set; }

        public void Send(Speaker receiver)
        {
            _messageBus.Send(this);
        }

        public void SetContent(MessageContent content)
        {
            Content = content;
        }

        public override string ToString()
        {
            return Content.ToString();
        }
    }
}
