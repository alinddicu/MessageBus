namespace MessageBusV2Test
{
    using System;

    public class Message
    {
        private User _sender;

        public Message(User sender, User receiver)
        {
            Id = Guid.NewGuid();
            _sender = sender;
            Receiver = receiver;
        }

        public Guid Id { get; private set; }

        public User Receiver { get; private set; }

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

            return Equals(obj as Message);
        }

        private bool Equals(Message message)
        {
            return Equals(this.Id, message.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
