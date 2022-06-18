using MdLabel.Renderer.Inline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Spans
{
    public class MarkdownListSpanBase : MarkdownInlineSpanBase
    {
        public MarkdownListSpanBase()
        {
        }

        public MarkdownListSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats) : base(inlineFormats)
        {
        }
    }
}
