using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer.Inline
{
    /// <summary>
    /// A HTML renderer for an <see cref="EmphasisInline"/>.
    /// </summary>
    /// <seealso cref="MauiObjectRenderer{EmphasisInline}"></seealso> 
    public class MauiEmphasisInlineRenderer : MauiObjectRenderer<EmphasisInline>
    {
        protected override void Write(MauiRenderer renderer, EmphasisInline emphasisInline)
        {
            switch (emphasisInline.DelimiterChar)
            {
                case '*' or '_':
                    renderer.PushInlineFormatType(emphasisInline.DelimiterCount == 2
                        ? MarkdownInlineFormatKind.Bold
                        : MarkdownInlineFormatKind.Italic);
                    break;
                case '~':
                    renderer.PushInlineFormatType(emphasisInline.DelimiterCount == 2
                        ? MarkdownInlineFormatKind.StrikeThrough
                        : MarkdownInlineFormatKind.SuperScript);
                    break;
                case '^':
                    renderer.PushInlineFormatType(MarkdownInlineFormatKind.SuperScript);
                    break;
                case '+':
                    renderer.PushInlineFormatType(MarkdownInlineFormatKind.Inserted);
                    break;
                case '=':
                    renderer.PushInlineFormatType(MarkdownInlineFormatKind.Marked);
                    break;
            }

            renderer.WriteChildren(emphasisInline);

            renderer.PopInlineFormatType();
        }
    }
}
