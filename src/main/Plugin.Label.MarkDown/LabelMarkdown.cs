using System;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown;
using Plugin.Label.MarkDown.Renderer;
using Xamarin.Forms;

namespace Plugin.Label.MarkDown
{
    public class LabelMarkdown : Xamarin.Forms.Label
    {
        public static readonly BindableProperty TextMarkdownProperty = BindableProperty.Create(
            propertyName: "TextMarkdown",
            returnType: typeof(string),
            declaringType: typeof(LabelMarkdown),
            defaultValue: default(string),
            defaultBindingMode:BindingMode.OneWay,
            OnValidateValue,
            OnPropertyChanged);

        public string TextMarkdown
        {
            get => (string) GetValue(TextMarkdownProperty);
            set => SetValue(TextMarkdownProperty, value);
        }

        private static bool OnValidateValue(BindableObject bindable, object value)
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

        private static void OnPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LabelMarkdown labelMarkdown 
                && newvalue != oldvalue 
                && newvalue is string str)
            {
                labelMarkdown.FormattedText = GetFormattedString(str);
            }
        }

        private static FormattedString GetFormattedString(string str)
        {
            var fs = new FormattedString();

            var document = new MarkdownDocument();
            document.Parse(str);

            if (document.Blocks.Any())
            {
                var renderer = new LabelMarkdownRenderer(document);

                renderer.Render(new RendererContext{Parent = fs});
            }

            return fs;
        }

    }
}
