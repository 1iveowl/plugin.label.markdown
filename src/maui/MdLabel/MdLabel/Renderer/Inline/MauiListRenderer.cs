using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiListRenderer : MauiObjectRenderer<ListBlock>
    {
        protected override void Write(MauiRenderer renderer, ListBlock listBlock)
        {
            renderer.State.BeginListBlockGroup(
                        listBlock.IsOrdered,
                        listBlock.IsOrdered
                            ? listBlock.OrderedDelimiter
                            : null);

            foreach (ListItemBlock item in listBlock)
            {
                renderer.State.AddListBlockItem(item.Order);

                renderer.WriteChildren(item);
            }

            renderer.State.EndListBlockGroup();
        }
    }
}
