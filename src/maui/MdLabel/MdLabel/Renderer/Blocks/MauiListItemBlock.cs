using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListItemBlock : MauiTextBlockBase, IMauiListItemBlock
    {
        public MauiListItemBlock() : base(MarkdownBlockKind.List)
        {
        }
    }
}
