using Markdig.Syntax.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Renderer
{
    public class MauiLiteralInlineRenderer : MauiObjectRenderer<LiteralInline>
    {
        protected override void Write(MauiRenderer renderer, LiteralInline obj)
        {
            renderer.WriteSpan(ref obj.Content);
        }
    }
}
