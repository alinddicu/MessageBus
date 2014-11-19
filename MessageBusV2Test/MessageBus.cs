namespace MessageBusV2Test
{
    using System;
    using System.Collections.Generic;

    public class MessageBus
    {
        private List<Message> _messages;

        public MessageBus()
        {
            _messages = new List<Message>();
        }

        public event EventHandler<MessageSentArgs> Distribute;

        public IEnumerable<Message> GetMessages()
        {
            return _messages;
        }

        public void Handle(object o, MessageSentArgs args)
        {
            var message = args.Message;
            if (!_messages.Contains(message))
            {
                _messages.Add(message);
                if (message.Receiver != null)
                {
                    EventHandler<MessageSentArgs> receiverHandle = message.Receiver.ReceiveMessage;
                    Distribute += receiverHandle;
                    Distribute(this, new MessageSentArgs(message));
                    Distribute -= receiverHandle;
                }
            }
        }

        public void ClearMessages()
        {
            _messages.Clear();
        }
    }
}
