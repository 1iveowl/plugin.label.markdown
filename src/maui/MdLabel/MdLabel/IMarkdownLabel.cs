using Microsoft.Maui;

namespace MdLabel
{
    public interface IMarkdownLabel : ILabel
    {
        new string Text { get; set; }

        bool IsExtraHeaderSpacing { get; set; }
        bool IsParagraphSpacing { get; set; }

        string Variable1 { get; set; }
        string Variable2 { get; set; }
        string Variable3 { get; set; }
        string Variable4 { get; set; }
        string Variable5 { get; set; }
        string Variable6 { get; set; }
    }
}