using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiQuoteBlockRenderer : MauiObjectRenderer<QuoteBlock>
    {
        protected override void Write(MauiRenderer renderer, QuoteBlock obj)
        {
            renderer.State.BeginQuoteBlockGroup();

            renderer.State.AddQuoteBlockItem();
            renderer.WriteChildren(obj);
            renderer.State.EndQuoteBlockGroup();
        }
    }
}
