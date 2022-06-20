using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public interface IMauiTextBlock
    {
        MarkdownBlockKind BlockKind { get; }

        int IndentLevel { get; }

        int TrailingNewLine { get; set; }

        void AddSpan(Span span);

        IEnumerable<Span> GetSpans();

        void SetIndentLevel(int level);
    }
}