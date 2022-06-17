using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    internal class MauiRenderState : IDisposable
    {
        private List<MauiSpanBlock> CurrentListBlock { get; set; } = new();

        internal List<MauiSpanBlock> SpanBlocks { get; private set; } = new();
        internal Stack<MarkdownInlineFormatKind> InlineFormatStack { get; private set; } = new();
        internal MarkdownSpanKind CurrentSpanKind { get; private set; } = MarkdownSpanKind.Default;

        internal MauiSpanBlock? CurrentSpanBlock { get; private set; } = default;
        internal MarkdownHeaderLevelKind CurrentHeaderLevel { get; private set; } = MarkdownHeaderLevelKind.None;

        internal Uri? Uri { get; private set; } = default;

        internal void SetHeaderStyle(int level)
        {
            if (level >= 1 && level <= 6)
            {
                CurrentHeaderLevel = (MarkdownHeaderLevelKind)level;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Header level must be between 1 and 6.");
            }
        }

        internal void ClearHeaderStyle()
        {
            CurrentHeaderLevel = MarkdownHeaderLevelKind.None;
        }

        internal void SetLink(Uri uri)
        {
            if (CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            PushInlineFormatType(MarkdownInlineFormatKind.Link);
            Uri = uri;
        }

        internal void ClearLink()
        {
            PopInlineFormatType();
            Uri = default;
        }

        internal void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType)
        {
            InlineFormatStack.Push(markdownLineType);
        }

        internal void PopInlineFormatType()
        {
            if (InlineFormatStack.Count > 0)
            {
                InlineFormatStack.Pop();
            }
        }

        internal void AddNewLine()
        {
            if (CurrentSpanBlock is not null)
            {
                CurrentSpanBlock.TrailingNewLine++;
            }
            else
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }
        }

        internal void OpenBlock()
        {
            // TODO Implement

            if (CurrentListBlock is not null)
            {
                CurrentListBlock.Clear();
            }

            CurrentSpanBlock = new MauiSpanBlock();
        }

        internal void CloseBlock()
        {
            // TODO Implement

            if (CurrentSpanBlock is not null)
            {
                SpanBlocks.Add(CurrentSpanBlock);
            }

            CurrentSpanBlock = default;
        }

        internal void OpenListBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                CloseBlock();
            }

            CurrentSpanBlock = new MauiSpanBlock();
        }

        internal void CloseListBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                SpanBlocks.Add(CurrentSpanBlock);
            }

            CurrentSpanBlock = default;
        }

        public void Dispose()
        {
            InlineFormatStack.Clear();
            SpanBlocks.Clear();
        }
    }
}
