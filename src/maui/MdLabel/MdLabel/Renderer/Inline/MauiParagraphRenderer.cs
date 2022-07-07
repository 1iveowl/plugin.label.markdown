using Markdig.Helpers;
using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiParagraphRenderer : MauiObjectRenderer<ParagraphBlock>
    {
        protected override void Write(MauiRenderer renderer, ParagraphBlock obj)
        {
            if (!renderer.State.IsParagraphPartOfBlock)
            {
                renderer.State.OpenTextBlock();
                renderer.State.AddTextBlock(MarkdownBlockKind.Paragraph);                
            }
            else
            {

            }

            renderer.WriteLeafInline(obj);

            if (obj.NewLine is not NewLine.None)
            {
                //renderer.State.AddNewLine();
            }

            if (!renderer.State.IsParagraphPartOfBlock)
            {
                renderer.State.CloseBlock();
            }
            else
            {
                renderer.State.EndListBlockItem();
            }
        }
    }
}
