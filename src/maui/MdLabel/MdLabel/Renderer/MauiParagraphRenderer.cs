using Markdig.Helpers;
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

            if (obj.NewLine != NewLine.None)
            {
                renderer.AddNewLine();
            }
            
            renderer.CloseBlock();
        }
    }
}
