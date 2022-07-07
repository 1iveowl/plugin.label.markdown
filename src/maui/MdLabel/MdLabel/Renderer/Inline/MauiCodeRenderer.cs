using Markdig.Syntax.Inlines;

namespace MdLabel.Renderer.Inline
{
    public class MauiCodeRenderer : MauiObjectRenderer<CodeInline>
    {
        protected override void Write(MauiRenderer renderer, CodeInline obj)
        {
            renderer.State.BeginCodeBlockGroup();

            renderer.State.AddCodeBlockItem();
            renderer.Write(obj.ContentSpan);
            renderer.State.EndCodeBlockGroup();
        }
    }
}
