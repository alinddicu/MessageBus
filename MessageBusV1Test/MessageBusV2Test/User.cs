using System;
namespace MessageBusV2Test
{
    public class User
    {
        private MessageBus _messageBus;        

        public User(MessageBus messageBus)
        {
            _messageBus = messageBus;
            Send += _messageBus.Receive;
        }

        public event EventHandler<MessageSentArgs> Send;

        public void SendMessage(Message message)
        {
            if (Send != null)
            {
                Send(this, new MessageSentArgs(message));
            }
        }
    }
}
