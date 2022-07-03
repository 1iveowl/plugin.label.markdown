using MdLabel.Renderer.Blocks;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState : MauiRendererStateBase
    {
        public virtual void OpenTextBlock(MarkdownBlockKind blockKind)
        {
            if (CurrentBlockGroup is MauiListBlockGroup blockListGroup)
            {
                return;
            }
            else
            {
                BeginBlockGroup<MauiTextBlockGroup>();
                AddBlock(new MauiTextBlock(blockKind));
            }                
        }

        public virtual void CloseBlock()
        {
            if (CurrentBlockGroup is MauiListBlockGroup blockListGroup)
            {
                return;
            }
            else
            {
                EndBlockGroup();
            }            
        }
    }
}
