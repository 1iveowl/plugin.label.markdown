using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public class MauiRenderState : IRendererState
    {
        private readonly List<IMauiSpanBlock> _currentListBlock  = new();
        private readonly List<IMauiSpanBlock> _spanBlocks  = new();
        private readonly Stack<MarkdownInlineFormatKind> _inlineFormatStack = new();

        public IEnumerable<IMauiSpanBlock> CurrentListBlock => _currentListBlock;
        public IEnumerable<IMauiSpanBlock> SpanBlocks => _spanBlocks;
        public IEnumerable<MarkdownInlineFormatKind> InlineFormatStack => _inlineFormatStack;

        public IMauiSpanBlock? CurrentSpanBlock { get; private set; } = default;
        public MarkdownBlockKind CurrentBlockKind { get; private set; } = MarkdownBlockKind.Default;

        public Uri? Uri { get; private set; } = default;

        public virtual void SetHeaderLevel(int level)
        {
            if (level >= 1 && level <= 6)
            {
                CurrentBlockKind = (MarkdownBlockKind)level;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Header level must be between 1 and 6.");
            }
        }

        public virtual void ClearHeader()
        {
            CurrentBlockKind = MarkdownBlockKind.Default;
        }

        public virtual void SetLink(Uri uri)
        {
            if (CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            PushInlineFormatType(MarkdownInlineFormatKind.Link);
            Uri = uri;
        }

        public virtual void ClearLink()
        {
            PopInlineFormatType();
            Uri = default;
        }

        public virtual void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType)
        {
            _inlineFormatStack.Push(markdownLineType);
        }

        public virtual void PopInlineFormatType()
        {
            if (_inlineFormatStack.Count > 0)
            {
                _inlineFormatStack.Pop();
            }
        }

        public virtual void AddNewLine()
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

        public virtual void OpenBlock()
        {
            // TODO Implement

            if (CurrentListBlock is not null)
            {
                _currentListBlock.Clear();
            }

            CurrentSpanBlock = new MauiSpanBlock();
        }

        public virtual void CloseBlock()
        {
            // TODO Implement

            if (CurrentSpanBlock is not null)
            {
                _spanBlocks.Add(CurrentSpanBlock);
            }

            CurrentSpanBlock = default;
        }

        public virtual void OpenListBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                CloseBlock();
            }

            CurrentSpanBlock = new MauiSpanBlock();
        }

        public virtual void CloseListBlock()
        {
            if (CurrentSpanBlock is not null)
            {
                _spanBlocks.Add(CurrentSpanBlock);
            }

            CurrentSpanBlock = default;
        }

        public virtual void Dispose()
        {
            _inlineFormatStack.Clear();
            _spanBlocks.Clear();
        }
    }
}
