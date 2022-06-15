using Markdig.Renderers;
using Markdig.Syntax;

namespace MdLabel.Renderer
{
    public class MauiHeadingRenderer : MauiObjectRenderer<HeadingBlock>
    {
        protected override void Write(MauiRenderer renderer, HeadingBlock obj)
        {
            renderer.OpenBlock();
            renderer.SetHeaderStyle(obj.Level);

            if (obj.Inline is not null)
            {
                renderer.WriteLeafInline(obj);
                renderer.AddNewLine();
            }

            renderer.CloseBlock();
            renderer.ClearHeaderStyle();
        }

        public override void Write(RendererBase renderer, MarkdownObject obj)
        {
            base.Write(renderer, obj);
        }
    }
}
