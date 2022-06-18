using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownHeader3Span : MarkdownHeaderSpanBase
    {
        public MarkdownHeader3Span()
        {
        }

        public MarkdownHeader3Span(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
