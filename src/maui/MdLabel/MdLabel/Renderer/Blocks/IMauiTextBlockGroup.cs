namespace MdLabel.Renderer.Blocks
{
    public interface IMauiTextBlockGroup
    {
        IEnumerable<IMauiTextBlock> Blocks { get; }

        void Add(IMauiTextBlock block);
    }
}
