using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiHeadingRenderer : MauiObjectRenderer<HeadingBlock>
    {
        protected override void Write(MauiRenderer renderer, HeadingBlock obj)
{
            if (obj.Level <= 1 && obj.Level >= 6)
            {
                throw new ArgumentOutOfRangeException("Header level must be between 1 and 6.");
            }

            renderer.State.OpenTextBlock((MarkdownBlockKind)obj.Level);

            if (obj.Inline is not null)
            {
                renderer.WriteLeafInline(obj);
                renderer.State.AddNewLine();
            }

            renderer.State.CloseBlock();
        }
    }
}
