namespace MessageBusTest
{
    using System.Collections.Generic;

    public class MessageBus
    {
        private List<Message> _messages;

        public MessageBus()
        {
            _messages = new List<Message>();
        }

        public void Send(Message message)
        {
            _messages.Add(message);
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messages;
        }
    }
}
