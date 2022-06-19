using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public abstract class MauiRendererStateBase : IDisposable
    {
        private readonly Stack<MarkdownInlineFormatKind> _inlineFormatStack = new();
        private readonly Stack<IMauiTextBlock> _blockStack = new();
        
        private readonly List<IMauiTextBlock> _textBlocks = new();

        public virtual IMauiTextBlock? CurrentTextBlock => _blockStack.Any()
            ? _blockStack.Last()
            : default;

        public virtual MarkdownBlockKind CurrentTextBlockKind => _blockStack.Any()
            ? _blockStack.Last().BlockKind
            : MarkdownBlockKind.Paragraph;

        public virtual IEnumerable<MarkdownInlineFormatKind> InlineFormats => _inlineFormatStack;
        public virtual IEnumerable<MarkdownSpanBase> MarkdownSpans => _textBlocks.SelectMany(block => block.GetSpans());

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

        public virtual void AddSpan(MarkdownSpanBase markdownSpan)
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

        protected virtual void BeginTextBlock(IMauiTextBlock textBlock)
        {
            if (CurrentTextBlock is not null)
            {
                throw new Exception("Current Text block is not closed before a new is added.");
            }

            _blockStack.Push(textBlock);
        }

        protected virtual void EndTextBlock()
        {
            if (CurrentTextBlock is not null)
            {
                _textBlocks.Add(CurrentTextBlock);
            }

            _blockStack.Pop();
        }

        public virtual void Dispose()
        {
            _textBlocks.Clear();
            _inlineFormatStack.Clear();
        }
    }
}
