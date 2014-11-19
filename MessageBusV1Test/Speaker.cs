namespace MessageBusTest
{
    using System;

    public class Speaker
    {
        private readonly Guid _id;

        private readonly MessageBus _messageBus;

        private readonly MessageContent _content;

        public Speaker(MessageBus messageBus)
        {
            _id = Guid.NewGuid();
            _messageBus = messageBus;
        }

        public Message CreateMessage(MessageContent content)
        {
            var message = new Message(this, _messageBus);
            message.SetContent(content);
            return message;
        }
    }
}
