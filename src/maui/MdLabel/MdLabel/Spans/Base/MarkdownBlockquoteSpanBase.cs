using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownBlockquoteSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownBlockquoteSpanBase()
        {
        }

        public MarkdownBlockquoteSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
