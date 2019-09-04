using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Plugin.Label.MarkDown.Renderer;
using Xamarin.Forms;

namespace Plugin.Label.MarkDown
{
    public class LabelMarkdown : Xamarin.Forms.Label
    {
        private static string _originalTextMarkdownStr;
        private static string _textMarkdownStr;

        private static Style _header1Style;
        private static Style _header2Style;
        private static Style _header3Style;

        private static string _variable1;
        private static string _variable2;
        private static string _variable3;
        private static string _variable4;
        private static string _variable5;
        private static string _variable6;

        public static readonly BindableProperty TextMarkdownProperty = BindableProperty.Create(
            propertyName: "TextMarkdown",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            defaultBindingMode:BindingMode.OneWay,
            OnTextMarkdownValidateValue,
            OnTextMarkdownPropertyChanged);

        public string TextMarkdown
        {
            get => (string) GetValue(TextMarkdownProperty);
            set => SetValue(TextMarkdownProperty, value);
        }

        public static readonly BindableProperty Header1StyleProperty = BindableProperty.Create(
            propertyName: "Header1Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(Style),
            propertyChanged: OnHeader1StylePropertyChanged);

        public Style Header1Style
        {
            get => (Style) GetValue(Header1StyleProperty);
            set => SetValue(Header1StyleProperty, value);
        }

        public static readonly BindableProperty Header2StyleProperty = BindableProperty.Create(
            propertyName: "Header2Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(Style),
            propertyChanged: OnHeader2StylePropertyChanged);

        public Style Header2Style
        {
            get => (Style) GetValue(Header2StyleProperty);
            set => SetValue(Header2StyleProperty, value);
        }

        public static readonly BindableProperty Header3StyleProperty = BindableProperty.Create(
            propertyName: "Header3Style",
            returnType: typeof(Style),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(Style),
            propertyChanged:OnHeader3StylePropertyChanged);


        public Style Header3Style
        {
            get => (Style) GetValue(Header3StyleProperty);
            set => SetValue(Header3StyleProperty, value);
        }

        public static readonly BindableProperty Variable1Property = BindableProperty.Create(
            propertyName: "Variable1",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged:OnVariable1PropertyChanged);


        public string Variable1
        {
            get => (string) GetValue(Variable1Property);
            set => SetValue(Variable1Property, value);
        }

        public static readonly BindableProperty Variable2Property = BindableProperty.Create(
            propertyName: "Variable2",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged: OnVariable2PropertyChanged);

        public string Variable2
        {
            get => (string) GetValue(Variable2Property);
            set => SetValue(Variable2Property, value);
        }

        public static readonly BindableProperty Variable3Property = BindableProperty.Create(
            propertyName: "Variable3",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged: OnVariable3PropertyChanged);

        public string Variable3
        {
            get => (string) GetValue(Variable3Property);
            set => SetValue(Variable3Property, value);
        }

        public static readonly BindableProperty Variable4Property = BindableProperty.Create(
            propertyName: "Variable4",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged: OnVariable4PropertyChanged);

        public string Variable4
        {
            get => (string) GetValue(Variable4Property);
            set => SetValue(Variable4Property, value);
        }

        public static readonly BindableProperty Variable5Property = BindableProperty.Create(
            propertyName: "Variable5",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged: OnVariable5PropertyChanged);

        public string Variable5
        {
            get => (string) GetValue(Variable5Property);
            set => SetValue(Variable5Property, value);
        }

        public static readonly BindableProperty Variable6Property = BindableProperty.Create(
            propertyName: "Variable6",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            propertyChanged: OnVariable6PropertyChanged);

        public string Variable6
        {
            get => (string) GetValue(Variable6Property);
            set => SetValue(Variable6Property, value);
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
            if (bindable is LabelMarkdown labelMarkdown 
                && newvalue != oldvalue 
                && newvalue is string str)
            {
                _originalTextMarkdownStr = str;
                UpdateFormattedText(labelMarkdown);
            }
        }

        private static void OnHeader1StylePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown labelMarkdown
                && newvalue != oldvalue
                && newvalue is Style style)
            {
                _header1Style = style;

                UpdateFormattedText(labelMarkdown);
            }
        }

        private static void OnHeader2StylePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown labelMarkdown
                && newvalue != oldvalue
                && newvalue is Style style)
            {
                _header2Style = style;

                UpdateFormattedText(labelMarkdown);
            }
        }

        private static void OnHeader3StylePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown labelMarkdown
                && newvalue != oldvalue
                && newvalue is Style style)
            {
                _header3Style = style;

                UpdateFormattedText(labelMarkdown);
            }
        }

        private static void OnVariable1PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable1 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }

        private static void OnVariable2PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable2 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }
        private static void OnVariable3PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable3 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }
        private static void OnVariable4PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable4 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }
        private static void OnVariable5PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable5 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }
        private static void OnVariable6PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown lableMarkDown
                && newvalue != oldvalue
                && newvalue is string str)
            {
                _variable6 = str;
                UpdateFormattedText(lableMarkDown);
            }
        }


        private static void UpdateFormattedText(LabelMarkdown labelMarkdown)
        {
            AddVariablesToMarkdownString();

            if (!string.IsNullOrEmpty(_textMarkdownStr))
            {
                labelMarkdown.FormattedText = GetFormattedString(_textMarkdownStr);
            }
        }

        private static void AddVariablesToMarkdownString()
        {
            _textMarkdownStr = _originalTextMarkdownStr;

            if (!string.IsNullOrEmpty(_textMarkdownStr))
            {
                if (!string.IsNullOrEmpty(_variable1))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{1}}", _variable1);
                }

                if (!string.IsNullOrEmpty(_variable2))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{2}}", _variable2);
                }

                if (!string.IsNullOrEmpty(_variable3))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{3}}", _variable3);
                }

                if (!string.IsNullOrEmpty(_variable4))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{4}}", _variable4);
                }

                if (!string.IsNullOrEmpty(_variable5))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{5}}", _variable5);
                }

                if (!string.IsNullOrEmpty(_variable6))
                {
                    _textMarkdownStr = _textMarkdownStr.Replace("{{6}}", _variable6);
                }
            }
        }

        private static FormattedString GetFormattedString(string str)
        {
            var fs = new FormattedString();

            var document = new MarkdownDocument();
            document.Parse(str);

            if (document.Blocks.Any())
            {
                var renderer = new LabelMarkdownRenderer(
                    document, 
                    new Dictionary<int, Style>
                    {
                        {1, _header1Style}, 
                        {2, _header2Style}, 
                        {3, _header3Style}
                    });

                renderer.Render(new RendererContext{Parent = fs});
            }

            return fs;
        }

    }
}
