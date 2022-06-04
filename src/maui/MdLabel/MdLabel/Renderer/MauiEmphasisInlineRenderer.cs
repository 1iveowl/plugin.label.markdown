using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer
{
    /// <summary>
    /// A HTML renderer for an <see cref="EmphasisInline"/>.
    /// </summary>
    /// <seealso cref="MauiObjectRenderer{EmphasisInline}"></seealso> 
    public class MauiEmphasisInlineRenderer : MauiObjectRenderer<EmphasisInline>
    {
        protected override void Write(MauiRenderer renderer, EmphasisInline obj)
        {
            if (obj.DelimiterChar is '*' or '_')
            {
                if (obj.DelimiterCount == 2)
                {
                    renderer.PushInlineType(MarkdownInlineFormatKind.Bold);
                }
                else
                {
                    renderer.PushInlineType(MarkdownInlineFormatKind.Italic);
                }
            }

            renderer.WriteChildren(obj);

            renderer.PopInlineType();
        }
    }
}
