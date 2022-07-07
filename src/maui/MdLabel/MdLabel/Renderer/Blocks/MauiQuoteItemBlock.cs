using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiQuoteItemBlock : MauiBlockBase, IMauiBlock
    {
        public MauiQuoteItemBlock() : base(MarkdownBlockKind.Blockquote)
        {
        }
    }
}
