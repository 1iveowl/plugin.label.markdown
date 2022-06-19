using Markdig.Renderers;
using Markdig.Syntax;

namespace MdLabel.Renderer
{
    /// <summary>
    /// A base class for Maui rendering <see cref="Block"/> and <see cref="Markdig.Syntax.Inlines.Inline"/> Markdown objects.
    /// </summary>
    /// <typeparam name="TObject">The type of the object.</typeparam>
    /// <seealso cref="IMarkdownObjectRenderer" />
    public abstract class MauiObjectRenderer<TObject> : MarkdownObjectRenderer<MauiRenderer, TObject> where TObject : MarkdownObject
    {
        protected override void Write(MauiRenderer renderer, TObject obj)
        {
            Write(renderer, obj);
        }
    }
}
