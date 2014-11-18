namespace MessageBusV2Test
{
    using System.Collections.Generic;

    public class MessageBus
    {
        private List<Message> _messages;

        public MessageBus()
        {
            _messages = new List<Message>();
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messages;
        }

        public void Receive(object o, MessageSentArgs args)
        {
            var message = args.Message;
            if (!_messages.Contains(message))
            {
                _messages.Add(message);
            }
        }
    }
}
