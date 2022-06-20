using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer.Blocks
{
    public record MauiListBlockGroup : MauiTextBlockGroupBase, IMauiListBlockGroup
    {
        public bool IsOrdered { get; init; }

        public MauiListBlockGroup(int intentLevel, bool isOrdered) : base(intentLevel)
        {
            IsOrdered = isOrdered;
        }

    }
}
