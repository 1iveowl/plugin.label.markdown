using MdLabel.Renderer.Blocks;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState
    {
        public virtual void BeginListBlockGroup(bool IsOrdered, char? orderDelimiter)
        {
            BeginBlockGroup<MauiListBlockGroup>(
                blockGroup => blockGroup = blockGroup with 
                { 
                    IsOrdered = IsOrdered,
                    OrderDelimiter = orderDelimiter
                });
        }

        public virtual void EndListBlockGroup()
        {
            EndBlockGroup();
        }


        public void BeginListBlockItem(int order)
        {
            if (CurrentBlockGroup is MauiListBlockGroup blockListGroup)
            {
                var listBlock = blockListGroup.IsOrdered
                    ? new MauiListItemBlock(order)
                    : new MauiListItemBlock();
            }
        }

        public void EndListBlockItem()
        {
            throw new NotImplementedException();
        }
    }
}