using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchMarkDigParser.Renderer
{
    public class MauiParagraphRenderer : MauiObjectRenderer<ParagraphBlock>
    {
        protected override void Write(MauiRenderer renderer, ParagraphBlock obj)
        {
            if (!renderer.ImplicitParagraph)
            {
                if (!renderer.IsFirstInContainer)
                {
                    renderer.EnsureLine();
                }

                renderer.Write("<p");
                renderer.WriteRaw('>');
            }
            renderer.WriteLeafInline(obj);

            if (!renderer.ImplicitParagraph)
            {
                renderer.WriteLine("</p>");

                renderer.EnsureLine();
            }
        }
    }
}
