using MdLabel.Renderer.Blocks;
using MdLabel.Spans;

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

        public void AddListBlockItem(int order)
        {
            if (CurrentBlockGroup is MauiListBlockGroup blockListGroup)
{
                var listBlock = new MauiListItemBlock() { Order = order };                
                
                if (blockListGroup.IndentLevel > 0)
                {
                    AddIndenting<MauiListItemBlock, MauiListBlockGroup, MarkdownListSpan>(listBlock, blockListGroup);
                }

                if (blockListGroup.IsOrdered)
                {
                    AddOrderedNumber(listBlock);
                }
                else
                {
                    AddBullet(listBlock);
                }

                AddBlock(listBlock);
            }
            

            void AddOrderedNumber(MauiListItemBlock listBlock)
            {
                listBlock.AddSpan(new MarkdownListSpan { Text = $"{order}{blockListGroup.OrderDelimiter} " });
            }

            void AddBullet(MauiListItemBlock listBlock)
            {
                listBlock.AddSpan(new MarkdownListSpan { Text = "*" });
            }
        }

        public void EndListBlockItem() => EndItem();
    }
}