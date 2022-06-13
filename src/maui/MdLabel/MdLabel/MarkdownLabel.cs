using Markdig;
using MdLabel.Renderer;

namespace MdLabel
{
    public class MarkdownLabel : Label, IMarkdownLabel
    {
        private static event EventHandler? OnUpdateTextEventHandler;

        public static new readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(MarkdownLabel),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: OnTextMarkdownPropertyChanged);

        public new string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public MarkdownLabel()
        {
            var rd = new ResourceDictionary();
            Resources.MergedDictionaries.Add(rd);
        }

        protected override void OnHandlerChanging(HandlerChangingEventArgs args)
        {
            base.OnHandlerChanging(args);
            OnUpdateTextEventHandler -= MarkdownLabel_OnUpdateTextEventHandler;
        }

        protected override void OnHandlerChanged()
        {
            OnUpdateTextEventHandler += MarkdownLabel_OnUpdateTextEventHandler;

            UpdateFormattedText(Text);
        }

        private void MarkdownLabel_OnUpdateTextEventHandler(object? sender, EventArgs? e)
        {
            if (sender is MarkdownLabel)
            {
                UpdateFormattedText(Text);
            }
        }

        private static void OnUpdatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is MarkdownLabel labelMarkdown
                && oldvalue != newvalue)
            {
                OnUpdateTextEventHandler?.Invoke(labelMarkdown, EventArgs.Empty);
            }
        }

        private static void OnTextMarkdownPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is MarkdownLabel labelMarkdown
                && newvalue is string
                && (!oldvalue?.Equals(newvalue) ?? true))
            {                
                OnUpdateTextEventHandler?.Invoke(labelMarkdown, EventArgs.Empty);
            }
        }

        private void UpdateFormattedText(string markdownString)
        {
            if (!string.IsNullOrEmpty(markdownString))
            {
                FormattedText = new MauiRenderer().GetFormattedString(markdownString);
            }
        }
    }
}

