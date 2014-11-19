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
            Id = Guid.NewGuid();
            _messageBus = messageBus;
            _messages = new List<Message>();
            Send += _messageBus.Handle;
        }

        public Guid Id { get; private set; }

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
            var message = args.Message;
            if (!_messages.Contains(message))
            {
                _messages.Add(message);
            }
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messages;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this.Equals(obj as User);
        }

        protected bool Equals(User otherUser)
        {
            return Id == otherUser.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
