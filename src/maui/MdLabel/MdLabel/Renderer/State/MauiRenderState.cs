using MdLabel.Renderer.Blocks;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState : MauiRendererStateBase, IRendererState
    {
        private readonly List<IMauiTextBlock> _currentListBlock  = new();
                
        private IEnumerable<IMauiTextBlock> CurrentListBlock => _currentListBlock;

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

        public virtual void OpenTextBlock(MarkdownBlockKind blockKind) => BeginTextBlock(new MauiTextBlock(blockKind));

        public virtual void CloseTextBlock() => EndTextBlock();


    }
}
