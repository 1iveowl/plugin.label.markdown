using MdLabel.Renderer.Inline;
using MdLabel.Helper;

namespace MdLabel.Renderer.Blocks
{
    public abstract record MauiBlockBase : IMauiBlock
    {
        private readonly List<Span>? _spans = new();

        //public int TrailingNewLine { get; private set; }

        public MarkdownBlockKind BlockKind { get; init; }

        public int IndentLevel {get; private set; }

        public MauiBlockBase(MarkdownBlockKind blockKind)
        {
            BlockKind = blockKind;
        }

        public virtual void AddSpan(Span span)
        {
            if (span is not null)
            {
                //if (TrailingNewLine > 0)
                //{
                //    var stringBuilder = StringBuilderCache.Acquire().Append(span.Text);

                //    for (var i = 0; i < TrailingNewLine; i++)
                //    {
                //        stringBuilder.Append(Environment.NewLine);
                //    }                    

                //    span.Text = StringBuilderCache.GetStringAndRelease(stringBuilder);

                //    TrailingNewLine = 0;
                //}

                _spans?.Add(span);
            }
        }

        public virtual IEnumerable<Span> GetSpans()
        {
            if (_spans?.Any() ?? false)
            {
                var stringBuilder = StringBuilderCache.Acquire().Append(_spans.Last().Text);
                stringBuilder.Append(Environment.NewLine);
                _spans.Last().Text = StringBuilderCache.GetStringAndRelease(stringBuilder);

                return _spans;
            }
            else
            {
                return new List<Span>();
            }
        }

        public void SetIndentLevel(int level)
        {
            IndentLevel = level;
        }
    }
}
