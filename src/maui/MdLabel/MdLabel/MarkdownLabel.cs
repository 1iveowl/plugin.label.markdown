using Markdig;
using MdLabel.Renderer;

namespace MdLabel
{
    public class MarkdownLabel : Label, IMarkdownLabel
    {
        private static event EventHandler OnUpdateEventHandler;

        private string _markdownString;

        public static readonly BindableProperty TextMarkdownProperty = BindableProperty.Create(
            propertyName: "TextMarkdown",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.OneWay,
            OnTextMarkdownValidateValue,
            OnTextMarkdownPropertyChanged);

        public string TextMarkdown
        {
            get => (string)GetValue(TextMarkdownProperty);
            set => SetValue(TextMarkdownProperty, value);
        }

        public static readonly BindableProperty UrlLinkColorProperty = BindableProperty.Create(
            propertyName: "UrlLinkColor",
            returnType: typeof(Color),
            declaringType: typeof(MarkdownLabel),
            defaultValue: Colors.Blue,
            propertyChanged: OnUpdatePropertyChanged);

        public Color UrlLinkColor
        {
            get => (Color)GetValue(UrlLinkColorProperty);
            set => SetValue(UrlLinkColorProperty, value);
        }

        public static readonly BindableProperty IsParagraphSpacingProperty = BindableProperty.Create(
            propertyName: "IsParaGraphSpacing",
            returnType: typeof(bool),
            declaringType: typeof(MarkdownLabel),
            defaultValue: true);

        public bool IsParagraphSpacing
        {
            get => (bool)GetValue(IsParagraphSpacingProperty);
            set => SetValue(IsParagraphSpacingProperty, value);
        }

        public static readonly BindableProperty Header1StyleProperty = BindableProperty.Create(
            propertyName: "Header1Style",
            returnType: typeof(Style),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);

        public static readonly BindableProperty IsExtraHeaderSpacingProperty = BindableProperty.Create(
            propertyName: "IsExtraHeaderSpacing",
            returnType: typeof(bool),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(bool));

        public bool IsExtraHeaderSpacing
        {
            get => (bool)GetValue(IsExtraHeaderSpacingProperty);
            set => SetValue(IsExtraHeaderSpacingProperty, value);
        }

        public Style Header1Style
        {
            get => (Style)GetValue(Header1StyleProperty);
            set => SetValue(Header1StyleProperty, value);
        }

        public static readonly BindableProperty Header2StyleProperty = BindableProperty.Create(
            propertyName: "Header2Style",
            returnType: typeof(Style),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);

        public Style Header2Style
        {
            get => (Style)GetValue(Header2StyleProperty);
            set => SetValue(Header2StyleProperty, value);
        }

        public static readonly BindableProperty Header3StyleProperty = BindableProperty.Create(
            propertyName: "Header3Style",
            returnType: typeof(Style),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);


        public Style Header3Style
        {
            get => (Style)GetValue(Header3StyleProperty);
            set => SetValue(Header3StyleProperty, value);
        }

        public static readonly BindableProperty Variable1Property = BindableProperty.Create(
            propertyName: "Variable1",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);


        public string Variable1
        {
            get => (string)GetValue(Variable1Property);
            set => SetValue(Variable1Property, value);
        }

        public static readonly BindableProperty Variable2Property = BindableProperty.Create(
            propertyName: "Variable2",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable2
        {
            get => (string)GetValue(Variable2Property);
            set => SetValue(Variable2Property, value);
        }

        public static readonly BindableProperty Variable3Property = BindableProperty.Create(
            propertyName: "Variable3",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable3
        {
            get => (string)GetValue(Variable3Property);
            set => SetValue(Variable3Property, value);
        }

        public static readonly BindableProperty Variable4Property = BindableProperty.Create(
            propertyName: "Variable4",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable4
        {
            get => (string)GetValue(Variable4Property);
            set => SetValue(Variable4Property, value);
        }

        public static readonly BindableProperty Variable5Property = BindableProperty.Create(
            propertyName: "Variable5",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable5
        {
            get => (string)GetValue(Variable5Property);
            set => SetValue(Variable5Property, value);
        }

        public static readonly BindableProperty Variable6Property = BindableProperty.Create(
            propertyName: "Variable6",
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable6
        {
            get => (string)GetValue(Variable6Property);
            set => SetValue(Variable6Property, value);
        }

        public MarkdownLabel()
        {
            OnUpdateEventHandler += OnUpdateEvent;
        }

        private void OnUpdateEvent(object sender, EventArgs e)
        {
            if (sender is MarkdownLabel labelMarkdown)
            {
                UpdateFormattedText();
            }
        }


        private static void OnUpdatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is MarkdownLabel labelMarkdown 
                && oldvalue != newvalue)
            {
                OnUpdateEventHandler?.Invoke(labelMarkdown, null);
            }
        }

        private static bool OnTextMarkdownValidateValue(BindableObject bindable, object value)
        {
            var str = (string)value;

            if (str is not null)
            {
                return true;
            }

            return false;

            //var document = new MarkdownDocument();

            //try
            //{
            //    document.Parse(str);
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        private static void OnTextMarkdownPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is MarkdownLabel labelMarkdown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                OnUpdateEventHandler?.Invoke(labelMarkdown, null);
            }
        }

        private void UpdateFormattedText()
        {
            AddVariablesToMarkdownString();

            if (!string.IsNullOrEmpty(_markdownString))
            {
                FormattedText = GetFormattedString(_markdownString);
            }
        }

        private FormattedString GetFormattedString(string str)
        {

            //var writer = new StringWriter();

            var renderer = new MauiRenderer(new StringWriter());
                       

            var markdownString = str.Replace("\r", "  ")
                .Replace("  \n", IsParagraphSpacing 
                                            ? "  \n  \n" 
                                            : "  \n");

            Markdown.Convert(markdownString, renderer);

            return renderer.FormattedString;

            //document.Parse(markdownStr);

            //if (document.Blocks.Any())
            //{

            //    var renderer = new LabelMarkdownRenderer(
            //        document,
            //        Style,
            //        UrlLinkColor,
            //        new Dictionary<int, Style>
            //        {
            //            {1, Header1Style},
            //            {2, Header2Style},
            //            {3, Header3Style}
            //        },
            //        IsExtraHeaderSpacing);

            //    renderer.Render(new RendererContext { Parent = fs });
            //}

            //if (fs.Spans.Any())
            //{
            //    // Remove the extra New Line feed added to the end, which should not be there.
            //    fs.Spans.Remove(fs.Spans.Last());
            //}

            //return fs;
        }

        private void AddVariablesToMarkdownString()
        {
            _markdownString = TextMarkdown;

            if (!string.IsNullOrEmpty(_markdownString))
            {
                _markdownString = _markdownString.Replace("{{1}}", Variable1 ?? string.Empty);

                _markdownString = _markdownString.Replace("{{2}}", Variable2 ?? string.Empty);

                _markdownString = _markdownString.Replace("{{3}}", Variable3 ?? string.Empty);

                _markdownString = _markdownString.Replace("{{4}}", Variable4 ?? string.Empty);

                _markdownString = _markdownString.Replace("{{5}}", Variable5 ?? string.Empty);

                _markdownString = _markdownString.Replace("{{6}}", Variable6 ?? string.Empty);
            }
        }
    }
}

