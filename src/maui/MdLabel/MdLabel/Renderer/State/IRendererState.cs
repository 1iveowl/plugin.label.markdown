using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public interface IRendererState : IDisposable
    {
        MarkdownBlockKind CurrentTextBlockKind { get; }
        //IMauiTextBlock? CurrentSpanBlock { get; }
        IEnumerable<MarkdownInlineFormatKind> InlineFormats { get; }
        IEnumerable<MarkdownSpanBase> MarkdownSpans { get; }
        Uri? Uri { get; }

        void AddSpan(MarkdownSpanBase span);

        void AddNewLine();

        void SetLink(Uri uri);
        void EndLink();

        void OpenTextBlock(MarkdownBlockKind blockKind);
        void CloseTextBlock();

        void BeginListBlock(bool isOrdered);
        void EndListBlock();
        void BeginListBlockItem();
        void EndListBlockItem();

        void PopInlineFormatType();
        void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType);

        //void SetHeaderLevel(int level);
        //void EndHeader();

    }
}
