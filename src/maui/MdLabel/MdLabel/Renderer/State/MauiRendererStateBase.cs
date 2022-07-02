using MdLabel.Renderer.Blocks;
using MdLabel.Renderer.Inline;

namespace MdLabel.Renderer
{
    public abstract class MauiRendererStateBase : IDisposable
    {
        private readonly Stack<MarkdownInlineFormatKind> _inlineFormatStack = new();
        private readonly Stack<IMauiBlockGroup> _blockGroupStack = new();
        private readonly List<IMauiBlock> _blocks = new();

        protected IMauiBlockGroup CurrentBlockGroup => _blockGroupStack.Peek();

        public virtual IMauiBlock? CurrentTextBlock => _blocks.Any()
            ? _blocks.Last()
            : default;

        public virtual MarkdownBlockKind CurrentTextBlockKind => _blocks.Any()
            ? _blocks.Last().BlockKind
            : MarkdownBlockKind.Paragraph;

        public virtual IEnumerable<MarkdownInlineFormatKind> InlineFormats => _inlineFormatStack;
        public virtual IEnumerable<Span> MarkdownSpans => _blocks.SelectMany(block => block.GetSpans());

        public Uri? Uri { get; private set; } = default;


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

        protected virtual void BeginBlockGroup<TBlockGroup>(Action<TBlockGroup>? blockGroupInit = default) 
            where TBlockGroup : IMauiBlockGroup, new()
        {
            var blockGroup = _blockGroupStack.Count == 0
                ? new TBlockGroup { IndentLevel = 0 }
                : new TBlockGroup { IndentLevel = _blockGroupStack.Peek().IndentLevel + 1 };

            if (blockGroupInit is not null)
            {
                blockGroupInit(blockGroup);
            }

            _blockGroupStack.Push(blockGroup);
        }

        protected virtual void AddBlock(IMauiBlock textBlock)
        {
            _blocks.Add(textBlock);
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

        public virtual void Dispose()
        {
            _blocks.Clear();
            _inlineFormatStack.Clear();
        }
    }
}
