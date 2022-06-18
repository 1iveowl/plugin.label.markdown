using Markdig.Helpers;
using Markdig.Renderers;

namespace MdLabel.Renderer
{
    public interface IMauiRenderer : IMarkdownRenderer, IDisposable
    {
        FormattedString GetFormattedString();

        void WriteSpan(ref StringSlice slice);
    }
}
