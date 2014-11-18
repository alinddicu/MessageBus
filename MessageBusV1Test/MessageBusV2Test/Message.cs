namespace MessageBusV2Test
{
    using System;

    public class Message
    {
        public Guid Id { get; private set; }

        public Message()
        {
            Id = Guid.NewGuid();
        }

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
