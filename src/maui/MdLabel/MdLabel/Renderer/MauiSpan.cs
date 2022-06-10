namespace MdLabel.Renderer
{
    public class MauiSpan : Span
    {
        public static readonly BindableProperty SpanStyleProperty = BindableProperty.Create(
            propertyName: nameof(SpanStyle),
            returnType: typeof(Style),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(Style),
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                if (newVal != oldVal
                    && bindable is Span span
                    && newVal is Style style)
                {
                    span.Style = style;
                }                
            });

        public Style SpanStyle
        {
            get => (Style)GetValue(SpanStyleProperty);
            set => SetValue(SpanStyleProperty, value);
        }
    }
}
