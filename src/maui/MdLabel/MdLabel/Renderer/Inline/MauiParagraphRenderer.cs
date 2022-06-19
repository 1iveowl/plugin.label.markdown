using Markdig.Helpers;
using Markdig.Syntax;

namespace MdLabel.Renderer.Inline
{
    public class MauiParagraphRenderer : MauiObjectRenderer<ParagraphBlock>
    {
        protected override void Write(MauiRenderer renderer, ParagraphBlock obj)
        {
            renderer.State.OpenTextBlock(MarkdownBlockKind.Paragraph);
            renderer.WriteLeafInline(obj);

            if (obj.NewLine != NewLine.None)
            {
                renderer.State.AddNewLine();
            }

            renderer.State.CloseTextBlock();
        }
    }
}
