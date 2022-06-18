using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownHeader1Span : MarkdownHeaderSpanBase
    {
        public MarkdownHeader1Span()
        {
        }

        public MarkdownHeader1Span(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
