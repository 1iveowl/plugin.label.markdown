
namespace MdLabel.Renderer.Blocks
{
    public abstract record MauiBlockGroupBase : IMauiBlockGroup
    {
        public int IndentLevel {get; init; }
    }
}
