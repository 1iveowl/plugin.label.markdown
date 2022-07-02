using MdLabel.Renderer.Inline;

namespace MdLabel.Spans
{
    public abstract class MarkdownSpanBase : Span
    {
        private readonly IEnumerable<MarkdownInlineFormatKind>? InlineFormats;

        public static readonly BindableProperty UrlColorProperty = BindableProperty.Create(
            propertyName: nameof(UrlColor),
            returnType: typeof(Color),
            declaringType: typeof(MarkdownSpanBase),
            defaultValue: default(Color),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is MarkdownSpanBase markdownSpan
                    && markdownSpan.InlineFormats is not null
                    && markdownSpan.InlineFormats.Any(il => il is MarkdownInlineFormatKind.Link))
                {
                    markdownSpan.TextColor = markdownSpan.UrlColor;
                }
            });

        public Color UrlColor
        {
            get => (Color)GetValue(UrlColorProperty);
            set => SetValue(UrlColorProperty, value);
        }

        public static readonly BindableProperty UrlTextDecorationsProperty = BindableProperty.Create(
            propertyName: nameof(UrlTextDecorations),
            returnType: typeof(TextDecorations),
            declaringType: typeof(MarkdownSpanBase),
            defaultValue: default(TextDecorations),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is MarkdownSpanBase markdownSpan
                    && markdownSpan.InlineFormats is not null
                    && markdownSpan.InlineFormats.Any(il => il is MarkdownInlineFormatKind.Link))
                {
                    markdownSpan.TextDecorations = markdownSpan.UrlTextDecorations;
                }                
            });

        public TextDecorations UrlTextDecorations
        {
            get => (TextDecorations)GetValue(UrlTextDecorationsProperty);
            set => SetValue(UrlTextDecorationsProperty, value);
        }

        protected MarkdownSpanBase()
        {

        }

        protected MarkdownSpanBase(IEnumerable<MarkdownInlineFormatKind>? inlineFormats)
        {
            // Make copy of inlineFormats in this instance of the span.
            InlineFormats = inlineFormats?.ToList();

            if (inlineFormats is not null 
                && inlineFormats.Any(il => il is MarkdownInlineFormatKind.Link))
            {                
                SetValue(TextColorProperty, UrlColor);
                SetValue(TextDecorationsProperty, UrlTextDecorations);
            }
        }
    }
}
