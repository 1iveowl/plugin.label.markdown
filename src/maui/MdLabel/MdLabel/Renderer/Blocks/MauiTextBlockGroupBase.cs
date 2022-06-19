
namespace MdLabel.Renderer.Blocks
{
    public class MauiTextBlockGroupBase : IMauiTextBlockGroup
    {
        public IEnumerable<IMauiTextBlock> Blocks => throw new NotImplementedException();

        public void Add(IMauiTextBlock block)
        {
            throw new NotImplementedException();
        }
    }
}
