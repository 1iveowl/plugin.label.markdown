//using MdLabel.Renderer.Inline;
//using MdLabel.Spans;

//namespace MdLabel.Helper
//{
//    internal static class SpanExtension
//    {
//        internal static MarkdownHeaderSpanBase GetHeaderSpan(this MarkdownHeaderLevelKind headerKind, bool isLink = false) => headerKind switch
//        {
//            MarkdownHeaderLevelKind.Header1 => new MarkdownHeader1Span(isLink),
//            MarkdownHeaderLevelKind.Header2 => new MarkdownHeader2Span(isLink),
//            MarkdownHeaderLevelKind.Header3 => new MarkdownHeader3Span(isLink),
//            MarkdownHeaderLevelKind.Header4 => new MarkdownHeader4Span(isLink),
//            MarkdownHeaderLevelKind.Header5 => new MarkdownHeader5Span(isLink),
//            MarkdownHeaderLevelKind.Header6 => new MarkdownHeader6Span(isLink),
//            MarkdownHeaderLevelKind.None => throw new ArgumentException($"Cannot create header span for {MarkdownHeaderLevelKind.None}"),
//            _ => throw new NotImplementedException(),
//        };
//    }
//}
