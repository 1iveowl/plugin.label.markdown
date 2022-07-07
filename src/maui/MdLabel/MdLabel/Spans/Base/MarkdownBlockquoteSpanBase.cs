using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownBlockQuoteSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownBlockQuoteSpanBase()
        {
        }

        public MarkdownBlockQuoteSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
