using System;
using Microsoft.Toolkit.Parsers.Markdown.Render;

namespace Plugin.Label.MarkDown.Renderer
{
    public class RendererContext : IRenderContext
    {
        public IRenderContext Clone()
        {
            throw new NotImplementedException();
        }

        public bool TrimLeadingWhitespace { get; set; }
        public object Parent { get; set; }
    }
}
