using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public interface IMauiSpanBlock
    {
        int TrailingNewLine { get; set; }
        void AddSpan(MarkdownSpanBase span);
        IEnumerable<MarkdownSpanBase> GetSpans();
    }
}