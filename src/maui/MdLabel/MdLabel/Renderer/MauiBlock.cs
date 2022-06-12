using MdLabel.Helper;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    internal record MauiSpanBlock
    {
        private readonly List<MarkdownSpanBase>? _spans = new();
                
        internal int TrailingNewLine { get; set; }

        internal IEnumerable<MarkdownSpanBase> GetSpans()
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

        internal void AddSpan(MarkdownSpanBase span)
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
    }
}
