using MdLabel.Renderer.Blocks;
using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState : MauiRendererStateBase
    {
        public virtual void OpenTextBlock()
        {
            BeginBlockGroup<MauiTextBlockGroup>();
        }

        public virtual void AddTextBlock(MarkdownBlockKind blockKind)
        {
            if (CurrentBlockGroup is MauiTextBlockGroup textBlockGroup)
            {
                var textBlock = new MauiTextBlock(blockKind);

                if (textBlockGroup.IndentLevel > 0)
{
                    AddIndenting<MauiTextBlock, MauiTextBlockGroup, MarkdownInlineSpan>(textBlock, textBlockGroup);
                }

                AddBlock(textBlock);
            }
        }

        public virtual void CloseBlock()
        {
            EndBlockGroup();
        }
    }
}
