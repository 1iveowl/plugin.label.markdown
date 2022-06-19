namespace MdLabel.Renderer.Block
{
    public interface IMauiListBlock
    {
        bool IsOrdered { get; }

        IEnumerable<IMauiListItemBlock> GetListItems();

        void AddListItem(IMauiListItemBlock item);
    }
}
