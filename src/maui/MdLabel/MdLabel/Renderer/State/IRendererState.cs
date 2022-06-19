using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public interface IRendererState : IDisposable
    {
        MarkdownBlockKind CurrentBlockKind { get; }
        IMauiBlock? CurrentSpanBlock { get; }
        IEnumerable<MarkdownInlineFormatKind> InlineFormatStack { get; }
        IEnumerable<IMauiBlock> SpanBlocks { get; }
        Uri? Uri { get; }

        void AddNewLine();
        void ClearHeader();
        void ClearLink();
        void CloseBlock();
        void CloseListBlock();
        void OpenBlock();
        void OpenListBlock();
        void PopInlineFormatType();
        void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType);
        void SetHeaderLevel(int level);
        void SetLink(Uri uri);
    }
}
