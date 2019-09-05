using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Plugin.Label.MarkDown.Renderer;
using Xamarin.Forms;

namespace Plugin.Label.MarkDown.CustomControl
{
    public class LabelMarkdownControl : ContentView
    {
        private static event EventHandler OnUpdateEventHandler;

        private static event EventHandler<MarkdownTextEventArgs> OnUpdateMarkupTextEventHandler;

        private string _textMarkdownStr;

        public static readonly BindableProperty MarkdownFormattedStringProperty = BindableProperty.Create(
            propertyName: "MarkdownFormattedString",
            returnType: typeof(FormattedString),
            declaringType: typeof(LabelMd),
            defaultValue: default(FormattedString));

        public FormattedString MarkdownFormattedString
        {
            get => (FormattedString) GetValue(MarkdownFormattedStringProperty);
            set => SetValue(MarkdownFormattedStringProperty, value);
        }

        public static readonly BindableProperty TextMarkdownProperty = BindableProperty.Create(
            propertyName: "TextMarkdown",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            defaultBindingMode:BindingMode.OneWay,
            OnTextMarkdownValidateValue,
            OnTextMarkdownPropertyChanged);

        public string TextMarkdown
        {
            get => (string) GetValue(TextMarkdownProperty);
            set => SetValue(TextMarkdownProperty, value);
        }

        public static readonly BindableProperty UrlLinkColorProperty = BindableProperty.Create(
            propertyName: "UrlLinkColor",
            returnType: typeof(Color),
            declaringType: typeof(LabelMd),
            defaultValue: Color.Blue,
            propertyChanged: OnUpdatePropertyChanged);

        public Color UrlLinkColor
        {
            get => (Color) GetValue(UrlLinkColorProperty);
            set => SetValue(UrlLinkColorProperty, value);
        }

        public static readonly BindableProperty Header1StyleProperty = BindableProperty.Create(
            propertyName: "Header1Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMd),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);

        public Style Header1Style
        {
            get => (Style) GetValue(Header1StyleProperty);
            set => SetValue(Header1StyleProperty, value);
        }

        public static readonly BindableProperty Header2StyleProperty = BindableProperty.Create(
            propertyName: "Header2Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMd),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);

        public Style Header2Style
        {
            get => (Style) GetValue(Header2StyleProperty);
            set => SetValue(Header2StyleProperty, value);
        }

        public static readonly BindableProperty Header3StyleProperty = BindableProperty.Create(
            propertyName: "Header3Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMd),
            defaultValue: default(Style),
            propertyChanged: OnUpdatePropertyChanged);


        public Style Header3Style
        {
            get => (Style) GetValue(Header3StyleProperty);
            set => SetValue(Header3StyleProperty, value);
        }

        public static readonly BindableProperty Variable1Property = BindableProperty.Create(
            propertyName: "Variable1",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);


        public string Variable1
        {
            get => (string) GetValue(Variable1Property);
            set => SetValue(Variable1Property, value);
        }

        public static readonly BindableProperty Variable2Property = BindableProperty.Create(
            propertyName: "Variable2",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable2
        {
            get => (string) GetValue(Variable2Property);
            set => SetValue(Variable2Property, value);
        }

        public static readonly BindableProperty Variable3Property = BindableProperty.Create(
            propertyName: "Variable3",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable3
        {
            get => (string) GetValue(Variable3Property);
            set => SetValue(Variable3Property, value);
        }

        public static readonly BindableProperty Variable4Property = BindableProperty.Create(
            propertyName: "Variable4",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable4
        {
            get => (string) GetValue(Variable4Property);
            set => SetValue(Variable4Property, value);
        }

        public static readonly BindableProperty Variable5Property = BindableProperty.Create(
            propertyName: "Variable5",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable5
        {
            get => (string) GetValue(Variable5Property);
            set => SetValue(Variable5Property, value);
        }

        public static readonly BindableProperty Variable6Property = BindableProperty.Create(
            propertyName: "Variable6",
            returnType: typeof(string),
            declaringType: typeof(LabelMd),
            defaultValue: default(string),
            propertyChanged: OnUpdatePropertyChanged);

        public string Variable6
        {
            get => (string) GetValue(Variable6Property);
            set => SetValue(Variable6Property, value);
        }

        public LabelMarkdownControl()
        {
            OnUpdateEventHandler += OnUpdateEvent;

            OnUpdateMarkupTextEventHandler += OnOnUpdateMarkupTextEvent;
        }

        private void OnUpdateEvent(object sender, EventArgs e)
        {
            if (sender is LabelMd labelMarkdown)
            {
                UpdateFormattedText();
            }
        }

        private void OnOnUpdateMarkupTextEvent(object sender, MarkdownTextEventArgs e)
        {
            if (sender is LabelMd labelMarkdown)
            {
                //_originalTextMarkdownStr = e.MarkdownText;

                OnUpdateEvent(sender, e);
            }
        }

        private static void OnUpdatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMd labelMarkdown && oldvalue != newvalue)
            {
                OnUpdateEventHandler?.Invoke(labelMarkdown, null);
            }
        }
        
        private static bool OnTextMarkdownValidateValue(BindableObject bindable, object value)
        {
            var str = (string)value;

            if (str is null)
            {
                return false;
            }

            var document = new MarkdownDocument();

            try
            {
                document.Parse(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void OnTextMarkdownPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMd labelMarkdown 
                && newvalue != oldvalue 
                && newvalue is string str)
            {
                OnUpdateMarkupTextEventHandler?.Invoke(labelMarkdown, new MarkdownTextEventArgs{MarkdownText = str});
            }
        }

        private void UpdateFormattedText()
        {
            AddVariablesToMarkdownString();

            if (!string.IsNullOrEmpty(_textMarkdownStr))
            {
                MarkdownFormattedString = GetFormattedString(_textMarkdownStr);
            }
        }

        private FormattedString GetFormattedString(string str)
        {
            var fs = new FormattedString();

            var document = new MarkdownDocument();

            var markdownStr = str.Replace("\r", "  ");
            
            document.Parse(markdownStr);

            if (document.Blocks.Any())
            {
                var renderer = new LabelMarkdownRenderer(
                    document, 
                    UrlLinkColor,
                    new Dictionary<int, Style>
                    {
                        {1, Header1Style}, 
                        {2, Header2Style}, 
                        {3, Header3Style}
                    });

                renderer.Render(new RendererContext{Parent = fs});
            }

            return fs;
        }

        private void AddVariablesToMarkdownString()
        {
            _textMarkdownStr = TextMarkdown;

            if (!string.IsNullOrEmpty(_textMarkdownStr))
            {
                if (!string.IsNullOrEmpty(Variable1))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{1}}", Variable1);
                }

                if (!string.IsNullOrEmpty(Variable2))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{2}}", Variable2);
                }

                if (!string.IsNullOrEmpty(Variable3))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{3}}", Variable3);
                }

                if (!string.IsNullOrEmpty(Variable4))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{4}}", Variable4);
                }

                if (!string.IsNullOrEmpty(Variable5))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{5}}", Variable5);
                }

                if (!string.IsNullOrEmpty(Variable6))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{6}}", Variable6);
                }
            }
        }
    }
}
