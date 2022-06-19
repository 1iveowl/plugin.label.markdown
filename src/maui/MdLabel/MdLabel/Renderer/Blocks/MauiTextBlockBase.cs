using MdLabel.Renderer.Inline;
using MdLabel.Spans;
using MdLabel.Helper;

namespace MdLabel.Renderer.Blocks
{
    public abstract record MauiTextBlockBase
    {
        private readonly List<MarkdownSpanBase>? _spans = new();

        public int TrailingNewLine { get; set; }

        public MarkdownBlockKind BlockKind { get; private set; }

        public MauiTextBlockBase(MarkdownBlockKind blockKind)
        {
            BlockKind = blockKind;
        }

        public virtual void AddSpan(MarkdownSpanBase span)
        {
            if (span is not null)
            {
                if (TrailingNewLine > 0)
                {
                    var stringBuilder = StringBuilderCache.Acquire().Append(span.Text);

                    for (var i = 0; i < TrailingNewLine; i++)
                    {
                        stringBuilder.Append(Environment.NewLine);
                    }

                    span.Text = StringBuilderCache.GetStringAndRelease(stringBuilder);
                }

                _spans?.Add(span);
            }
        }

        public virtual IEnumerable<MarkdownSpanBase> GetSpans()
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
                return new List<MarkdownSpanBase>();
            }
        }
    }
}
