using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Factory
{
    public interface ISpanFactory
    {
        MarkdownSpanBase GetSpan(
            MarkdownBlockKind spanBlock,
            IEnumerable<MarkdownInlineFormatKind> inlineFormats,            
            Action<MarkdownSpanBase> linkAction);
    }
}
