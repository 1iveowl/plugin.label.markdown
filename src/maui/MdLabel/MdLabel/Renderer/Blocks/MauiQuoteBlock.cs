using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiQuoteBlock : MauiBlockBase, IMauiBlock
    {
        public MauiQuoteBlock() : base(MarkdownBlockKind.Blockquote)
        {
        }
    }
}
