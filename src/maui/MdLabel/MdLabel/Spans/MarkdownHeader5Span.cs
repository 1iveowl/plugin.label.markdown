using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownHeader5Span : MarkdownHeaderSpanBase
    {
        public MarkdownHeader5Span()
        {
        }

        public MarkdownHeader5Span(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
