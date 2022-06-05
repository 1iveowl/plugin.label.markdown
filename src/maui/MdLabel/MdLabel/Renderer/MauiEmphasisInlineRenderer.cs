using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer
{
    /// <summary>
    /// A HTML renderer for an <see cref="EmphasisInline"/>.
    /// </summary>
    /// <seealso cref="MauiObjectRenderer{EmphasisInline}"></seealso> 
    public class MauiEmphasisInlineRenderer : MauiObjectRenderer<EmphasisInline>
    {
        protected override void Write(MauiRenderer renderer, EmphasisInline emphasisInline)
        {
            switch(emphasisInline.DelimiterChar)
            {
                case '*' or '_':
                    renderer.PushInlineType(emphasisInline.DelimiterCount == 2
                        ? MarkdownInlineFormatKind.Bold
                        : MarkdownInlineFormatKind.Italic);
                    break;
                case '~':
                    renderer.PushInlineType(emphasisInline.DelimiterCount == 2
                        ? MarkdownInlineFormatKind.StrikeThrough
                        : MarkdownInlineFormatKind.SuperScript);
                    break;
                case '^':
                    renderer.PushInlineType(MarkdownInlineFormatKind.SuperScript);
                    break;
                case '+':
                    renderer.PushInlineType(MarkdownInlineFormatKind.Inserted);
                    break;
                case '=':
                    renderer.PushInlineType(MarkdownInlineFormatKind.Marked);
                    break;
            }

            renderer.WriteChildren(emphasisInline);

            renderer.PopInlineType();
        }
    }
}
