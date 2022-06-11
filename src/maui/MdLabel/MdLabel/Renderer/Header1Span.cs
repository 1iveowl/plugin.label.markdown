using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLabel.Renderer
{
    public class Header1Span : Span
    {
        public Header1Span()
        {
            this.SetDynamicResource(StyleProperty, "Header1StyleBase");
        }
    }
}
