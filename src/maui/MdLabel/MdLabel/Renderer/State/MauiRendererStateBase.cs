using MdLabel.Renderer.Blocks;
using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public abstract class MauiRendererStateBase : IDisposable
    {
        private readonly Stack<MarkdownInlineFormatKind> _inlineFormatStack = new();
        private readonly Stack<IMauiBlockGroup> _blockGroupStack = new();
        private readonly List<IMauiBlock> _blocks = new();

        private bool _isBlockItem;

        protected IMauiBlockGroup? CurrentBlockGroup => 
            _blockGroupStack.TryPeek(out var blockGroup) 
                ? blockGroup 
                : default;

        public virtual IMauiBlock? CurrentTextBlock => _blocks.Any()
            ? _blocks.Last()
            : default;

        public virtual MarkdownBlockKind CurrentTextBlockKind => _blocks.Any()
            ? _blocks.Last().BlockKind
            : MarkdownBlockKind.Paragraph;

        public virtual IEnumerable<MarkdownInlineFormatKind> InlineFormats => _inlineFormatStack;
        public virtual IEnumerable<Span> MarkdownSpans => _blocks.SelectMany(block => block.GetSpans());

        public Uri? Uri { get; private set; } = default;

        public bool IsParagraphPartOfBlock => (CurrentTextBlockKind 
            is MarkdownBlockKind.List
            or MarkdownBlockKind.Code
            or MarkdownBlockKind.Blockquote)
            && _isBlockItem;


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

        public virtual void AddSpanToBlock(Span markdownSpan)
        {
            if (CurrentTextBlock is not null)
            {
                CurrentTextBlock?.AddSpan(markdownSpan);
            }
            else
            {
                throw new NullReferenceException($"{nameof(MauiTextBlock)} cannot be null");
            }            
        }

        protected virtual void SetUri(Uri? uri)
        {
            Uri = uri;
        }

        protected virtual void BeginBlockGroup<TBlockGroup>(Func<TBlockGroup, TBlockGroup>? blockGroupInit = default) 
            where TBlockGroup : IMauiBlockGroup, new()
        {
            var blockGroup = _blockGroupStack.Count == 0
                ? new TBlockGroup { IndentLevel = 0 }
                : new TBlockGroup { IndentLevel = _blockGroupStack.Peek().IndentLevel + 1 };

            if (blockGroupInit is not null)
            {
                blockGroup = blockGroupInit(blockGroup);
            }

            _blockGroupStack.Push(blockGroup);
        }

        protected virtual void AddBlock(IMauiBlock block)
        {
            if (block is MauiListItemBlock
                or MauiQuoteItemBlock
                or MauiCodeItemBlock)
            {
                _isBlockItem = true;
            }

            _blocks.Add(block);
        }

        protected virtual void EndItem()
        {
            _isBlockItem = false;
        }

        protected virtual void EndBlockGroup()
        {           

            if (_blockGroupStack.Count == 0)
            {
                throw new InvalidOperationException("Did not expect the Text Block Group to be empty or null");
            }

            var blockGroup = _blockGroupStack.Pop();

            _blocks.Last().SetIndentLevel(blockGroup.IndentLevel);
        }

        protected virtual void AddIndenting<TBlock, TBlockGroup, TSpan>(
            TBlock listBlock,
            TBlockGroup blockGroup)
                where TBlock : IMauiBlock
                where TBlockGroup : IMauiBlockGroup
                where TSpan : MarkdownSpanBase, new()
        {
            for (int i = 0; i < blockGroup.IndentLevel; i++)
            {
                listBlock.AddSpan(new TSpan { Text = "    " });
            }
        }

        public virtual void Dispose()
        {
            _blocks.Clear();
            _inlineFormatStack.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
