using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListBlock : MauiBlockBase, IMauiBlockList
    {

        public MauiListBlock(MarkdownBlockKind blockKind) : base(blockKind)
        {
        }
    }
}
