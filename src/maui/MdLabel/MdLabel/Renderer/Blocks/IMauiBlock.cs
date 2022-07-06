using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public interface IMauiBlock
    {
        MarkdownBlockKind BlockKind { get; }

        int IndentLevel { get; }

        //void AddSpanNewLine { get; }
        //int TrailingNewLine { get; }

        void AddSpan(Span span);

        IEnumerable<Span> GetSpans();

        void SetIndentLevel(int level);
    }
}