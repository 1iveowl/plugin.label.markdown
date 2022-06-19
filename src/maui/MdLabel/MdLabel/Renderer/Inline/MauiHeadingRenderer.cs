using Markdig.Renderers;
using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiHeadingRenderer : MauiObjectRenderer<HeadingBlock>
    {
        protected override void Write(MauiRenderer renderer, HeadingBlock obj)
        {
            renderer.State.OpenBlock();
            renderer.State.SetHeaderLevel(obj.Level);

            if (obj.Inline is not null)
            {
                renderer.WriteLeafInline(obj);
                renderer.State.AddNewLine();
            }

            renderer.State.CloseBlock();
            renderer.State.ClearHeader();
        }
    }
}
