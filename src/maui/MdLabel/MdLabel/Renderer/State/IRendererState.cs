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

        bool IsParagraphPartOfBlock { get; }

        void AddSpanToBlock(Span span);

        void AddNewLine();

        void SetLink(Uri uri);
        void EndLink();

        void OpenTextBlock();
        void AddTextBlock(MarkdownBlockKind blockKind);
        void CloseBlock();

        void BeginListBlockGroup(bool IsOrdered, char? orderDelimiter);
        void EndListBlockGroup();
        void AddListBlockItem(int order);
        void EndListBlockItem();

        void BeginQuoteBlockGroup();
        void EndQuoteBlockGroup();
        void AddQuoteBlockItem();
        void EndQuoteBlockItem();

        void BeginCodeBlockGroup();
        void EndCodeBlockGroup();
        void AddCodeBlockItem();
        void EndCodeBlockItem();

        void PopInlineFormatType();
        void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType);
    }
}
