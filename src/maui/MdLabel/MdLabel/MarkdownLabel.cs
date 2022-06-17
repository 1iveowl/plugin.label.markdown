using Markdig;
using MdLabel.Factory;
using MdLabel.Renderer;

namespace MdLabel
{
    public class MarkdownLabel : Label, IMarkdownLabel
    {
        private readonly ISpanFactory SpanFactory = new SpanFactory();

        private static readonly MarkdownPipeline? _markdownPipeline = 
            new MarkdownPipelineBuilder()
                        .UseEmojiAndSmiley()
                        .UseEmphasisExtras()
                        .Build();

        public static new readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is MarkdownLabel labelMarkdown
                    && newValue is string markdownString
                    && (!oldValue?.Equals(newValue) ?? true)
                    && labelMarkdown.SpanFactory is not null)
                {
                    using var mauiRenderer = new MauiRenderer(labelMarkdown.SpanFactory);

                    Markdown.Convert(
                        markdownString.Replace("  ", Environment.NewLine),
                        mauiRenderer, 
                        _markdownPipeline);

                    labelMarkdown.FormattedText = mauiRenderer.GetFormattedString();
                }
            });

        public MarkdownLabel()
        {
            SpanFactory = new SpanFactory();
        }

        public MarkdownLabel(ISpanFactory spanFactory)
        {
            SpanFactory = spanFactory;
        }

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public virtual ISpanFactory GetSpanFactory()
        {
            return SpanFactory;
        }
    }
}

