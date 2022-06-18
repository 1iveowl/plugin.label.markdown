using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownCodeSpan : MarkdownCodeSpanBase
    {
        public MarkdownCodeSpan()
        {
        }

        public MarkdownCodeSpan(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
