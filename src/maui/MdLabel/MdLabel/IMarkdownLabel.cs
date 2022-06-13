using Microsoft.Maui;

namespace MdLabel
{
    public interface IMarkdownLabel : ILabel
    {
        new string Text { get; set; }
    }
}