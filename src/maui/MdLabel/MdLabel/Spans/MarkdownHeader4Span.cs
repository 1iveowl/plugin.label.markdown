using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownHeader4Span : MarkdownHeaderSpanBase
    {
        public MarkdownHeader4Span()
        {
        }

        public MarkdownHeader4Span(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
