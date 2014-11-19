namespace MessageBusV2Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class MessageBusV2Test
    {
        private static readonly MessageBus MessageBus = new MessageBus();

        [TestInitialize]
        public void Initialize()
        {
            MessageBus.ClearMessages();
            MessageBus.ClearReceivers();
        }

        [TestMethod]
        public void WhenUserSendsMessageThenTheMessageBusContainsMessage()
        {
            var user = new User(MessageBus);
            var message = new Message(user, null);

            user.SendMessage(message);

            var receivedMessage = MessageBus.GetMessages().FirstOrDefault();
            Check.That(receivedMessage).IsNotNull();
            Check.That(receivedMessage).Equals(message);
        }

        [TestMethod]
        public void WhenSenderSendsMessageToReceiverThenReceiverGetsTheMessage()
        {
            var sender = new User(MessageBus);
            var receiver = new User(MessageBus);
            var message = new Message(sender, receiver);

            sender.SendMessage(message);

            var receivedMessage = receiver.GetMessages().FirstOrDefault();
            Check.That(receivedMessage).IsNotNull();
            Check.That(receivedMessage).Equals(message);
        }

        [TestMethod]
        public void WhenSenderSendsMessageToReceiver1ThenOnlyReceiver1GetsTheMessage()
        {
            var sender = new User(MessageBus);
            var receiver1 = new User(MessageBus);
            var receiver2 = new User(MessageBus);
            var message = new Message(sender, receiver1);

            sender.SendMessage(message);

            var receivedMessage = receiver1.GetMessages().FirstOrDefault();
            Check.That(receivedMessage).IsNotNull();
            Check.That(receivedMessage).Equals(message);

            var receivedMessage2 = receiver2.GetMessages().FirstOrDefault();
            Check.That(receivedMessage2).IsNull();
        }
    }
}
