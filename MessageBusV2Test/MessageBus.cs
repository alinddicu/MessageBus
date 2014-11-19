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
                    Distribute += message.Receiver.ReceiveMessage;
                    Distribute(this, new MessageSentArgs(message));
                    ClearReceivers();
                }
            }
        }

        public void ClearMessages()
        {
            _messages.Clear();
        }

        public void ClearReceivers()
        {
            if (Distribute == null)
            {
                return;
            }

            foreach (dynamic deleg in Distribute.GetInvocationList())
            {
                Distribute -= deleg;
            }
        }
    }
}
