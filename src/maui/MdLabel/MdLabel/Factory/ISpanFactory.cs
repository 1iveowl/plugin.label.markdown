using MdLabel.Spans;

namespace MdLabel.Factory
{
    public interface ISpanFactory
    {
        MarkdownSpanBase GetSpan(MarkdownHeaderLevelKind headerKind, bool isLink);
    }
}
