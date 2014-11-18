namespace MessageBusV2Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class MessageBusV2Test
    {
        [TestMethod]
        public void WhenUserSendsMessageThenTheMessageBusContainsMessage()
        {
            var messageBus = new MessageBus();
            var user = new User(messageBus);
            var message = new Message();

            user.SendMessage(message);

            var receivedMessage = messageBus.GetMessages().FirstOrDefault();
            Check.That(receivedMessage).IsNotNull();
            Check.That(receivedMessage).Equals(message);
        }
    }
}
