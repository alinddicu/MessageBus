namespace MessageBusTest
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class MessageBusTest
    {
        [TestMethod]
        public void WhenSendHelloThanBusContainsHelloMessageContent()
        {
            var messageBus = new MessageBus();
            var speaker1 = new Speaker(messageBus);
            var speaker2 = new Speaker(messageBus);

            speaker1.CreateMessage(new TextContent("Hello")).Send(speaker2);

            Check.That(messageBus.GetMessages().ToList()[0].ToString()).Equals("Hello");
        }
    }
}
