using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin.Label.MarkDown.CustomControl
{
    public class MarkdownTextEventArgs : EventArgs
    {
        public string MarkdownText { get; set; }
    }
}
