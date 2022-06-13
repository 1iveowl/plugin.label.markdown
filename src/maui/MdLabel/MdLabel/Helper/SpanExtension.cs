using MdLabel.Spans;

namespace MdLabel.Helper
{
    internal static class SpanExtension
    {
        internal static MarkdownHeaderSpanBase GetHeaderSpan(this MarkdownHeaderKind headerKind) => headerKind switch
        {
            MarkdownHeaderKind.Header1 => new MarkdownHeader1Span(),
            MarkdownHeaderKind.Header2 => new MarkdownHeader2Span(),
            MarkdownHeaderKind.Header3 => new MarkdownHeader3Span(),
            MarkdownHeaderKind.Header4 => new MarkdownHeader4Span(),
            MarkdownHeaderKind.Header5 => new MarkdownHeader5Span(),
            MarkdownHeaderKind.Header6 => new MarkdownHeader6Span(),
            MarkdownHeaderKind.None => throw new ArgumentException($"Cannot create header span for {MarkdownHeaderKind.None}"),
            _ => throw new NotImplementedException(),
        };

        internal static MarkdownHeaderSpanBase GetHeaderLinkSpan(this MarkdownHeaderKind headerKind) => headerKind switch
        {
            MarkdownHeaderKind.Header1 => new MarkdownHeader1LinkSpan(),
            MarkdownHeaderKind.Header2 => new MarkdownHeader2LinkSpan(),
            MarkdownHeaderKind.Header3 => new MarkdownHeader3LinkSpan(),
            MarkdownHeaderKind.Header4 => new MarkdownHeader4LinkSpan(),
            MarkdownHeaderKind.Header5 => new MarkdownHeader5LinkSpan(),
            MarkdownHeaderKind.Header6 => new MarkdownHeader6LinkSpan(),
            MarkdownHeaderKind.None => throw new ArgumentException($"Cannot create header span for {MarkdownHeaderKind.None}"),
            _ => throw new NotImplementedException(),
        };
    }
}
