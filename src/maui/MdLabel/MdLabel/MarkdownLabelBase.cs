using Markdig;
using MdLabel.Factory;
using MdLabel.Renderer;

namespace MdLabel
{
    public abstract class MarkdownLabelBase : Label, IMarkdownLabel
    {
        public static new readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabelBase),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is MarkdownLabelBase markdownLabel
                    && newValue is string markdownString
                    && (!oldValue?.Equals(newValue) ?? true))
                {
                    markdownLabel.FormattedText = markdownLabel.Convert(markdownString);
                }
            });

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        protected abstract IMauiRenderer GetRenderer();

        protected virtual ISpanFactory? SpanFactory { get; set; }

        protected virtual MarkdownPipeline? GetMarkdownPipeline() => 
            new MarkdownPipelineBuilder()
                        .UseEmojiAndSmiley()
                        .UseEmphasisExtras()
                        .Build();

        protected virtual FormattedString Convert(string markdownString)
        {
            using var mauiRenderer = GetRenderer();

            Markdown.Convert(
                        markdownString.Replace("  ", Environment.NewLine),
                        mauiRenderer,
                        GetMarkdownPipeline());

            return mauiRenderer.GetFormattedString();
        }
    }
}

