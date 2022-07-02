namespace MdLabel.Renderer.Blocks
{
    public interface IMauiListBlockGroup : IMauiBlockGroup
    {
        bool IsOrdered { get; }
        char? OrderDelimiter { get; }

        //int IncrementOrder();
    }
}
