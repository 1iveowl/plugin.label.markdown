using Markdig;
using MdLabel.Renderer;

namespace MdLabel;

public partial class MarkdownView : ContentView, IMarkdownLabel
{
    private static event EventHandler? OnUpdateTextEventHandler;
    private static event EventHandler? OnUpdateEventHandler;

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(string),
        defaultBindingMode: BindingMode.OneWay,
        validateValue: OnTextMarkdownValidateValue,
        propertyChanged: (bindObj, newVal, oldVal) =>
        {
            if (bindObj is MarkdownView markdownView)
            {
                markdownView.UpdateFormattedText();
            }
        });

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty UrlLinkColorProperty = BindableProperty.Create(
        propertyName: nameof(UrlLinkColor),
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
        propertyName: nameof(IsParagraphSpacing),
        returnType: typeof(bool),
        declaringType: typeof(MarkdownLabel),
        defaultValue: true);

    public bool IsParagraphSpacing
    {
        get => (bool)GetValue(IsParagraphSpacingProperty);
        set => SetValue(IsParagraphSpacingProperty, value);
    }

    public static readonly BindableProperty IsExtraHeaderSpacingProperty = BindableProperty.Create(
        propertyName: nameof(IsExtraHeaderSpacing),
        returnType: typeof(bool),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(bool));

    public bool IsExtraHeaderSpacing
    {
        get => (bool)GetValue(IsExtraHeaderSpacingProperty);
        set => SetValue(IsExtraHeaderSpacingProperty, value);
    }

    #region headers

    public static readonly BindableProperty Header1StyleProperty = BindableProperty.Create(
        propertyName: nameof(Header1Style),
        returnType: typeof(Style),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(Style),
        propertyChanged: OnUpdatePropertyChanged);

    public Style Header1Style
    {
        get => (Style)GetValue(Header1StyleProperty);
        set => SetValue(Header1StyleProperty, value);
    }

    public static readonly BindableProperty Header2StyleProperty = BindableProperty.Create(
        propertyName: nameof(Header2Style),
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
        propertyName: nameof(Header3Style),
        returnType: typeof(Style),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(Style),
        propertyChanged: OnUpdatePropertyChanged);


    public Style Header3Style
    {
        get => (Style)GetValue(Header3StyleProperty);
        set => SetValue(Header3StyleProperty, value);
    }

    public static readonly BindableProperty Header4StyleProperty = BindableProperty.Create(
        propertyName: nameof(Header4Style),
        returnType: typeof(Style),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(Style),
        propertyChanged: OnUpdatePropertyChanged);


    public Style Header4Style
    {
        get => (Style)GetValue(Header4StyleProperty);
        set => SetValue(Header4StyleProperty, value);
    }

    public static readonly BindableProperty Header5StyleProperty = BindableProperty.Create(
        propertyName: nameof(Header5Style),
        returnType: typeof(Style),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(Style),
        propertyChanged: OnUpdatePropertyChanged);


    public Style Header5Style
    {
        get => (Style)GetValue(Header5StyleProperty);
        set => SetValue(Header5StyleProperty, value);
    }

    public static readonly BindableProperty Header6StyleProperty = BindableProperty.Create(
        propertyName: nameof(Header6Style),
        returnType: typeof(Style),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(Style),
        propertyChanged: OnUpdatePropertyChanged);


    public Style Header6Style
    {
        get => (Style)GetValue(Header6StyleProperty);
        set => SetValue(Header6StyleProperty, value);
    }

    public static readonly BindableProperty Variable1Property = BindableProperty.Create(
        propertyName: nameof(Variable1),
        returnType: typeof(string),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(string),
        propertyChanged: OnUpdatePropertyChanged);

    #endregion

    #region variables
    public string Variable1
    {
        get => (string)GetValue(Variable1Property);
        set => SetValue(Variable1Property, value);
    }

    public static readonly BindableProperty Variable2Property = BindableProperty.Create(
        propertyName: nameof(Variable2),
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
        propertyName: nameof(Variable3),
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
        propertyName: nameof(Variable4),
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
        propertyName: nameof(Variable5),
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
        propertyName: nameof(Variable6),
        returnType: typeof(string),
        declaringType: typeof(MarkdownLabel),
        defaultValue: default(string),
        propertyChanged: OnUpdatePropertyChanged);

    public string Variable6
    {
        get => (string)GetValue(Variable6Property);
        set => SetValue(Variable6Property, value);
    }

    #endregion

    //public static readonly BindableProperty FormattedTextProperty = BindableProperty.Create(
    //    propertyName: nameof(FormattedString),
    //    returnType: typeof(FormattedString),
    //    declaringType: typeof(MarkdownLabel),
    //    defaultValue: default(FormattedString),
    //    defaultValueCreator: bindObj =>
    //    {
    //        if (bindObj is MarkdownView markdownView)
    //        {
    //            return markdownView.UpdateFormattedText();
    //        }

    //        return default;
    //    });

    //public FormattedString FormattedString
    //{
    //    get => (FormattedString)GetValue(FormattedTextProperty);
    //    set => SetValue(FormattedTextProperty, value);
    //}

    public MarkdownView()
	{
		InitializeComponent();
	}




    public FormattedString? UpdateFormattedText()
    {
        var markdownString = AddVariablesToMarkdownString();

        if (!string.IsNullOrEmpty(markdownString))
        {
            var formattedText = GetFormattedString(markdownString);

            MarkdownLabel.FormattedText = formattedText;

            return formattedText;
        }

        return default;
    }

    private FormattedString GetFormattedString(string markdownString)
    {
        var renderer = new MauiRenderer(new StringWriter(), Style)
        {
            UrlLinkColor = UrlLinkColor,
            IsExtraHeaderSpacing = IsExtraHeaderSpacing,
            HeaderStyles = new Dictionary<int, Style>
                {
                    {1, Header1Style},
                    {2, Header2Style},
                    {3, Header3Style},
                    {4, Header4Style},
                    {5, Header5Style},
                    {6, Header6Style},
                }
        };

        markdownString = markdownString
            .Replace("  ", Environment.NewLine + Environment.NewLine);

        var pipeline = new MarkdownPipelineBuilder().UseEmojiAndSmiley().UseEmphasisExtras().Build();

        Markdown.Convert(markdownString, renderer, pipeline);

        return renderer.GetFormattedString();
    }

    private string AddVariablesToMarkdownString()
    {
        var markdownString = Text;

        if (!string.IsNullOrEmpty(Text))
        {
            markdownString = Text.Replace("{{1}}", Variable1 ?? string.Empty)
                .Replace("{{2}}", Variable2 ?? string.Empty)
                .Replace("{{3}}", Variable3 ?? string.Empty)
                .Replace("{{4}}", Variable4 ?? string.Empty)
                .Replace("{{5}}", Variable5 ?? string.Empty)
                .Replace("{{6}}", Variable6 ?? string.Empty);
        }

        return markdownString;
    }

    private static void OnTextMarkdownValidateValue(BindableObject bindable, object oldvalue, object newvalue)
    {
            OnUpdateTextEventHandler?.Invoke(bindable, EventArgs.Empty);
    }

    private static bool OnTextMarkdownValidateValue(BindableObject bindable, object value)
    {
        var str = (string)value;

        if (str is not null)
        {
            return true;
        }

        return false;
    }

    private static void OnTextMarkdownPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is MarkdownView labelMarkdown
            && newvalue is string
            && (!oldvalue?.Equals(newvalue) ?? true))
        {
            OnUpdateTextEventHandler?.Invoke(labelMarkdown, EventArgs.Empty);
        }
    }

    private static void OnUpdatePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is MarkdownLabel labelMarkdown
            && oldvalue != newvalue)
        {
            OnUpdateEventHandler?.Invoke(labelMarkdown, EventArgs.Empty);
        }
    }
}