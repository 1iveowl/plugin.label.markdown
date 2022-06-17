using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Renderer.Inline
{
    internal enum MarkdownSpanKind
    {
        Default,
        Comment,
        Inserted,
        List,
        Marked,
        Code,
        Image,
        Link
    }
}
