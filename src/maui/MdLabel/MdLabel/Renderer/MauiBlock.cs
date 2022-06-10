using MdLabel.Helper;

namespace MdLabel.Renderer
{
    internal record MauiSpanBlock
    {
        private readonly List<MauiSpan>? _spans = new();
                
        internal int TrailingNewLine { get; set; }

        internal IEnumerable<MauiSpan> GetSpans()
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
                return new List<MauiSpan>();
            }
        }

        internal void AddSpan(MauiSpan span)
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
