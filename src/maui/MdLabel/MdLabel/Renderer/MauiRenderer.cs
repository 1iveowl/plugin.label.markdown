using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>
    {
        private readonly Stack<MarkdownInlineFormatKind> _markdownInlineFormatStack = new();
        private readonly List<MauiSpanBlock> _mauiSpanBlocks = new();

        private Style? _currentStyle = default;
        private MauiSpanBlock? _currentSpanBlock = default;
        private Uri? _uri = default;


        internal FormattedString GetFormattedString()
        {
            var formattedString = new FormattedString();

            foreach (var span in _mauiSpanBlocks.SelectMany(block => block.GetSpans()))
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }
        internal Style? Style { get; init; }

        internal Color? UrlLinkColor { get; init; }        
        internal Dictionary<int, Style>? HeaderStyles { get; init; }
        internal bool IsExtraHeaderSpacing { get; init; }

        public bool EnableHtmlForBlock { get; set; }
        public bool EnableHtmlForInline { get; set; }
        public bool EnableHtmlEscape { get; set; }
        public bool ImplicitParagraph { get; set; }

        public Uri? BaseUrl { get; set; }

        public MauiRenderer(TextWriter writer, Style style) : base(writer)
        {
            Style = style;
            _currentStyle = style;

            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());
            ObjectRenderers.Add(new MauiHeadingRenderer());
            ObjectRenderers.Add(new MauiLineBreakInlineRenderer());
            ObjectRenderers.Add(new MauiLinkInlineRenderer());

            ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            ObjectWriteAfter += MdRenderer_ObjectWriteAfter;

            //ImplicitParagraph = true;
            EnableHtmlForBlock = true;
            EnableHtmlForInline = true;
            EnableHtmlEscape = false;
        }

        internal void SetHeaderStyle(int i)
        {
            if (HeaderStyles is not null
                && i >= 1 
                && i <= HeaderStyles?.Count)
            {

                if (HeaderStyles.TryGetValue(i, out var style))
                {
                    _currentStyle = style;
                }                
            }            
        }

        internal void RemoveHeaderStyle()
        {
            _currentStyle = Style;
        }

        internal MauiRenderer WriteInline(ref StringSlice slice)
        {
            if (_currentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            Span? span = default;

            var (attributes, decorations) = GetInlineFormating();

            if (_markdownInlineFormatStack.Any(inlineFormat => inlineFormat == MarkdownInlineFormatKind.Link)
                && _uri is not null)
            {
                var urlText = slice.ToString();

                span = new Span()
                {
                    Text = urlText,
                    TextDecorations = decorations,
                    TextColor = UrlLinkColor,
                    FontAttributes = attributes,
                    
                    Style = _currentStyle
                };

                var tap = new TapGestureRecognizer()
                {
                    Command = new Command<string>(async _ =>
                    {
                        await Launcher.OpenAsync(_uri);
                    }),
                    CommandParameter = urlText
                };

                span.GestureRecognizers.Add(tap);
            }
            else
            {
                span = new Span()
                {
                    Text = slice.ToString(),
                    FontAttributes = attributes,
                    TextDecorations = decorations,
                    Style = _currentStyle
                };


            }

            _currentSpanBlock?.AddSpan(span);

            return this;
        }

        internal void OpenLink(Uri uri)
        {
            if (_currentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            PushInlineType(MarkdownInlineFormatKind.Link);
            _uri = uri;     
        }
        internal void CloseLink()
        {
            PopInlineType();
            _uri = default;
        }

        internal void PushInlineType(MarkdownInlineFormatKind markdownLineType)
        {
            _markdownInlineFormatStack.Push(markdownLineType);
        }

        internal void PopInlineType()
        {
            if (_markdownInlineFormatStack.Count > 0)
            {
                _markdownInlineFormatStack.Pop();
            }
        }

        internal void AddNewLine()
        {
            if (_currentSpanBlock is not null)
            {
                _currentSpanBlock.TrailingNewLine++;
            }
            else
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }
        }

        internal void OpenBlock()
        {
            if (_currentSpanBlock is not null)
            {
                CloseBlock();
            }

            _currentSpanBlock = new MauiSpanBlock();
        }

        internal void CloseBlock()
        {
            if (_currentSpanBlock is not null)
            {
                _mauiSpanBlocks.Add(_currentSpanBlock);
            }

            _currentSpanBlock = default;
        }

        private (FontAttributes attributes, TextDecorations decorations) GetInlineFormating()
        {
            FontAttributes fontAttributes = FontAttributes.None;
            TextDecorations decorations = TextDecorations.None;

            foreach (var inlineFormat in _markdownInlineFormatStack)
            {
                switch (inlineFormat)
                {
                    case MarkdownInlineFormatKind.None:
                        break;
                    case MarkdownInlineFormatKind.Link:
                        decorations += (int)TextDecorations.Underline;
                        break;
                    case MarkdownInlineFormatKind.Comment:
                    case MarkdownInlineFormatKind.TextRun:
                        break;
                    case MarkdownInlineFormatKind.Bold:
                        fontAttributes += (int)FontAttributes.Bold;
                        break;
                    case MarkdownInlineFormatKind.Italic:
                        fontAttributes += (int)FontAttributes.Italic;
                        break;
                    case MarkdownInlineFormatKind.Underline:
                        decorations += (int)TextDecorations.Underline;
                        break;
                    case MarkdownInlineFormatKind.StrikeThrough:
                        decorations += (int)TextDecorations.Strikethrough;
                        break;
                    case MarkdownInlineFormatKind.SuperScript:
                        break;
                    case MarkdownInlineFormatKind.Subscript:
                        break;
                    case MarkdownInlineFormatKind.Code:
                        break;
                    case MarkdownInlineFormatKind.Image:
                        break;
                    case MarkdownInlineFormatKind.Inserted:
                        break;
                    case MarkdownInlineFormatKind.Marked:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (fontAttributes, decorations);
        }

        private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }
    }
}


