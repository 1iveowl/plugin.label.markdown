using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListItemBlock : MauiBlockBase, IMauiListItemBlock
    {
        public int Order { get; } = 0;

        public MauiListItemBlock(int order) : this()
        {
            Order = order;
        }

        public MauiListItemBlock() : base(MarkdownBlockKind.List)
        {
            if (Order is not 0)
            {
                AddSpan(new MarkdownListSpan { });
            }
            else
            {

            }
            // Add bullet or number to start of item block;
            
        }
    }
}
