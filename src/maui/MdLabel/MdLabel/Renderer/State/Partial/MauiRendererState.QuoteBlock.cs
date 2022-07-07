
using Markdig.Syntax;
using MdLabel.Renderer.Blocks;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState : MauiRendererStateBase
    {
        public void BeginQuoteBlockGroup()
        {
            BeginBlockGroup<MauiQuoteBlockGroup>();
        }

        public void EndQuoteBlockGroup()
        {
            EndBlockGroup();
        }

        public void AddQuoteBlockItem()
        {
            if (CurrentBlockGroup is MauiQuoteBlockGroup quoteBlockGroup)
            {
                var quoteBlock = new MauiQuoteItemBlock();

                if (quoteBlockGroup.IndentLevel > 0)
{
                    AddIndenting<MauiQuoteItemBlock, MauiQuoteBlockGroup, MarkdownBlockQuoteSpan>(quoteBlock, quoteBlockGroup);
                }

                AddBlock(quoteBlock);
            }
        }

        public void EndQuoteBlockItem()
        {

        }
    }
}
