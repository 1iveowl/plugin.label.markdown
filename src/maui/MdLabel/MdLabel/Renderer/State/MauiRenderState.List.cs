using Markdig.Syntax;
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

        public void BeginListBlockItem(int order)
        {
            if (CurrentBlockGroup is MauiListBlockGroup blockListGroup)
{
                var listBlock = new MauiListItemBlock() { Order = order };

                if (blockListGroup.IsOrdered)
                {
                    listBlock.AddSpan(new MarkdownListSpan { Text = $"{order}{blockListGroup.OrderDelimiter} " });
                }
                else
                {
                    listBlock.AddSpan(new MarkdownListSpan { Text = "*" });
                }

                AddBlock(listBlock);
            }
        }

        public void EndListBlockItem()
        {
            //throw new NotImplementedException();
        }
    }
}