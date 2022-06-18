
using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public class MarkdownListSpan : MarkdownListSpanBase
    {
        public MarkdownListSpan()
        {
        }

        public MarkdownListSpan(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
