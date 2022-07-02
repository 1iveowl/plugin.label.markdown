using MdLabel.Renderer.Blocks;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState : IRendererState
    {
        public virtual void AddNewLine()
        {
            if (CurrentTextBlock is not null)
            {
                CurrentTextBlock.TrailingNewLine++;
            }
            else
            {
                throw new NullReferenceException($"{nameof(MauiTextBlock)} cannot be null");
            }
        }
    }
}
