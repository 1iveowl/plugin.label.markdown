using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public abstract class MarkdownHeaderSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownHeaderSpanBase()
        {
            
        }

        public MarkdownHeaderSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
