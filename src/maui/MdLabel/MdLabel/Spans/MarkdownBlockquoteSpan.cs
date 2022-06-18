using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    internal class MarkdownBlockquoteSpan : MarkdownBlockquoteSpanBase
    {
        public MarkdownBlockquoteSpan()
        {
        }

        public MarkdownBlockquoteSpan(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
