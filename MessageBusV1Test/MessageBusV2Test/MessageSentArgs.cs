namespace MessageBusV2Test
{
    using System;

    public class MessageSentArgs : EventArgs
    {
        public MessageSentArgs(Message message)
        {
            Message = message;
        }

        public Message Message { get; private set; }
    }
}
