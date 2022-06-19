using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiQuoteBlock : MauiTextBlockBase, IMauiTextBlock
    {
        public MauiQuoteBlock() : base(MarkdownBlockKind.Blockquote)
        {
        }
    }
}
