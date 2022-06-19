using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Block
{
    public record MauiListItemBlock : MauiTextBlock, IMauiListItemBlock
    {
        public MauiListItemBlock(MarkdownBlockKind blockKind) : base(blockKind)
        {
        }
    }
}
