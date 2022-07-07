using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiCodeItemBlock : MauiBlockBase, IMauiBlock
    {
        public MauiCodeItemBlock() : base(MarkdownBlockKind.Code)
        {
        }
    }
}
