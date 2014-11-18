namespace MessageBusV2Test
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private MessageBus _messageBus;
        private List<Message> _messages;

        public User(MessageBus messageBus)
        {
            _messageBus = messageBus;
            _messages = new List<Message>();
            Send += _messageBus.Handle;
        }

        public event EventHandler<MessageSentArgs> Send;

        public void SendMessage(Message message)
        {
            if (Send != null)
            {
                Send(this, new MessageSentArgs(message));
            }
        }

        public void ReceiveMessage(object sender, MessageSentArgs args)
        {
            _messages.Add(args.Message);
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messages;
        }
    }
}
