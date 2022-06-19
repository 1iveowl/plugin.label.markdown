using MdLabel.Renderer.Blocks;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState
    {
        private readonly Stack<IMauiListBlockGroup> _blockListStack = new();

        public virtual void BeginListBlock(bool IsOrdered)
        {

        }

        public virtual void EndListBlock()
        {
            if (CurrentTextBlock is not null)
            {
                //BeginTextBlock(CurrentTextBlock);
            }

            //EndTextBlock();
        }

        public void BeginListBlockItem()
        {
            throw new NotImplementedException();
        }

        public void EndListBlockItem()
        {
            throw new NotImplementedException();
        }
    }
}