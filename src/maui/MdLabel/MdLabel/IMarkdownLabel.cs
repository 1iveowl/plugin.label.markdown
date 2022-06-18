using Markdig.Renderers;
using MdLabel.Renderer;

namespace MdLabel
{
    public interface IMarkdownLabel : ILabel
    {
        new string Text { get; set; }
    }
}