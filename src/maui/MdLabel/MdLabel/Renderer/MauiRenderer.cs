using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using MdLabel.Factory;
using MdLabel.Helper;
using MdLabel.Renderer.Inline;
using MdLabel.Spans;

namespace MdLabel.Renderer
{
    public class MauiRenderer : TextRendererBase<MauiRenderer>, IDisposable
    {
        private readonly ISpanFactory _spanFactory;
        private readonly MauiRenderState _state = new();

        public MauiRenderer(ISpanFactory spanFactory) : base(new StringWriter())
        {
            _spanFactory = spanFactory;

            ObjectRenderers.Add(new MauiParagraphRenderer());
            ObjectRenderers.Add(new MauiLiteralInlineRenderer());
            ObjectRenderers.Add(new MauiEmphasisInlineRenderer());
            ObjectRenderers.Add(new MauiHeadingRenderer());
            ObjectRenderers.Add(new MauiLineBreakInlineRenderer());
            ObjectRenderers.Add(new MauiLinkInlineRenderer());
            ObjectRenderers.Add(new MauiListRenderer());

            ObjectWriteBefore += MdRenderer_ObjectWriteBefore;
            ObjectWriteAfter += MdRenderer_ObjectWriteAfter;
        }

        internal FormattedString GetFormattedString()
        {
            var formattedString = new FormattedString();

            foreach (var span in _state.SpanBlocks.SelectMany(block => block.GetSpans()))
            {
                formattedString.Spans.Add(span);
            }

            return formattedString;
        }

        internal void WriteSpan(ref StringSlice slice)
        {
            if (_state.CurrentSpanBlock is null)
            {
                throw new NullReferenceException($"{nameof(MauiSpanBlock)} cannot be null");
            }

            var text = slice.ToString();
            
            MarkdownSpanBase? markdownSpan = default;

            if(_state.InlineFormatStack.Any(inlineFormat => inlineFormat == MarkdownInlineFormatKind.Link) 
                && _state.Uri is not null)
            {
                markdownSpan = _state.CurrentHeaderLevel is MarkdownHeaderLevelKind.None
                    ? new MarkdownInlineLinkSpan()
                    : _state.CurrentHeaderLevel.GetHeaderSpan(true);

                markdownSpan.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command<string>(async _ =>
                    {
                        await Launcher.OpenAsync(_state.Uri);
                    }),
                    CommandParameter = text
                });
            }
            else
            {
                markdownSpan = _state.CurrentHeaderLevel is MarkdownHeaderLevelKind.None
                    ? new MarkdownInlineSpan()
                    : _state.CurrentHeaderLevel.GetHeaderSpan();
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

            _state.CurrentSpanBlock?.AddSpan(markdownSpan);
        }

        private (FontAttributes attributes, TextDecorations decorations) GetInlineFormating()
        {
            FontAttributes fontAttributes = FontAttributes.None;
            TextDecorations decorations = TextDecorations.None;

            foreach (var inlineFormat in _state.InlineFormatStack)
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
                    case MarkdownInlineFormatKind.Default:
                    //case MarkdownInlineFormatKind.Link:
                    //case MarkdownInlineFormatKind.Comment:
                    //case MarkdownInlineFormatKind.TextRun:
                    case MarkdownInlineFormatKind.SuperScript:
                    case MarkdownInlineFormatKind.Subscript:
                    //case MarkdownInlineFormatKind.Code:
                    //case MarkdownInlineFormatKind.Image:
                    //case MarkdownInlineFormatKind.Inserted:
                    //case MarkdownInlineFormatKind.Marked:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (fontAttributes, decorations);
        }

        internal void SetHeaderStyle(int level) => _state.SetHeaderStyle(level);

        internal void ClearHeaderStyle() => _state.ClearHeaderStyle();

        internal void SetLink(Uri uri) => _state.SetLink(uri);

        internal void ClearLink() => _state.ClearLink();

        internal void PushInlineFormatType(MarkdownInlineFormatKind markdownLineType) => _state.PushInlineFormatType(markdownLineType);

        internal void PopInlineFormatType() => _state.PopInlineFormatType();

        internal void AddNewLine() => _state.AddNewLine();

        internal void OpenBlock() => _state.OpenBlock();

        internal void CloseBlock() => _state.CloseBlock();

        private void MdRenderer_ObjectWriteAfter(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        private void MdRenderer_ObjectWriteBefore(IMarkdownRenderer arg1, MarkdownObject arg2)
        {

        }

        public void Dispose() => _state.Dispose();
    }
}


