namespace MdLabel.Renderer.Blocks
{
    public record MauiTextBlockGroup : MauiTextBlockGroupBase, IMauiTextBlockGroup
    {
        public MauiTextBlockGroup(int indentLevel) : base(indentLevel)
        {
        }
    }
}
