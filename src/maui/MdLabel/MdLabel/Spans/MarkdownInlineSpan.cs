namespace MdLabel.Spans
{
    public class MarkdownInlineSpan : MarkdownSpanBase
    {
        public MarkdownInlineSpan()
        {
        }

        public MarkdownInlineSpan(bool isLink) : base(isLink)
        {
        }
    }
}
