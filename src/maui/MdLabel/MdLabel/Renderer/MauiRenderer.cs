using Markdig;
using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using MdLabel.Helper;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>
    {
        private readonly Stack<MarkdownInlineFormatKind> _markdownInlineFormatStack = new();
        private readonly List<MauiSpanBlock> _mauiSpanBlocks = new();

        private MauiSpanBlock? _currentSpanBlock = default;
        private Uri? _uri = default;
        private MarkdownHeaderKind _markdownHeaderKind = MarkdownHeaderKind.None;

        internal FormattedString GetFormattedString(string markdownString)
        {
            markdownString = markdownString
                    .Replace("  ", Environment.NewLine);

            var pipeline = new MarkdownPipelineBuilder()
                .UseEmojiAndSmiley()
                .UseEmphasisExtras()
                .Build();

            Markdown.Convert(markdownString, this, pipeline);

            var formattedString = new FormattedString();

            foreach (var span in _mauiSpanBlocks.SelectMany(block => block.GetSpans()))
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        //public bool EnableHtmlForBlock { get; set; }
        //public bool EnableHtmlForInline { get; set; }
        //public bool EnableHtmlEscape { get; set; }
        //public bool ImplicitParagraph { get; set; }

        public Uri? BaseUrl { get; set; }

        public MauiRenderer() : base(new StringWriter())
        {
            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());
            ObjectRenderers.Add(new MauiHeadingRenderer());
            ObjectRenderers.Add(new MauiLineBreakInlineRenderer());
            ObjectRenderers.Add(new MauiLinkInlineRenderer());

            ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            ObjectWriteAfter += MdRenderer_ObjectWriteAfter;

            //EnableHtmlForBlock = true;
            //EnableHtmlForInline = true;
            //EnableHtmlEscape = false;
        }

        internal void SetHeaderStyle(int level)
        {
            if (level >= 1 && level <= 6)
            {
                _markdownHeaderKind = (MarkdownHeaderKind)level;
            }
        }

        internal void RemoveHeaderStyle()
        {
            _markdownHeaderKind = MarkdownHeaderKind.None;
        }

        internal void WriteSpan(ref StringSlice slice)
        {
            if (_currentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            var text = slice.ToString();
            
            MarkdownSpanBase? markdownSpan = default;

            if(_markdownInlineFormatStack.Any(inlineFormat => inlineFormat == MarkdownInlineFormatKind.Link) 
                && _uri is not null)
            {
                markdownSpan = _markdownHeaderKind is MarkdownHeaderKind.None
                    ? new MarkdownInlineLinkSpan()
                    : _markdownHeaderKind.GetHeaderLinkSpan();

                markdownSpan.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command<string>(async _ =>
                    {
                        await Launcher.OpenAsync(_uri);
                    }),
                    CommandParameter = text
                });
            }
            else
            {
                markdownSpan = _markdownHeaderKind is MarkdownHeaderKind.None
                    ? new MarkdownInlineSpan()
                    : _markdownHeaderKind.GetHeaderSpan();
            }

            var (fontAttributes, textDecorations) = GetInlineFormating();

            if (textDecorations is not TextDecorations.None)
            {
                markdownSpan.TextDecorations = textDecorations;
            }

            if (fontAttributes is not FontAttributes.None)
            {
                markdownSpan.FontAttributes = fontAttributes;
            }            

            markdownSpan.Text = text;

            _currentSpanBlock?.AddSpan(markdownSpan);
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
                    case MarkdownInlineFormatKind.None:
                    case MarkdownInlineFormatKind.Link:
                    case MarkdownInlineFormatKind.Comment:
                    case MarkdownInlineFormatKind.TextRun:
                    case MarkdownInlineFormatKind.SuperScript:
                    case MarkdownInlineFormatKind.Subscript:
                    case MarkdownInlineFormatKind.Code:
                    case MarkdownInlineFormatKind.Image:
                    case MarkdownInlineFormatKind.Inserted:
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


