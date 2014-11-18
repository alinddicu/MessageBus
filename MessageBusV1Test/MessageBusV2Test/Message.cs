namespace MessageBusV2Test
{
    using System;

    public class Message
    {
        public User _sender;
        public User _receiver;

        public Message(User sender, User receiver)
        {
            Id = Guid.NewGuid();
            _sender = sender;
            _receiver = receiver;
        }

        public Guid Id { get; private set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(this, null))
            {
                return false;
            }

            return base.Equals(obj as Message);
        }

        protected bool Equals(Message message)
        {
            return Equals(this.Id, message.Id);
        }
    }
}
