using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownCodeSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownCodeSpanBase()
        {
        }

        public MarkdownCodeSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
