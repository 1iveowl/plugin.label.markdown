using MdLabel.Helper;
using MdLabel.Spans;

namespace MdLabel.Factory
{
    public class SpanFactory : ISpanFactory
    {
        public virtual MarkdownSpanBase GetSpan(MarkdownHeaderLevelKind headerKind, bool isLink)
        {
            return headerKind.GetHeaderSpan(isLink);
        }
    }
}
