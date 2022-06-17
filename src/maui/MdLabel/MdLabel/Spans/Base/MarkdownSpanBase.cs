using Markdig;

namespace MdLabel.Spans
{
    public abstract class MarkdownSpanBase : Span
    {
        internal bool IsLink { get; private set; }

        public static readonly BindableProperty UrlColorProperty = BindableProperty.Create(
            propertyName: nameof(UrlColor),
            returnType: typeof(Color),
            declaringType: typeof(MarkdownSpanBase),
            defaultValue: default(Color),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (bindable is MarkdownSpanBase markdownSpan 
                    && markdownSpan.IsLink)
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
                    && markdownSpan.IsLink)
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

        protected MarkdownSpanBase(bool isLink)
        {
            IsLink = isLink;

            if (isLink)
            {                
                SetValue(TextColorProperty, UrlColor);
                SetValue(TextDecorationsProperty, UrlTextDecorations);
            }
        }
    }
}
