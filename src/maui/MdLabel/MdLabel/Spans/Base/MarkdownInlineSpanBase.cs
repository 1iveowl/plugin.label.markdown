using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownInlineSpanBase : MarkdownSpanBase
    {
        public MarkdownInlineSpanBase()
        {
        }

        public MarkdownInlineSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
