using Markdig;
using MdLabel.Renderer;

namespace MdLabel
{
    public class MarkdownLabel : Label, IMarkdownLabel
    {
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
                    && (!oldValue?.Equals(newValue) ?? true))
                {
                    using var mauiRenderer = new MauiRenderer();

                    Markdown.Convert(
                        markdownString.Replace("  ", Environment.NewLine),
                        mauiRenderer, 
                        _markdownPipeline);

                    labelMarkdown.FormattedText = mauiRenderer.GetFormattedString();
                }
            });

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}

