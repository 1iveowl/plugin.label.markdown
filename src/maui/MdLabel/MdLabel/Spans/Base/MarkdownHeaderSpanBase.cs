namespace MdLabel.Spans
{
    public abstract class MarkdownHeaderSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownHeaderSpanBase()
        {
        }

        public MarkdownHeaderSpanBase(bool isLink) : base(isLink)
        {
        }
    }
}
