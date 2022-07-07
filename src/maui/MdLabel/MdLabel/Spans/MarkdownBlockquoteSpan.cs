using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    internal class MarkdownBlockQuoteSpan : MarkdownBlockQuoteSpanBase
    {
        public MarkdownBlockQuoteSpan()
        {
        }

        public MarkdownBlockQuoteSpan(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
