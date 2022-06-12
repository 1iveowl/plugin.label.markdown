using MdLabel.Span;

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
        //internal ReadOnlySpan<char> Replace(this Span<char> span, string replace, string replaceWith)
        //{
        //    var replaceIndex = 0;
        //    var replaceWithIndex = 0;

        //    var newSpan = new char[] { };

        //    for (int i = 0; i < span.Length; i++)
        //    {
        //        if (span[i] == replace[replaceIndex])
        //        {
        //            if (replaceIndex < replace.Length)
        //            {
        //                if (replaceWithIndex < replace.Length)
        //                {

        //                    Array.Resize
        //                }

        //                replaceIndex++;
        //            }
        //        }
        //    }
        //}
    }
}
