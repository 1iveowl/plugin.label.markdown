using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListItemBlock : MauiBlockBase, IMauiListItemBlock
    {
        public int Order { get; init; }

        public MauiListItemBlock() : base(MarkdownBlockKind.List)
        {
        }
    }
}
