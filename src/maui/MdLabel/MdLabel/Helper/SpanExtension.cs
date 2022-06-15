using MdLabel.Spans;

namespace MdLabel.Helper
{
    internal static class SpanExtension
    {
        internal static MarkdownHeaderSpanBase GetHeaderSpan(this MarkdownHeaderLevelKind headerKind) => headerKind switch
        {
            MarkdownHeaderLevelKind.Header1 => new MarkdownHeader1Span(),
            MarkdownHeaderLevelKind.Header2 => new MarkdownHeader2Span(),
            MarkdownHeaderLevelKind.Header3 => new MarkdownHeader3Span(),
            MarkdownHeaderLevelKind.Header4 => new MarkdownHeader4Span(),
            MarkdownHeaderLevelKind.Header5 => new MarkdownHeader5Span(),
            MarkdownHeaderLevelKind.Header6 => new MarkdownHeader6Span(),
            MarkdownHeaderLevelKind.None => throw new ArgumentException($"Cannot create header span for {MarkdownHeaderLevelKind.None}"),
            _ => throw new NotImplementedException(),
        };

        internal static MarkdownHeaderSpanBase GetHeaderLinkSpan(this MarkdownHeaderLevelKind headerKind) => headerKind switch
        {
            MarkdownHeaderLevelKind.Header1 => new MarkdownHeader1LinkSpan(),
            MarkdownHeaderLevelKind.Header2 => new MarkdownHeader2LinkSpan(),
            MarkdownHeaderLevelKind.Header3 => new MarkdownHeader3LinkSpan(),
            MarkdownHeaderLevelKind.Header4 => new MarkdownHeader4LinkSpan(),
            MarkdownHeaderLevelKind.Header5 => new MarkdownHeader5LinkSpan(),
            MarkdownHeaderLevelKind.Header6 => new MarkdownHeader6LinkSpan(),
            MarkdownHeaderLevelKind.None => throw new ArgumentException($"Cannot create header span for {MarkdownHeaderLevelKind.None}"),
            _ => throw new NotImplementedException(),
        };
    }
}
