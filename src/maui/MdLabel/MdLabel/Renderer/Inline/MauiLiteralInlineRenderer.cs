using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer.Inline
{
    public class MauiLiteralInlineRenderer : MauiObjectRenderer<LiteralInline>
    {
        protected override void Write(MauiRenderer renderer, LiteralInline obj)
        {
            renderer.WriteSpan(ref obj.Content);
        }
    }
}
