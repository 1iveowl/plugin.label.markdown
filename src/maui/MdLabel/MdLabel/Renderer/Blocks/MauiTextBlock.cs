using MdLabel.Helper;
using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer.Blocks
{
    public record MauiTextBlock : MauiTextBlockBase, IMauiTextBlock
    {
        public MauiTextBlock(MarkdownBlockKind blockKind) : base(blockKind)
        {
        }
    }
}
