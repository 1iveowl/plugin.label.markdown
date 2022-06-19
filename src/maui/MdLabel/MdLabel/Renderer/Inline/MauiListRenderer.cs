using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiListRenderer : MauiObjectRenderer<ListBlock>
    {
        protected override void Write(MauiRenderer renderer, ListBlock listBlock)
        {
            renderer.State.BeginListBlock(listBlock.IsOrdered);

            foreach (ListItemBlock itemBlock in listBlock)
            {
                renderer.State.BeginListBlockItem();

                renderer.WriteChildren(itemBlock);

                renderer.State.EndListBlockItem();
            }

            renderer.State.EndListBlock();

        }
    }
}
