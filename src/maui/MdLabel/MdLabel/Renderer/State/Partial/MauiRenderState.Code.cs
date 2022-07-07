using MdLabel.Renderer.Blocks;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState
    {
        public void BeginCodeBlockGroup()
        {
            BeginBlockGroup<MauiCodeBlockGroup>();
        }

        public void EndCodeBlockGroup()
        {
            EndBlockGroup();
        }

        public void AddCodeBlockItem()
        {
            if (CurrentBlockGroup is MauiCodeBlockGroup quoteBlockGroup)
            {
                var quoteBlock = new MauiCodeItemBlock();

                if (quoteBlockGroup.IndentLevel > 0)
                {
                    AddIndenting<MauiCodeItemBlock, MauiCodeBlockGroup, MarkdownCodeSpan>(quoteBlock, quoteBlockGroup);
                }

                AddBlock(quoteBlock);
            }
        }

        public void EndCodeBlockItem()
        {

        }
    }
}
