using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer
{
    /// <summary>
    /// A HTML renderer for an <see cref="EmphasisInline"/>.
    /// </summary>
    /// <seealso cref="MauiObjectRenderer{EmphasisInline}"></seealso> 
    public class MauiEmphasisInlineRenderer : MauiObjectRenderer<EmphasisInline>
    {
        /// <summary>
        /// Delegates to get the tag associated to an <see cref="EmphasisInline"/> object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The HTML tag associated to this <see cref="EmphasisInline"/> object</returns>
        public delegate string GetTagDelegate(EmphasisInline obj);

        /// <summary>
        /// Initializes a new instance of the <see cref="MauiEmphasisInlineRenderer"/> class.
        /// </summary>
        public MauiEmphasisInlineRenderer()
        {

        }
        protected override void Write(MauiRenderer renderer, EmphasisInline obj)
        {
            var span = new Span();

            span.FontAttributes += (int)FontAttributes.None;

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
