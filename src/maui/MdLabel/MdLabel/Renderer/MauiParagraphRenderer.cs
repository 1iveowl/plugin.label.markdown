using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Renderer
{
    public class MauiParagraphRenderer : MauiObjectRenderer<ParagraphBlock>
    {
        protected override void Write(MauiRenderer renderer, ParagraphBlock obj)
        {
            renderer.OpenBlock(); 
            renderer.WriteLeafInline(obj);
            renderer.AddNewLine();
            renderer.CloseBlock();
        }
    }
}
