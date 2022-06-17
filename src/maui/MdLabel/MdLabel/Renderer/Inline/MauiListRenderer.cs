using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiListRenderer : MauiObjectRenderer<ListBlock>
    {
        protected override void Write(MauiRenderer renderer, ListBlock listBlock)
        {
            if (listBlock.IsOrdered)
            {

            }

            base.Write(renderer, listBlock);
        }
    }
}
