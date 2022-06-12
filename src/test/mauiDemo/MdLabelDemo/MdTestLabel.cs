namespace MdLabelDemo
{
    public class MdTestLabel : Label
    {
        public static new readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(MdTestLabel),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                if (bindable is MdTestLabel mdTestLabel
                    && newVal is string str)
                {
                    var fs = new FormattedString();

                    fs.Spans.Add(new TestHeader1Span() { Text = str});

                    mdTestLabel.FormattedText = fs;
                }
            });

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty Header1StyleProperty = BindableProperty.Create(
            propertyName: nameof(Header1Style),
            returnType: typeof(Style),
            declaringType: typeof(MdTestLabel),
            defaultValue: default(Style),
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                if (bindable is MdTestLabel mdTestLabel
                    && newVal is Style style)
                {

                }
            });

        public Style Header1Style
        {
            get => (Style)GetValue(Header1StyleProperty);
            set => SetValue(Header1StyleProperty, value);
        }

        public MdTestLabel()
        {

        }
    }
}
