using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchMarkDigParser.Renderer
{
    public class MauiLiteralInlineRenderer : MauiObjectRenderer<LiteralInline>
    {
        protected override void Write(MauiRenderer renderer, LiteralInline obj)
        {
            if (renderer.EnableHtmlEscape)
            {
                renderer.WriteEscape(ref obj.Content);
            }
            else
            {
                renderer.Write(ref obj.Content);
            }
        }
    }
}
