using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Renderer
{
    public class MauiLineBreakInlineRenderer : MauiObjectRenderer<LineBreakInline>
    {
        protected override void Write(MauiRenderer renderer, LineBreakInline obj)
        {
            renderer.AddNewLine();
        }
    }
}
