using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer.Inline
{
    public class MauiLineBreakInlineRenderer : MauiObjectRenderer<LineBreakInline>
    {
        protected override void Write(MauiRenderer renderer, LineBreakInline obj)
        {
            renderer.State.AddNewLine();
        }
    }
}
