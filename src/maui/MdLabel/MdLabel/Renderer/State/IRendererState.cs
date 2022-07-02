using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public interface IRendererState : IDisposable
    {
        MarkdownBlockKind CurrentTextBlockKind { get; }
        IEnumerable<MarkdownInlineFormatKind> InlineFormats { get; }
        IEnumerable<Span> MarkdownSpans { get; }
        Uri? Uri { get; }

        void AddSpanToBlock(Span span);

        void AddNewLine();

        void SetLink(Uri uri);
        void EndLink();

        void OpenTextBlock(MarkdownBlockKind blockKind);
        void CloseBlock();

        void BeginListBlockGroup(bool IsOrdered, char? orderDelimiter);
        void EndListBlockGroup();
        void BeginListBlockItem(int order);
        void EndListBlockItem();

        void PopInlineFormatType();
        void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType);

        //void SetHeaderLevel(int level);
        //void EndHeader();

    }
}
