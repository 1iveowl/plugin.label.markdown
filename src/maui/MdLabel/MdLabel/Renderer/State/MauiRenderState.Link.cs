using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public partial class MauiRenderState
    {
        public virtual void SetLink(Uri uri)
        {
            if (CurrentTextBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiTextBlock)} cannot be null");
            }

            PushInlineFormatType(MarkdownInlineFormatKind.Link);
            SetUri(uri);
        }

        public virtual void EndLink()
        {
            PopInlineFormatType();
            SetUri(default);
        }
    }
}

