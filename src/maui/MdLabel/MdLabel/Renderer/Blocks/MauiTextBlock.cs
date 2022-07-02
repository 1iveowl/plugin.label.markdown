using MdLabel.Helper;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiTextBlock : MauiBlockBase, IMauiBlock
    {
        public MauiTextBlock(MarkdownBlockKind blockKind) : base(blockKind)
        {
        }
    }
}
