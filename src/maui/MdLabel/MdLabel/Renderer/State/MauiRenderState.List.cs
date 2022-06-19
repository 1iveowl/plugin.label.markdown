namespace MdLabel.Renderer
{
    public partial class MauiRenderState
    {
        public virtual void BeginListBlock(bool IsOrdered)
        {
            if (CurrentTextBlock is not null)
            {
                //CloseTextBlock();
            }

            //BeginTextBlock(new MauiTextBlock());
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