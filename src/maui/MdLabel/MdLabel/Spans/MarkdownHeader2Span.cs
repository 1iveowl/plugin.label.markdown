using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{

    public class MarkdownHeader2Span : MarkdownHeaderSpanBase
    {
        public MarkdownHeader2Span()
        {
        }

        public MarkdownHeader2Span(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
