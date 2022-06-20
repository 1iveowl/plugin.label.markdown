
namespace MdLabel.Renderer.Blocks
{
    public record MauiQuoteBlockGroup : MauiTextBlockGroupBase, IMauiTextBlockGroup
    {
        public MauiQuoteBlockGroup(int level) : base(level)
        {
        }
    }
}
