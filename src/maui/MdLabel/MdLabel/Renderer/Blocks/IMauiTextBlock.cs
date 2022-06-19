using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public interface IMauiTextBlock
    {
        MarkdownBlockKind BlockKind { get; }
        int TrailingNewLine { get; set; }

        void AddSpan(MarkdownSpanBase span);
        IEnumerable<MarkdownSpanBase> GetSpans();
    }
}