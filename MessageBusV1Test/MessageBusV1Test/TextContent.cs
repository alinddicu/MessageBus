namespace MessageBusTest
{
    public class TextContent : MessageContent
    {
        private string _text;

        public TextContent(string text)
        {
            _text = text;
        }

        public override string ToString()
        {
            return _text.ToString();
        }
    }
}
