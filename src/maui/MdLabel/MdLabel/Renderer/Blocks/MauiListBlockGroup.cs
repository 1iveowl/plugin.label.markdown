using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public class MauiListBlockGroup : MauiTextBlockGroupBase, IMauiListBlockGroup
    {
        public bool IsOrdered { get; private set; }

    }
}
