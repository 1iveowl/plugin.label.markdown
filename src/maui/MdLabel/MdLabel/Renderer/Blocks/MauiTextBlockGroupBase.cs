
namespace MdLabel.Renderer.Blocks
{
    public abstract record MauiTextBlockGroupBase : IMauiTextBlockGroup
    {
        public int IndentLevel {get; init; }

        protected MauiTextBlockGroupBase(int indentLevel)
        {
            IndentLevel = indentLevel;
        }
    }
}
