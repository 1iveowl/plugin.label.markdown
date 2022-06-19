using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Factory
{
    public class SpanFactory : ISpanFactory
    {
        public virtual MarkdownSpanBase GetSpan(
            MarkdownBlockKind spanBlock,
            IEnumerable<MarkdownInlineFormatKind> inlineFormats,            
            Action<MarkdownSpanBase> linkAction)
        {
            var markdownSpan = GetMarkdownSpan(spanBlock, inlineFormats);

            if (inlineFormats is not null)
            {
                if (inlineFormats.Any(inlineFormat => inlineFormat is MarkdownInlineFormatKind.Link))
                {
                    linkAction(markdownSpan);
                }

                var (fontAttributes, textDecorations) = GetInlineFormating(inlineFormats);

                if (textDecorations is not TextDecorations.None)
                {
                    markdownSpan.TextDecorations = textDecorations;
                }

                if (fontAttributes is not FontAttributes.None)
                {
                    markdownSpan.FontAttributes = fontAttributes;
                }
            }

            return markdownSpan;
        }

        protected virtual MarkdownSpanBase GetMarkdownSpan(
            MarkdownBlockKind spanBlock, 
            IEnumerable<MarkdownInlineFormatKind> inlineFormats) => 
                spanBlock switch
                {
                    MarkdownBlockKind.Paragraph => new MarkdownInlineSpan(inlineFormats),
                    MarkdownBlockKind.Header1 => new MarkdownHeader1Span(inlineFormats),
                    MarkdownBlockKind.Header2 => new MarkdownHeader2Span(inlineFormats),
                    MarkdownBlockKind.Header3 => new MarkdownHeader3Span(inlineFormats),
                    MarkdownBlockKind.Header4 => new MarkdownHeader4Span(inlineFormats),
                    MarkdownBlockKind.Header5 => new MarkdownHeader5Span(inlineFormats),
                    MarkdownBlockKind.Header6 => new MarkdownHeader6Span(inlineFormats),
                    MarkdownBlockKind.List => new MarkdownListSpan(inlineFormats),
                    MarkdownBlockKind.Blockquote => new MarkdownBlockquoteSpan(inlineFormats),
                    MarkdownBlockKind.Code => new MarkdownCodeSpan(inlineFormats),
                    _ => throw new NotImplementedException(),
                };

        protected virtual (FontAttributes attributes, TextDecorations decorations) GetInlineFormating(IEnumerable<MarkdownInlineFormatKind> inlineFormats)
        {
            FontAttributes fontAttributes = FontAttributes.None;
            TextDecorations decorations = TextDecorations.None;

            foreach (var inlineFormat in inlineFormats)
            {
                switch (inlineFormat)
                {
                    case MarkdownInlineFormatKind.Default:
                        break;
                    case MarkdownInlineFormatKind.Bold:
                        fontAttributes += (int)FontAttributes.Bold;
                        break;
                    case MarkdownInlineFormatKind.Italic:
                        fontAttributes += (int)FontAttributes.Italic;
                        break;
                    case MarkdownInlineFormatKind.Underline:
                        decorations += (int)TextDecorations.Underline;
                        break;
                    case MarkdownInlineFormatKind.StrikeThrough:
                        decorations += (int)TextDecorations.Strikethrough;
                        break;
                    case MarkdownInlineFormatKind.SuperScript:
                    case MarkdownInlineFormatKind.Subscript:
                        break;
                    case MarkdownInlineFormatKind.Link:
                        break;
                    case MarkdownInlineFormatKind.Mark:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (fontAttributes, decorations);
        }
    }
}
