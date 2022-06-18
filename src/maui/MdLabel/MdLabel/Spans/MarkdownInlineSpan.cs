using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownInlineSpan : MarkdownSpanBase
    {
        public MarkdownInlineSpan()
        {
        }

        public MarkdownInlineSpan(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
