using MdLabel.Factory;

namespace MdLabel
{
    public interface IMarkdownLabel : ILabel
    {
        new string Text { get; set; }
    }
}