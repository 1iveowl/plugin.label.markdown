namespace MdLabel.Renderer.Block
{
    public class MauiListBlock : IMauiListBlock
    {
        public bool IsOrdered { get; private set; }

        public MauiListBlock(bool isOrdered)
        {
            IsOrdered = isOrdered;
        }

        public IEnumerable<IMauiListItemBlock> GetListItems()
        {
            throw new NotImplementedException();
        }

        public void AddListItem(IMauiListItemBlock item)
        {
            throw new NotImplementedException();
        }
    }
}
