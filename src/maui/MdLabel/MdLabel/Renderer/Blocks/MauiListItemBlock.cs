using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListItemBlock : MauiBlockBase, IMauiListItemBlock
    {
        public int Order { get; init; }

        public MauiListItemBlock() : base(MarkdownBlockKind.List)
        {
            

            //if (Order is not 0)
            //{
            //    AddSpan(new MarkdownListSpan { Text = Order.ToString() });
            //}
            //else
            //{
            //    AddSpan(new MarkdownListSpan { Text = "*" });
            //}
            // Add bullet or number to start of item block;
        }
    }
}
